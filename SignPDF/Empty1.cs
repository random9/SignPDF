/*
 * Creato da SharpDevelop.
 * Utente: glauco.rampogna
 * Data: 20/01/2011
 * Ora: 11.01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto;

String CERT_PATH  = "private.p12";
String CERT_PASSW = "password";
String TSA_URL    = "http://tsa.url.net/";
String TSA_ACCNT  = null;
String TSA_PASSW  = null;
string IN_FILE = "hello.pdf";
string OUT_FILE = "hello_signed_cs.pdf";

FileStream fs = new FileStream(CERT_PATH, FileMode.Open);
Pkcs12Store ks = new Pkcs12Store(fs, CERT_PASSW.ToCharArray());
string alias = null;
foreach (string al in ks.Aliases) {
	if (ks.IsKeyEntry(al) && ks.GetKey(al).Key.IsPrivate) {
		alias = al;
		break;
	}
}
fs.Close();
ICipherParameters pk = ks.GetKey(alias).Key;
X509CertificateEntry[] x = ks.GetCertificateChain(alias);
X509Certificate[] chain = new X509Certificate[x.Length];
for (int k = 0; k < x.Length; ++k) {
	chain[k] = x[k].Certificate;
}
ITSAClient tsc = new TSAClientBouncyCastle(TSA_URL, TSA_ACCNT, TSA_PASSW);

PdfReader reader = new PdfReader(IN_FILE);
FileStream fout = new FileStream(OUT_FILE, FileMode.Create);
PdfStamper stp = PdfStamper.CreateSignature(reader, fout, '\0');
PdfSignatureAppearance sap = stp.SignatureAppearance;

sap.SetCrypto(null, chain, null, PdfSignatureAppearance.SELF_SIGNED);

sap.SetVisibleSignature(new Rectangle(100, 100, 300, 200), 1, "Signature");

PdfSignature dic = new PdfSignature(PdfName.ADOBE_PPKLITE,
                                    new PdfName("adbe.pkcs7.detached"));
dic.Reason = sap.Reason;
dic.Location = sap.Location;
dic.Contact = sap.Contact;
dic.Date = new PdfDate(sap.SignDate);
sap.CryptoDictionary = dic;

int contentEstimated = 15000;
// Preallocate excluded byte-range for the signature content (hex encoded)
Hashtable exc = new Hashtable();
exc[PdfName.CONTENTS] = contentEstimated * 2 + 2;
sap.PreClose(exc);

PdfPKCS7 sgn = new PdfPKCS7(pk, chain, null, "SHA1", false);
IDigest messageDigest = DigestUtilities.GetDigest("SHA1");
Stream data = sap.RangeStream;
byte[] buf = new byte[8192];
int n;
while ((n = data.Read(buf, 0, buf.Length)) > 0) {
	messageDigest.BlockUpdate(buf, 0, n);
}
byte[] hash = new byte[messageDigest.GetDigestSize()];
messageDigest.DoFinal(hash, 0);
DateTime cal = DateTime.Now;
byte[] ocsp = null;
if (chain.Length >= 2) {
	String url = PdfPKCS7.GetOCSPURL(chain[0]);
	if (url != null && url.Length > 0)
		ocsp =  new OcspClientBouncyCastle(chain[0], chain[1], url).GetEncoded();
}
byte[] sh = sgn.GetAuthenticatedAttributeBytes(hash, cal, ocsp);
sgn.Update(sh, 0, sh.Length);

byte[] encodedSig = sgn.GetEncodedPKCS7(hash, cal, tsc, ocsp);
if (contentEstimated + 2 < encodedSig.Length)
	throw new Exception("Not enough space");

byte[] paddedSig = new byte[contentEstimated];
System.Array.Copy(encodedSig, 0, paddedSig, 0, encodedSig.Length);

PdfDictionary dic2 = new PdfDictionary();
dic2.Put(PdfName.CONTENTS, new PdfString(paddedSig).SetHexWriting(true));
sap.Close(dic2);
