/*
 * Creato da SharpDevelop.
 * Data: 05/01/2011
 * Ora: 16.23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml.xmp;

using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Tsp;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Asn1.Ess;
//using System.Runtime.InteropServices;
using GhostscriptSharp;
namespace SignPDF
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private PDFEncryption PDFEnc = new PDFEncryption();
		private PdfReader reader;
		private readonly PickBox pbox = new PickBox();
		// Acrobat objects
		//Acrobat.CAcroPDDoc pdfDoc;
		//Acrobat.CAcroPDPage pdfPage;
		//Acrobat.CAcroRect pdfRect;
		//Acrobat.CAcroPoint pdfPoint;
		private readonly string SignLocation =Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\.SignPDF";
		private readonly string TmpLocation =Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\.SignPDF\\tmp";
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			CheckCommandLine();
			InitializeComponent();
			pbox.WireControl(sigPicture);
			lbPosizioneFirma.SelectedIndex=2;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			// Verificare se il pdf e' gia stato firmato
			// Verificare il formato delle pagine
			// verificare se e' cifrato
			//
		}
		
		void CheckCommandLine() {
			if(Environment.GetCommandLineArgs().Length==2) {
				string file=Environment.GetCommandLineArgs()[1];
				if(File.Exists(file)) {
					string ext=file.Substring(1 + file.LastIndexOf(@".")).ToLower();
					bool CONMARCA=false;
					bool GiaFirmato=false;
					DialogResult dialogResult = MessageBox.Show("VUOI ANCHE MARCARLO TEMPORALMENTE?\nSe stai firmando un atto che diventa esecutivo con la tua firma\nCLICCA SI.","Domanda",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
					switch(dialogResult)
					{
						case DialogResult.Yes:
							CONMARCA=true;
							break;
						case DialogResult.No:
							CONMARCA=false;
							break;
						case DialogResult.Cancel:
							Environment.Exit(0);
							break;
                    }

                    if (ext == "p7m") {
                        GiaFirmato = true;
                    } else { 
							GiaFirmato=false;
					}
					/*switch(ext) {
						case "pdf":
							CONMARCA=true;
							break;
						case "p7m":
							CONMARCA=false;
							break;
					}*/
					
					try	{
						//il certificato per firmare
						X509Certificate2 card = null;
						//seleziono il certificato
						X509Store st = new X509Store(StoreName.My, StoreLocation.CurrentUser);
						st.Open(OpenFlags.ReadOnly);
						X509Certificate2Collection col = st.Certificates;
						//trovo i certificati per l'uso "NON RIPUDIO"
						X509Certificate2Collection selection=col.Find(X509FindType.FindByKeyUsage,X509KeyUsageFlags.NonRepudiation,true);
						//se sono molti faccio scegliere all'utente
						if(selection.Count>1) {
							X509Certificate2Collection selectedByUser = System.Security.Cryptography.X509Certificates.X509Certificate2UI.SelectFromCollection(selection, "Certificates", "Select one to sign", X509SelectionFlag.SingleSelection);
							if (selectedByUser.Count > 0)
							{
								X509Certificate2Enumerator en = selectedByUser.GetEnumerator();
								en.MoveNext();
								card = en.Current;
							}
						} else { //altrimenti uso l'unico che ho trovato
							X509Certificate2Enumerator en = selection.GetEnumerator();
							en.MoveNext();
							card = en.Current;
						}
						st.Close();
						string TSAURL = "http://10.0.0.245";
						string TSAUSER = "";
						string TSAPASS = "";
						string Res;
						if (card != null) {
							byte[] Firmato = FirmaFileBouncy(file, card, GiaFirmato, CONMARCA, TSAURL, TSAUSER, TSAPASS, out Res);
							if (string.IsNullOrEmpty(Res)) {
                                if (ext == "p7m")
                                {
                                    File.WriteAllBytes(file, Firmato);
                                }
                                else
                                {
                                    File.WriteAllBytes(file + ".p7m", Firmato);
                                }
							}
							else {
								throw new Exception(Res);
							}
						}
					}
					catch (Exception ex) {
						MessageBox.Show(ex.ToString());
					}
					if(File.Exists(file + ".p7m")) {
                        if (CONMARCA)
                        {
                            MessageBox.Show("File Firmato e Marcato correttamente", "Operazione Completata");
                        }
                        else
                        {
                            MessageBox.Show("File firmato correttamente", "Operazione Completata");
                        }
					}
				}
				Environment.Exit(0);
				
			}
		}
		void LbDragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData("FileDrop", false);
			foreach (string s in files)
			{
				//just filename
				string ext=s.Substring(1 + s.LastIndexOf(@"."));
                //lb.Items.Add(s.Substring(1 + s.LastIndexOf(@".")));
                if (ext == "pdf" || ext == "PDF")
                    if (!lb.Items.Contains((object)s))
                    {
                        lb.Items.Add(s);
                    }
			}
		}

		void LbDragEnter(object sender, DragEventArgs e)
		{
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
		}
		public void SignDetached() {
			if(lb.Items.Count>0) {
				try
				{
					X509Certificate2 card = GetCertificate();
					Org.BouncyCastle.X509.X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
					Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[]{cp.ReadCertificate(card.RawData)};
					pb.Minimum=0;
					pb.Maximum=lb.Items.Count;
					pb.Visible=true;

					foreach(object oFile in lb.Items) {
						string filePDF=oFile.ToString();
						PdfReader reader = new PdfReader(filePDF);
						int Pagina=1;
						int posX=0,posY=0,Altezza=0,Larghezza=0;
						//ricreo il percorso con il nome del nuovo file
						string file=filePDF.Substring(1 + filePDF.LastIndexOf(@"\"));
						string NuovoFile = filePDF.Substring(0, filePDF.LastIndexOf(@"\")+1)+file.Substring(0, file.LastIndexOf("."))+"_firmato.pdf";
						PdfStamper stp = PdfStamper.CreateSignature(reader, new FileStream(NuovoFile, FileMode.Create), '\0', null, multiSigChkBx.Checked);
						PdfSignatureAppearance sap = stp.SignatureAppearance;
						
						//string nPagine= (cbRagione.SelectedIndex==2) ? reader.NumberOfPages.ToString() : "";
						string nPagine= reader.NumberOfPages.ToString();
						sap.Reason = cbRagione.Text+nPagine;
						sap.Contact = tbContatto.Text;
						sap.Location = tbLuogo.Text;
						if(cbFirmaVisibile.Checked==true) { //firma visibile
							if(rbNuovaPagina.Checked) { //firma su nuova pagina
								Pagina=reader.NumberOfPages+1;
								stp.InsertPage(Pagina,reader.GetPageSize(1)); //new iTextSharp.text.Rectangle(600,800));
								iTextSharp.text.Rectangle rect = reader.GetPageSize(Pagina);
								int w=Convert.ToInt32(rect.Width);
								int h=Convert.ToInt32(rect.Height);
								posX=20;
								posY=h-120;
								Larghezza=posX+100;
								Altezza=posY+100;
							}
							else if(rbVecchiaPagina.Checked) { //firma su pagina esistente
								int IndiceScelto=lbPosizioneFirma.SelectedIndex;
								int paginaScelta = (IndiceScelto<=3) ? 1 : reader.NumberOfPages;
								iTextSharp.text.Rectangle rect = reader.GetPageSize(paginaScelta);
								int w=Convert.ToInt32(rect.Width);
								int h=Convert.ToInt32(rect.Height);
								//MessageBox.Show(paginaScelta.ToString());
								Pagina=paginaScelta;
								/* istruzioni:
								 *  0 Prima Pagina in Alto a Sinistra
								 *  1 Prima Pagina in Alto a Destra
								 *  2 Prima Pagina in Basso a Sinistra
								 *  3 Prima Pagina in Basso a Destra
								 *  4 Ultima Pagina in Alto a Sinistra
								 * 	5 Ultima Pagina in Alto a Destra
								 *  6 Ultima Pagina in Basso a Sinistra
								 *  7 Ultima Pagina in Basso a Destra
								 */
								switch(IndiceScelto) {
									case 0:
                                    default:
                                    case 4:
										posX=20;
										posY=h-110;
										Larghezza=posX+100;
										Altezza=posY+100;
										break;
									case 1:
									case 5:
										posX=w-110;
										posY=h-110;
										Larghezza=posX+100;
										Altezza=posY+100;
										break;
									case 2:
									case 6:
										posX=20;
										posY=20;
										Larghezza=posX+350;
										Altezza=posY+70;
										break;
									case 3:
									case 7:
										posX=w-110;
										posY=20;
										Larghezza=posX+100;
										Altezza=posY+100;
										break;
                                }
							}
							sap.SetVisibleSignature(new iTextSharp.text.Rectangle(posX, posY, Larghezza, Altezza), Pagina, null);
						}
						sap.SignDate = DateTime.Now;
						sap.SetCrypto(null, chain, null, null);
						
						sap.Acro6Layers = true;
						sap.Render = PdfSignatureAppearance.SignatureRender.Description; //.NameAndDescription;
						PdfSignature dic = new PdfSignature(PdfName.ADOBE_PPKLITE, PdfName.ADBE_PKCS7_DETACHED);
						dic.Date = new PdfDate(sap.SignDate);
						dic.Name = PdfPKCS7.GetSubjectFields(chain[0]).GetField("CN");
						sap.Layer2Text = "Firmato Digitalmente da: "+PdfPKCS7.GetSubjectFields(chain[0]).GetField("CN");
						sap.Layer2Text+="\r\nData: "+sap.SignDate;
						sap.Layer2Text+="\r\nRagione: "+sap.Reason;
						if (sap.Reason != null)
							dic.Reason = sap.Reason;
						if (sap.Location != null)
							dic.Location = sap.Location;
						if (sap.Contact != null)
							dic.Contact = sap.Contact;
						sap.CryptoDictionary = dic;
						int contentEstimated = 56000;
						Dictionary<PdfName, int> exc = new Dictionary<PdfName, int>();
						exc[PdfName.CONTENTS] = contentEstimated * 2 + 2;
						sap.PreClose(exc);
						
						Stream s = sap.GetRangeStream();
						MemoryStream ss = new MemoryStream();
						int read = 0;
						byte[] buff = new byte[8192];
						while ((read = s.Read(buff, 0, 8192)) > 0) {
							ss.Write(buff, 0, read);
						}
						byte[] pk;
						if(tsaCbx.Checked) { //ss.ToArray()
							pk = SignMsg(ss.ToArray(), card, true, tsaCbx.Checked, TSAUrlTextBox.Text, tsaLogin.Text, tsaPwd.Text);
						} else {
							pk = SignMsg(ss.ToArray(), card, true, false, "", "", "");
						}
						byte[] outc = new byte[contentEstimated];
						
						PdfDictionary dic2 = new PdfDictionary();

						Array.Copy(pk, 0, outc, 0, pk.Length);

						dic2.Put(PdfName.CONTENTS, new PdfString(outc).SetHexWriting(true));
						sap.Close(dic2);
						//avanzo di 1 la progress bar
						pb.Increment(1);
					}
					MessageBox.Show(pb.Maximum.ToString()+" file firmati correttamente","Operazione Completata");
					pb.Visible=false;
				}
				catch (Exception ex) {
					MessageBox.Show(ex.ToString(), "Messaggio dal Sistema Windows");
					pb.Visible=false;
				}
			}
		}
		//  Sign the message with the private key of the signer.
		static public byte[] SignMsg(Byte[] msg, X509Certificate2 signerCert, bool detached, bool UsaTSA, string TSAurl, string TSAuser, string TSApass)
		{
			try
			{
				SHA256Managed hashSha256 = new SHA256Managed();
				byte[] certHash = hashSha256.ComputeHash(signerCert.RawData);
				EssCertIDv2 essCert1 = new EssCertIDv2(new Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier("2.16.840.1.101.3.4.2.1"), certHash);
				SigningCertificateV2 scv2 = new SigningCertificateV2(new EssCertIDv2[] { essCert1 });
				Org.BouncyCastle.Asn1.Cms.Attribute CertHAttribute = new Org.BouncyCastle.Asn1.Cms.Attribute(Org.BouncyCastle.Asn1.Pkcs.PkcsObjectIdentifiers.IdAASigningCertificateV2, new DerSet(scv2));
				Asn1EncodableVector v = new Asn1EncodableVector();
				v.Add(CertHAttribute);
				Org.BouncyCastle.Asn1.Cms.AttributeTable AT = new Org.BouncyCastle.Asn1.Cms.AttributeTable(v);
				CmsSignedDataGenWithRsaCsp cms = new CmsSignedDataGenWithRsaCsp();
				var rsa = (RSACryptoServiceProvider)signerCert.PrivateKey;
				Org.BouncyCastle.X509.X509Certificate certCopy = DotNetUtilities.FromX509Certificate(signerCert);
				cms.MyAddSigner(rsa, certCopy, "1.2.840.113549.1.1.1", "2.16.840.1.101.3.4.2.1", AT, null);
				ArrayList certList = new ArrayList();
				certList.Add(certCopy);
				Org.BouncyCastle.X509.Store.X509CollectionStoreParameters PP = new Org.BouncyCastle.X509.Store.X509CollectionStoreParameters(certList);
				Org.BouncyCastle.X509.Store.IX509Store st1 = Org.BouncyCastle.X509.Store.X509StoreFactory.Create("CERTIFICATE/COLLECTION", PP);
				cms.AddCertificates(st1);
				CmsProcessableByteArray file = new CmsProcessableByteArray(msg); //CmsProcessableFile(File);
				CmsSignedData Firmato = cms.Generate(file, false); //se settato a true, il secondo argomento integra l'intero file
				
				byte[] bb = Firmato.GetEncoded();
				
				if(UsaTSA) {
					CmsSignedData sd = new CmsSignedData(bb);
					SignerInformationStore signers = sd.GetSignerInfos();
					byte[] signature = null;
					SignerInformation signer = null;
					foreach (SignerInformation signer_ in signers.GetSigners()) {
						signer = signer_;
						break;
					}
					
					signature = signer.GetSignature();
					Org.BouncyCastle.Asn1.Cms.AttributeTable at = new Org.BouncyCastle.Asn1.Cms.AttributeTable(GetTimestamp(signature,TSAurl,TSAuser,TSApass));
					signer = SignerInformation.ReplaceUnsignedAttributes(signer, at);
					IList signerInfos = new ArrayList();
					signerInfos.Add(signer);
					sd = CmsSignedData.ReplaceSigners(sd, new SignerInformationStore(signerInfos));
					bb = sd.GetEncoded();
				}
				return bb;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return null;
			}
			/****
			 * Le istruzioni che seguono non sono piu' utili da quando non si puo' piu' usare SHA1
			 * 
			 * cmsSigner.DigestAlgorithm = new Oid("2.16.840.1.101.3.4.2.1"); NON FUNZIONA!
			 * 
			//  Place message in a ContentInfo object.
			//  This is required to build a SignedCms object.
			ContentInfo contentInfo = new ContentInfo(msg);

			//  Instantiate SignedCms object with the ContentInfo above.
			//  Has default SubjectIdentifierType IssuerAndSerialNumber.
			SignedCms signedCms = new SignedCms(contentInfo, detached);

			//  Formulate a CmsSigner object for the signer.
			CmsSigner cmsSigner = new CmsSigner(signerCert);

			// Include the following line if the top certificate in the
			// smartcard is not in the trusted list.
			cmsSigner.IncludeOption = X509IncludeOption.EndCertOnly;
			
			//cmsSigner.DigestAlgorithm = new Oid("2.16.840.1.101.3.4.2.1"); //SHA256
			//cmsSigner.DigestAlgorithm = new Oid("2.16.840.1.101.3.4.2.1"); //SHA256
			//cmsSigner.DigestAlgorithm = new Oid("SHA256");
			//MessageBox.Show(cmsSigner.DigestAlgorithm.Value.ToString());
			//  Sign the CMS/PKCS #7 message. The second argument is
			//  needed to ask for the pin.
			signedCms.ComputeSignature(cmsSigner, false);
			//  Encode the CMS/PKCS #7 message.
			byte[] bb = signedCms.Encode();
			//return bb here if no timestamp is to be applied
			CmsSignedData sd = new CmsSignedData(bb);
			SignerInformationStore signers = sd.GetSignerInfos();
			byte[] signature = null;
			SignerInformation signer = null;
			foreach (SignerInformation signer_ in signers.GetSigners()) {
				signer = signer_;
				break;
			}
			
			signature = signer.GetSignature();
			if(UsaTSA) {
				Org.BouncyCastle.Asn1.Cms.AttributeTable at = new Org.BouncyCastle.Asn1.Cms.AttributeTable(GetTimestamp(signature,TSAurl,TSAuser,TSApass));
				signer = SignerInformation.ReplaceUnsignedAttributes(signer, at);
				IList signerInfos = new ArrayList();
				signerInfos.Add(signer);
				sd = CmsSignedData.ReplaceSigners(sd, new SignerInformationStore(signerInfos));
				bb = sd.GetEncoded();
				return bb;
			}
			//Encode the CMS/PKCS #7 message.
			return signedCms.Encode();*/
		}

		public static X509Certificate2 GetCertificate() {
			X509Store st = new X509Store(StoreName.My, StoreLocation.CurrentUser);
			st.Open(OpenFlags.ReadOnly);
			X509Certificate2Collection col = st.Certificates;
			X509Certificate2 card = null;
			X509Certificate2Collection sel = X509Certificate2UI.SelectFromCollection(col, "Certificati", "Seleziona il certificato", X509SelectionFlag.SingleSelection);
			if (sel.Count > 0) {
				X509Certificate2Enumerator en = sel.GetEnumerator();
				en.MoveNext();
				card = en.Current;
				
			}
			st.Close();
			return card;
		}

		public static Org.BouncyCastle.Asn1.Asn1EncodableVector GetTimestamp(byte[] signature,string url, string user, string pass) {
			
			byte[] tsImprint = PdfEncryption.DigestComputeHash("SHA256", signature);
			
			//ITSAClient tsc = new TSAClientBouncyCastle("http://10.0.0.245:8080/signserver/process?workerName=TimeStampSigner", null, null);
			//MessageBox.Show(url+" "+user+" "+pass);
			int size=6500;
			ITSAClient tsc = new TSAClientBouncyCastle(url, user, pass, size, "SHA256");
			//return tsc.GetTimeStampToken(null, tsImprint);
			String ID_TIME_STAMP_TOKEN = "1.2.840.113549.1.9.16.2.14"; // RFC 3161 id-aa-timeStampToken

			Asn1InputStream tempstream = new Asn1InputStream(new MemoryStream(tsc.GetTimeStampToken(tsImprint)));

			Asn1EncodableVector unauthAttributes = new Asn1EncodableVector();

			Asn1EncodableVector v = new Asn1EncodableVector();
			v.Add(new DerObjectIdentifier(ID_TIME_STAMP_TOKEN)); // id-aa-timeStampToken
			Asn1Sequence seq = (Asn1Sequence) tempstream.ReadObject();
			v.Add(new DerSet(seq));

			unauthAttributes.Add(new DerSequence(v));
			return unauthAttributes;
		}

		void Button1Click(object sender, EventArgs e)
		{
			SignDetached();
		}

		void Button2Click(object sender, System.EventArgs e)
		{
			if (ofd.ShowDialog()==DialogResult.OK) {
				string[] files = ofd.FileNames;
				foreach (string s in files)
				{
					//just filename
					string ext=s.Substring(1 + s.LastIndexOf(@"."));
                    //lb.Items.Add(s.Substring(1 + s.LastIndexOf(@".")));
                    if (ext == "pdf" || ext == "PDF")
                    {
                        if (!lb.Items.Contains((object)s))
                        {
                            lb.Items.Add(s);
                        }
                    }
				}
			}
		}

		void CbVisibileCheckedChanged(object sender, EventArgs e)
		{
			gbFirma.Visible = (gbFirma.Visible) ? false : true;
		}

		void RbVecchiaPaginaCheckedChanged(object sender, EventArgs e)
		{
			lbPosizioneFirma.Visible = (rbVecchiaPagina.Checked) ? true : false;
		}

		void EliminaToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(lb.SelectedItem!=null)
				lb.Items.Remove(lb.SelectedItem);
		}

        void LbKeyUp(object sender, KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Delete) {
                if (lb.SelectedItem != null)
                {
                    lb.Items.Remove(lb.SelectedItem);
                }
			}
		}

        void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			TopMost=(TopMost) ? false : true;
		}

		void ApriSingoloPDFClick(object sender, EventArgs e)
		{
			System.Windows.Forms.OpenFileDialog openFile;
			openFile = new System.Windows.Forms.OpenFileDialog();
			openFile.Filter = "PDF files *.pdf|*.pdf";
			openFile.Title = "Select a file";
            if (openFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }
			inputBox.Text = openFile.FileName;
            if (pagePreviewPanel.BackgroundImage != null)
            {
                pagePreviewPanel.BackgroundImage.Dispose();
            }
			
			try
			{
				reader = new PdfReader(inputBox.Text);

			}
			catch
			{
				PwdDialog dlg = new PwdDialog();
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					string pwd = (dlg.Controls["pwdTextBox"] as TextBox).Text;
					reader = new PdfReader(inputBox.Text, Tools.StrToByteArray(pwd));
				}
				else
				{
					inputBox.Text = "";
					return;
				}
			}
			MetaData md = new MetaData();
			md.Info = reader.Info;

			authorBox.Text = md.Author;
			titleBox.Text = md.Title;
			subjectBox.Text = md.Subject;
			kwBox.Text = md.Keywords;
			creatorBox.Text = md.Creator;
			prodBox.Text = md.Producer;
			string MULTIPLE_FILE_LOCATION  = TmpLocation+"\\output%d.jpg";
			if(!Directory.Exists(TmpLocation)) {
				Directory.CreateDirectory(TmpLocation);
			} else {
                int i = 1;
					while(File.Exists(TmpLocation+"\\output"+i+".jpg")) {
						try {
							File.Delete(TmpLocation+"\\output"+i+".jpg");
						} catch (Exception ex) {
							MessageBox.Show(ex.Message, "Errore nel cancellare i files temporanei");
						}
                        i++;
					}
				
			}
			try {
				GhostscriptWrapper.GeneratePageThumbs(openFile.FileName, MULTIPLE_FILE_LOCATION, 1, reader.NumberOfPages, 20, 20);
			} catch (Exception ex) {
				MessageBox.Show(ex.Message,"Errore nella generazione dell'anteprima");
			}
			//for (var i = 1; i <= reader.NumberOfPages; i++)
			//Assert.IsTrue(File.Exists(String.Format("output{0}.jpg", i)));

			numberOfPagesUpDown.Maximum = reader.NumberOfPages;
            numberOfPagesUpDown.Minimum = 1;
            numberOfPagesUpDown.Value = 1;
			numberOfPagesUpDown_ValueChanged(numberOfPagesUpDown, null);

			sigPicture.Left = 0;
			sigPicture.Top = sigPicture.Parent.Height - sigPicture.Height;
			sigPictureMove(sigPicture, null);
			
			sigPicture.Width = 50;
			sigPicture.Height = 20;
			sigPictureResize(sigPicture, null);
		}

		private void numberOfPagesUpDown_ValueChanged(object sender, EventArgs e)
		{
			//-----------------------------------------------
			//PdfReader reader = new PdfReader(inputBox.Text);
			//Document ddd = new Document();
			//PdfWriter writer = PdfWriter.GetInstance(ddd, new FileStream("ciao.pdf",FileMode.Create));
			//PdfImportedPage page = writer.GetImportedPage(reader, 1);
			//iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(page);
			//MessageBox.Show(image.ToString());
			//iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("c:\\temp\\test.png");

			//Bitmap bmp = new Bitmap((int)img.Width, (int)img.Height, PixelFormat.Format24bppRgb);
			//System.Drawing.Rectangle rect0 = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
			//BitmapData bmpdat = bmp.LockBits(rect0, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			//Marshal.Copy(img.RawData, 0, bmpdat.Scan0, img.RawData.Length);
			//bmp.UnlockBits(bmpdat);
			//bmp.Save("c:\\temp\\test2.png");
			/*pdfDoc = (Acrobat.CAcroPDDoc) Microsoft.VisualBasic.Interaction.CreateObject("AcroExch.PDDoc", "");
			pdfDoc.Open(inputBox.Text);
			pdfPage = (Acrobat.CAcroPDPage)pdfDoc.AcquirePage(Convert.ToInt32(numberOfPagesUpDown.Value)-1);
			pdfPoint = (Acrobat.CAcroPoint)pdfPage.GetSize();
			pdfRect = (Acrobat.CAcroRect) Microsoft.VisualBasic.Interaction.CreateObject("AcroExch.Rect", "");

			pdfRect.Left = 0;
			pdfRect.right = pdfPoint.x;
			pdfRect.Top = 0;
			pdfRect.bottom = pdfPoint.y;
			pdfPage.CopyToClipboard(pdfRect, 0, 0, 100);
			 */
			//IDataObject clipboardData = Clipboard.GetDataObject();
			
			//if (clipboardData.GetDataPresent(DataFormats.Bitmap))
			//{
			//Bitmap pdfBitmap = (Bitmap)clipboardData.GetData(DataFormats.Bitmap);
			
			//pdfDoc.Close();
			//Marshal.ReleaseComObject(pdfPage);
			//Marshal.ReleaseComObject(pdfRect);
			//Marshal.ReleaseComObject(pdfDoc);
			
			//-----------------------------------------------
			iTextSharp.text.Rectangle rect = reader.GetPageSize(Convert.ToInt32(numberOfPagesUpDown.Value));

			pagePreviewPanel.Top = 0;

			if (rect.Width > rect.Height)
			{
				pagePreviewPanel.Width = pagePreviewPanel.Parent.Width;
				pagePreviewPanel.Height = Convert.ToInt32((pagePreviewPanel.Width * rect.Height) / rect.Width);
			}
			else
			{
				pagePreviewPanel.Height = pagePreviewPanel.Parent.Height;
				pagePreviewPanel.Width = Convert.ToInt32((pagePreviewPanel.Height * rect.Width) / rect.Height);
			}
			pagePreviewPanel.Left = (pagePreviewPanel.Parent.Width - pagePreviewPanel.Width) / 2;
			pagePreviewPanel.Top = (pagePreviewPanel.Parent.Height - pagePreviewPanel.Height) / 2;
			
			//System.Drawing.Image pdfImage = pdfBitmap.GetThumbnailImage(pagePreviewPanel.Width, pagePreviewPanel.Height,null, IntPtr.Zero);
			if(File.Exists(TmpLocation+"\\output"+numberOfPagesUpDown.Value.ToString()+".jpg")) {
				pagePreviewPanel.BackgroundImage=System.Drawing.Image.FromFile(TmpLocation+"\\output"+numberOfPagesUpDown.Value.ToString()+".jpg");
			}
			sigPosX.Maximum = Convert.ToInt32(rect.Width);
			sigPosY.Maximum = Convert.ToInt32(rect.Height);

			sigWidth.Maximum = Convert.ToInt32(rect.Width);
			sigHeight.Maximum = Convert.ToInt32(rect.Height);
			//}
		}

		private void sigPictureMove(object sender, EventArgs e)
		{
			iTextSharp.text.Rectangle rect = reader.GetPageSize(Convert.ToInt32(numberOfPagesUpDown.Value));
			decimal X = Convert.ToInt32( (rect.Width * sigPicture.Left) / pagePreviewPanel.Width );

			decimal Y = sigPicture.Parent.Height - sigPicture.Top - sigPicture.Height;
			Y =  Convert.ToInt32( (rect.Height * (float)Y) / pagePreviewPanel.Height );

            if (X > sigPosX.Maximum) { X = sigPosX.Maximum; }
			if (X < sigPosX.Minimum) { X = sigPosX.Minimum; }
            if (Y > sigPosY.Maximum) { Y = sigPosY.Maximum; }
            if (Y < sigPosY.Minimum) { Y = sigPosY.Minimum; }

            sigPosX.Value = X;
			sigPosY.Value = Y;
		}

		private void clearBtn_Click(object sender, EventArgs e)
		{
            sigPicture.Image = null;
            sigImgBox.Image = null;
		}

		private void browseBtn_Click(object sender, EventArgs e)
		{
			System.Windows.Forms.OpenFileDialog openFile;
			openFile = new System.Windows.Forms.OpenFileDialog();
			openFile.Filter = "File jpeg (*.jpg) |*.jpg| File gif (*.gif) |*.gif| File bmp (*.bmp)|*.bmp| File png (*.png)| *.png";
			openFile.Title = "Select a file";
			if (openFile.ShowDialog() != DialogResult.OK)
				return;

			sigPicture.Image = sigImgBox.Image = new Bitmap(openFile.FileName);
		}

		private void sigPictureResize(object sender, EventArgs e)
		{
			iTextSharp.text.Rectangle rect = reader.GetPageSize(Convert.ToInt32(numberOfPagesUpDown.Value));
			decimal W = Convert.ToInt32((rect.Width * sigPicture.Width) / pagePreviewPanel.Width);
			decimal H = Convert.ToInt32((rect.Height * sigPicture.Height) / pagePreviewPanel.Height);
			
			if (W > sigWidth.Maximum) W = sigWidth.Maximum;
			if (W < sigWidth.Minimum) W = sigWidth.Minimum;
			if (H > sigHeight.Maximum) H = sigHeight.Maximum;
			if (H < sigHeight.Minimum) H = sigHeight.Minimum;

			sigWidth.Value = W;
			sigHeight.Value = H;
		}

		void SigVisibleCheckedChanged(object sender, EventArgs e)
		{
			sigPanel1.Visible = sigPanel2.Visible = sigPanel1.Enabled = sigPanel2.Enabled = SigVisible.Checked;
		}

		private void tsaCbx_CheckedChanged(object sender, EventArgs e)
		{
			TSAUrlTextBox.Enabled = (sender as CheckBox).Checked;
			tsaLogin.Enabled = (sender as CheckBox).Checked;
			tsaPwd.Enabled = (sender as CheckBox).Checked;
			TSALbl1.Enabled = (sender as CheckBox).Checked;
			TSALbl2.Enabled = (sender as CheckBox).Checked;
			TSALbl3.Enabled = (sender as CheckBox).Checked;
		}

		public void Button3Click(object sender, System.EventArgs e)
		{
			if(inputBox.Text!=null) {
				string filePDF=inputBox.Text;
				try
				{
					X509Certificate2 card = GetCertificate();
					Org.BouncyCastle.X509.X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
					Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[]{cp.ReadCertificate(card.RawData)};
					
					//ricreo il percorso con il nome del novo file
					
					string file=filePDF.Substring(1 + filePDF.LastIndexOf(@"\"));
					string NuovoFile = filePDF.Substring(0, filePDF.LastIndexOf(@"\")+1)+file.Substring(0, file.LastIndexOf("."))+"_firmato.pdf";
					PdfReader reader = new PdfReader(filePDF);
					//------------------------------
					/*if(cbPDFA.Checked) {
						filePDF=SignLocation+"\\"+file;
						Document doc = new Document(reader.GetPageSize(1));
						PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(SignLocation+"\\"+file, FileMode.Create));
						writer.PDFXConformance = PdfWriter.PDFA1B;
						doc.Open();
						PdfDictionary outi = new PdfDictionary(PdfName.OUTPUTINTENT);
						outi.Put(PdfName.OUTPUTCONDITIONIDENTIFIER, new PdfString("sRGB IEC61966-2.1"));
						outi.Put(PdfName.INFO, new PdfString("sRGB IEC61966-2.1"));
						outi.Put(PdfName.S, PdfName.GTS_PDFA1);
						if(!File.Exists(SignLocation+"\\srgb.profile")) {
							MessageBox.Show("Manca il profilo SRGB nella cartella "+SignLocation);
							return;
						}
						ICC_Profile icc = ICC_Profile.GetInstance(SignLocation+"\\srgb.profile");
						PdfICCBased ib = new PdfICCBased(icc);
						ib.Remove(PdfName.ALTERNATE);
						outi.Put(PdfName.DESTOUTPUTPROFILE, writer.AddToBody(ib).IndirectReference);
						writer.ExtraCatalog.Put(PdfName.OUTPUTINTENTS, new PdfArray(outi));
						BaseFont bf = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.WINANSI, true);
						Font f = new Font(bf, 12);
						doc.Add(new Paragraph("hello", f));
						writer.CreateXmpMetadata();
						doc.Close();
						
					}
					 */
					//-------------------------------
					//MessageBox.Show(file+" + "+NuovoFile);
					
					PdfStamper stp = PdfStamper.CreateSignature(reader, new FileStream(NuovoFile, FileMode.Create), '\0', null, multiSigChkBx.Checked);
					PdfSignatureAppearance sap = stp.SignatureAppearance;
					
					if(tsaCbx.Checked) {
						ITSAClient tsc = new TSAClientBouncyCastle(TSAUrlTextBox.Text, tsaLogin.Text, tsaPwd.Text);
					}
					
					if(SigVisible.Checked) {
						sap.Reason = cbRagioneSingolo.Text;
						sap.Contact = Contacttext.Text;
						sap.Location = Locationtext.Text;
						
						if (sigImgBox.Image != null) {
							MemoryStream ms = new MemoryStream();
							sigImgBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
							sap.Image = ms.ToArray() == null ? null : iTextSharp.text.Image.GetInstance(ms.ToArray());
							ms.Close();
						}
						sap.SetVisibleSignature(new iTextSharp.text.Rectangle((float)sigPosX.Value,
						                                                      (float)sigPosY.Value,
						                                                      (float)sigPosX.Value+(float)sigWidth.Value,
						                                                      (float)sigPosY.Value+(float)sigHeight.Value),
						                        Convert.ToInt32(numberOfPagesUpDown.Value),
						                        null);
					}
					/*if(custSigText.!=null) {
						sap.Layer2Text = custSigText.Text;
					}*/
					
					sap.SignDate = DateTime.Now;
					sap.SetCrypto(null, chain, null, null);
					
					sap.Acro6Layers = true;
					sap.Render = PdfSignatureAppearance.SignatureRender.Description; //.NameAndDescription;
					PdfSignature dic = new PdfSignature(PdfName.ADOBE_PPKLITE, PdfName.ADBE_PKCS7_DETACHED);
					dic.Date = new PdfDate(sap.SignDate);
					dic.Name = PdfPKCS7.GetSubjectFields(chain[0]).GetField("CN");
					
					if (sap.Reason != null)
						dic.Reason = sap.Reason;
					if (sap.Location != null)
						dic.Location = sap.Location;
					if (sap.Contact != null)
						dic.Contact = sap.Contact;
					sap.CryptoDictionary = dic;
					int contentEstimated = 15000;
					Dictionary<PdfName, int> exc = new Dictionary<PdfName, int>();
					exc[PdfName.CONTENTS] = contentEstimated * 2 + 2;
					sap.PreClose(exc);
					IDigest messageDigest = DigestUtilities.GetDigest("SHA256"); //add
					Stream s = sap.GetRangeStream();
					MemoryStream ss = new MemoryStream();
					int read = 0;
					byte[] buff = new byte[8192];
					while ((read = s.Read(buff, 0, 8192)) > 0) {
						ss.Write(buff, 0, read);
						messageDigest.BlockUpdate(buff, 0, read); //add
					}
					//--------------------------------------------
					byte[] hash = new byte[messageDigest.GetDigestSize()];
					messageDigest.DoFinal(hash, 0);
					DateTime cal = DateTime.Now;
					byte[] ocsp = null;
					if (chain.Length >= 2) {
						String url = PdfPKCS7.GetOCSPURL(chain[0]);
						if (url != null && url.Length > 0) {
							ocsp =  new OcspClientBouncyCastle().GetEncoded(chain[0], chain[1], url);
							MessageBox.Show(ocsp.ToString());
						}
					}
					
					//-------------------------------------------------------------------
					//TEST TIMESTAMP CON BOUNCYCASTLE
					//-------------------------------------------------------------------
					/*
					TimeStampRequestGenerator reqGen = new TimeStampRequestGenerator();
					// Dummy request
					TimeStampRequest request = reqGen.Generate(TspAlgorithms.Sha1, hash, BigInteger.ValueOf(100));
					byte[] reqData = request.GetEncoded();
					HttpWebRequest httpReq = (HttpWebRequest) WebRequest.Create("http://localhost:8080/signserver/process?workerId=1");
					httpReq.Method = "POST";
					httpReq.ContentType = "application/timestamp-query";
					httpReq.ContentLength = reqData.Length;
					// Write the request content
					Stream reqStream = httpReq.GetRequestStream();
					reqStream.Write(reqData, 0, reqData.Length);
					reqStream.Close();
					HttpWebResponse httpResp = (HttpWebResponse) httpReq.GetResponse();
					// Read the response
					Stream respStream = new BufferedStream(httpResp.GetResponseStream());
					TimeStampResponse response = new TimeStampResponse(respStream);
					respStream.Close();
					//MessageBox.Show(response.TimeStampToken.TimeStampInfo.GenTime.ToString());
					 */
					//-------------------------------------------------------------------
					//TEST TIMESTAMP CON BOUNCYCASTLE
					//-------------------------------------------------------------------
					
					//byte[] test = PdfPKCS7.GetAuthenticatedAttributeBytes(hash, cal, ocsp);
					//===================================QUI FIRMO
					byte[] pk;
					if(tsaCbx.Checked) {
						pk = SignMsg(ss.ToArray(), card, true, tsaCbx.Checked, TSAUrlTextBox.Text, tsaLogin.Text, tsaPwd.Text);
					} else {
						pk = SignMsg(ss.ToArray(), card, true, tsaCbx.Checked, "", "", "");
					}
					//--------------------------------------------
					byte[] outc = new byte[contentEstimated];

					PdfDictionary dic2 = new PdfDictionary();

					Array.Copy(pk, 0, outc, 0, pk.Length);

					dic2.Put(PdfName.CONTENTS, new PdfString(outc).SetHexWriting(true));
					sap.Close(dic2);
					MessageBox.Show("File firmato correttamente","Operazione Completata");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
		}

		void Button4Click(object sender, EventArgs e)
		{
			if(!tsaCbx.Checked || TSAUrlTextBox.Text=="") {
				MessageBox.Show("Marca temporale non selezionata, oppure server non definito");
				return;
			}
			
			string TSA_URL    = TSAUrlTextBox.Text;
			string TSA_ACCNT  = tsaLogin.Text;
			string TSA_PASSW  = tsaPwd.Text;
			if (fbd.ShowDialog()==DialogResult.OK) {
				string foldername=fbd.SelectedPath;
				string[] files = Directory.GetFiles(foldername,"*.pdf");
				pb.Minimum=0;
				pb.Maximum=files.Length;
				pb.Visible=true;
				lb2.Items.Clear();
				foreach (string s in files)
				{
					//just filename
					try {
						string ext=s.Substring(1 + s.LastIndexOf(@"."));
						//lb.Items.Add(s.Substring(1 + s.LastIndexOf(@".")));
						if(ext=="pdf" || ext=="PDF") {
							//ricreo il percorso con il nome del nuovo file
							string file=s.Substring(1 + s.LastIndexOf(@"\"));
							string NuovoFile = s.Substring(0, s.LastIndexOf(@"\")+1)+file.Substring(0, file.LastIndexOf("."))+"_validato_"+DateTime.Now.ToFileTime()+".pdf";
							//MessageBox.Show(NuovoFile);
							PdfReader r = new PdfReader(s);
							FileStream fout = new FileStream(NuovoFile, FileMode.Create);
							PdfStamper stp = PdfStamper.CreateSignature(r, fout, '\0', null, true);
							LtvVerification v = stp.LtvVerification;
							AcroFields af = stp.AcroFields;
							foreach (string sigName in af.GetSignatureNames()) {
								v.AddVerification(sigName, new OcspClientBouncyCastle(), new CrlClientImp(), LtvVerification.CertificateOption.WHOLE_CHAIN, LtvVerification.Level.OCSP_CRL, LtvVerification.CertificateInclusion.NO);
							}
							PdfSignatureAppearance sap = stp.SignatureAppearance;
							TSAClientBouncyCastle tsa = new TSAClientBouncyCastle(TSA_URL, TSA_ACCNT, TSA_PASSW, 6500, "sha256");
							LtvTimestamp.Timestamp(sap, tsa, null);
							lb2.Items.Add(NuovoFile);
							lb2.Refresh();
							pb.Increment(1);
						}
					}
					catch (Exception ex) {
						MessageBox.Show(ex.ToString());
						pb.Visible=false;
						return;
					}
				}
				MessageBox.Show(pb.Maximum.ToString()+" file firmati correttamente","Operazione Completata");
				pb.Visible=false;
			}
		}

		void Button5Click(object sender, EventArgs e)
		{
			if (ofd3.ShowDialog()==DialogResult.OK) {
				string[] files = ofd3.FileNames;
				foreach (string s in files)
				{
					if(!lbp7m.Items.Contains((object)s))
						lbp7m.Items.Add(s);
				}
			}
		}

		void Lbp7mDragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData("FileDrop", false);
			foreach (string s in files)
			{
				if(!lbp7m.Items.Contains((object)s))
					lbp7m.Items.Add(s);
			}
		}

		void Lbp7mDragEnter(object sender, DragEventArgs e)
		{
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
		}

		public byte[] FirmaFileBouncy(string NomeFile, X509Certificate2 cert, bool GiaFirmato, bool UsaTSA, string TSAurl, string TSAuser, string TSApass, out string RisFirma)
		{
			try
			{

				SHA256Managed hashSha256 = new SHA256Managed();
				byte[] certHash = hashSha256.ComputeHash(cert.RawData);
				EssCertIDv2 essCert1 = new EssCertIDv2(new Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier("2.16.840.1.101.3.4.2.1"), certHash);
				SigningCertificateV2 scv2 = new SigningCertificateV2(new EssCertIDv2[] { essCert1 });
				Org.BouncyCastle.Asn1.Cms.Attribute CertHAttribute = new Org.BouncyCastle.Asn1.Cms.Attribute(Org.BouncyCastle.Asn1.Pkcs.PkcsObjectIdentifiers.IdAASigningCertificateV2, new DerSet(scv2));
				Asn1EncodableVector v = new Asn1EncodableVector();
				v.Add(CertHAttribute);
				Org.BouncyCastle.Asn1.Cms.AttributeTable AT = new Org.BouncyCastle.Asn1.Cms.AttributeTable(v);
				CmsSignedDataGenWithRsaCsp cms = new CmsSignedDataGenWithRsaCsp();
				var rsa = (RSACryptoServiceProvider)cert.PrivateKey;
				Org.BouncyCastle.X509.X509Certificate certCopy = DotNetUtilities.FromX509Certificate(cert);
				cms.MyAddSigner(rsa, certCopy, "1.2.840.113549.1.1.1", "2.16.840.1.101.3.4.2.1", AT, null);
				ArrayList certList = new ArrayList();
				certList.Add(certCopy);
				Org.BouncyCastle.X509.Store.X509CollectionStoreParameters PP = new Org.BouncyCastle.X509.Store.X509CollectionStoreParameters(certList);
				Org.BouncyCastle.X509.Store.IX509Store st1 = Org.BouncyCastle.X509.Store.X509StoreFactory.Create("CERTIFICATE/COLLECTION", PP);
				cms.AddCertificates(st1);
				//mi ricavo il file da firmare
				FileInfo FileDaAprire = new FileInfo(NomeFile);
				/*CmsSignedData Firmato;
				if (GiaFirmato) {
					CmsSignedData signedData = new CmsSignedData(File.ReadAllBytes(NomeFile));
					if (signedData!=null){
						SignerInformationStore signers = signedData.GetSignerInfos();
						certList.Add(signers.GetSigners());
						//MessageBox.Show(signedData.ContentInfo.GetEncoded().Length.ToString());
						//signedData.ContentInfo.GetEncoded();
					}
					certList.Insert(0,certCopy);
					CmsProcessableByteArray file = new CmsProcessableByteArray(signedData.ContentInfo.GetEncoded());
					Firmato = cms.Generate(file, true);
				} else {
					certList.Add(certCopy);
					CmsProcessableFile file = new CmsProcessableFile(FileDaAprire);
					Firmato = cms.Generate(file, true);
				}
				*/
				CmsProcessableFile file = new CmsProcessableFile(FileDaAprire);
				CmsSignedData Firmato = cms.Generate(file, true);
				byte[] Encoded = Firmato.GetEncoded();
				
				if(UsaTSA) {
					CmsSignedData sd = new CmsSignedData(Encoded);
					SignerInformationStore signers = sd.GetSignerInfos();
					byte[] signature = null;
					SignerInformation signer = null;
					foreach (SignerInformation signer_ in signers.GetSigners()) {
						signer = signer_;
						break;
					}
					
					signature = signer.GetSignature();
					Org.BouncyCastle.Asn1.Cms.AttributeTable at = new Org.BouncyCastle.Asn1.Cms.AttributeTable(GetTimestamp(signature,TSAurl,TSAuser,TSApass));
					signer = SignerInformation.ReplaceUnsignedAttributes(signer, at);
					IList signerInfos = new ArrayList();
					signerInfos.Add(signer);
					sd = CmsSignedData.ReplaceSigners(sd, new SignerInformationStore(signerInfos));
					Encoded = sd.GetEncoded();
				}
				RisFirma = "";
				return Encoded;
			}
			catch (Exception ex)
			{
				RisFirma = ex.ToString();
				return null;
			}
		}

		void Button6Click(object sender, EventArgs e)
		{
			try
			{
				//mi seleziono il certificato
				X509Store st = new X509Store(StoreName.My, StoreLocation.CurrentUser);
				st.Open(OpenFlags.ReadOnly);
				X509Certificate2Collection col = st.Certificates;
				X509Certificate2 card = null;
				X509Certificate2Collection sel = System.Security.Cryptography.X509Certificates.X509Certificate2UI.SelectFromCollection(col, "Certificates", "Select one to sign", X509SelectionFlag.SingleSelection);
				if (sel.Count > 0)
				{
					X509Certificate2Enumerator en = sel.GetEnumerator();
					en.MoveNext();
					card = en.Current;
				}
				st.Close();
				MessageBox.Show(card.ToString());
				if (card != null)
				{
					pb.Minimum=0;
					pb.Maximum=lbp7m.Items.Count;
					pb.Visible=true;
					foreach(object oFile in lbp7m.Items)
					{
						string Res = "";
						byte[] Firmato = FirmaFileBouncy(oFile.ToString(), card, false, tsaCbx.Checked, TSAUrlTextBox.Text, tsaLogin.Text, tsaPwd.Text, out Res);
						//MessageBox.Show(Firmato.ToString());
						if (string.IsNullOrEmpty(Res))
						{
							File.WriteAllBytes(oFile.ToString() + ".p7m", Firmato);
							pb.Increment(1);
						}
						else
						{
							throw new Exception(Res);
						}
					}
					lbp7m.Items.Clear();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			MessageBox.Show(pb.Maximum.ToString()+" file firmati correttamente","Operazione Completata");
			pb.Visible=false;
		}

		void Lbp7mKeyUp(object sender, KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Delete) {
				if(lbp7m.SelectedItem!=null)
					lbp7m.Items.Remove(lbp7m.SelectedItem);
			}
		}
	}
}