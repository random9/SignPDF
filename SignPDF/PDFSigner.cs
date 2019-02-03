﻿using System;
using System.Collections.Generic;
using System.Text;


using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.X509;
using System.Collections;
using Org.BouncyCastle.Pkcs;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.xml.xmp;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Asn1;

///
/// <summary>
/// This Library allows you to sign a PDF document using iTextSharp
/// </summary>
/// <author>Alaa-eddine KADDOURI</author>
///
///

namespace SignPDF
{
	/// <summary>
	/// this is the most important class
	/// it uses iTextSharp library to sign a PDF document
	/// </summary>
	class PDFSigner
	{
		private string inputPDF = "";
		private string outputPDF = "";
		private Cert myCert;
		private MetaData metadata;

		public PDFSigner(string input, string output)
		{
			this.inputPDF = input;
			this.outputPDF = output;
		}

		public PDFSigner(string input, string output, Cert cert)
		{
			this.inputPDF = input;
			this.outputPDF = output;
			this.myCert = cert;
		}
		public PDFSigner(string input, string output, MetaData md)
		{
			this.inputPDF = input;
			this.outputPDF = output;
			this.metadata = md;
		}
		public PDFSigner(string input, string output, Cert cert, MetaData md)
		{
			this.inputPDF = input;
			this.outputPDF = output;
			this.myCert = cert;
			this.metadata = md;
		}

		public static void Verify()
		{
            throw new NotSupportedException();
		}


		public void Sign(PDFSignatureAP sigAP, bool encrypt, PDFEncryption Enc)
		{
			PdfReader reader = new PdfReader(this.inputPDF);

			FileStream fs = new FileStream(this.outputPDF, FileMode.Create, FileAccess.Write);


			PdfStamper st;
			if (this.myCert == null) //No signature just write meta-data and quit
			{
				st = new PdfStamper(reader, fs);
			}
			else
			{
				st = PdfStamper.CreateSignature(reader, fs, '\0', null, sigAP.Multi);
			}

			if (encrypt && Enc != null) Enc.Encrypt(st);
			//st.SetEncryption(PdfWriter.STRENGTH128BITS, "user", "owner", PdfWriter.ALLOW_COPY);

			st.MoreInfo = this.metadata.getMetaData();
			st.XmpMetadata = this.metadata.getStreamedMetaData();

			if (this.myCert == null) //No signature just write meta-data and quit
			{
				st.Close();
				return;
			}

			PdfSignatureAppearance sap = st.SignatureAppearance;
			
			//sap.SetCrypto(this.myCert.Akp, this.myCert.Chain, null, PdfSignatureAppearance.WINCER_SIGNED);

			sap.SetCrypto(null, this.myCert.Chain, null, PdfSignatureAppearance.SELF_SIGNED);

			sap.Reason = sigAP.SigReason;
			sap.Contact = sigAP.SigContact;
			sap.Location = sigAP.SigLocation;
			if (sigAP.Visible)
			{
				iTextSharp.text.Rectangle rect = st.Reader.GetPageSize(sigAP.Page);
				sap.Image = sigAP.RawData == null ? null : iTextSharp.text.Image.GetInstance(sigAP.RawData);
				sap.Layer2Text = sigAP.CustomText;

				sap.SetVisibleSignature(new iTextSharp.text.Rectangle(sigAP.SigX, sigAP.SigY, sigAP.SigX + sigAP.SigW, sigAP.SigY + sigAP.SigH), sigAP.Page, null);
			}
			
			

			/////
			PdfSignature dic = new PdfSignature(PdfName.ADOBE_PPKLITE, new PdfName("adbe.pkcs7.detached"));
			dic.Reason = sap.Reason;
			dic.Location = sap.Location;
			dic.Contact = sap.Contact;
			dic.Date = new PdfDate(sap.SignDate);
			sap.CryptoDictionary = dic;

			int contentEstimated = 15000;
			// Preallocate excluded byte-range for the signature content (hex encoded)
			Dictionary<PdfName, int> exc = new Dictionary<PdfName, int>();
			exc[PdfName.CONTENTS] = contentEstimated * 2 + 2;
			sap.PreClose(exc);

			PdfPKCS7 sgn = new PdfPKCS7(this.myCert.Akp, this.myCert.Chain, null, "SHA1", false);
			IDigest messageDigest = DigestUtilities.GetDigest("SHA1");
			Stream data = sap.GetRangeStream();
			byte[] buf = new byte[8192];
			int n;
			while ((n = data.Read(buf, 0, buf.Length)) > 0)
			{
				messageDigest.BlockUpdate(buf, 0, n);
			}
			byte[] hash = new byte[messageDigest.GetDigestSize()];
			messageDigest.DoFinal(hash, 0);
			DateTime cal = DateTime.Now;
			byte[] ocsp = null;
			if (this.myCert.Chain.Length >= 2)
			{
				String url = PdfPKCS7.GetOCSPURL(this.myCert.Chain[0]);
                if (url != null && url.Length > 0)
                {
                    ocsp = new OcspClientBouncyCastle().GetEncoded(this.myCert.Chain[0], this.myCert.Chain[1], url);
                }
			}
			byte[] sh = sgn.GetAuthenticatedAttributeBytes(hash, cal, ocsp);
			sgn.Update(sh, 0, sh.Length);


			byte[] paddedSig = new byte[contentEstimated];
			

			if (this.myCert.Tsc != null)
			{
				byte[] encodedSigTsa = sgn.GetEncodedPKCS7(hash, cal, this.myCert.Tsc, ocsp);
				System.Array.Copy(encodedSigTsa, 0, paddedSig, 0, encodedSigTsa.Length);
                if (contentEstimated + 2 < encodedSigTsa.Length)
                {
                    throw new ArgumentNullException("Not enough space for signature");
                }
			}
			else
			{
				byte[] encodedSig = sgn.GetEncodedPKCS7(hash, cal);
				System.Array.Copy(encodedSig, 0, paddedSig, 0, encodedSig.Length);
                if (contentEstimated + 2 < encodedSig.Length)
                {
                    throw new ArgumentNullException("Not enough space for signature");
                }
			}
			


			PdfDictionary dic2 = new PdfDictionary();
			dic2.Put(PdfName.CONTENTS, new PdfString(paddedSig).SetHexWriting(true));
			sap.Close(dic2);
			
			//////
			//st.Close();
		}
		

	}
}




