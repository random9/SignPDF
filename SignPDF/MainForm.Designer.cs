/*
 * Creato da SharpDevelop.
 * Utente: glauco
 * Data: 05/01/2011
 * Ora: 16.23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SignPDF
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.lb = new System.Windows.Forms.ListBox();
			this.cm1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.eliminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.cbFirmaVisibile = new System.Windows.Forms.CheckBox();
			this.tt = new System.Windows.Forms.ToolTip(this.components);
			this.gbFirma = new System.Windows.Forms.GroupBox();
			this.cbRagione = new System.Windows.Forms.ComboBox();
			this.lbPosizioneFirma = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbContatto = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbLuogo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.rbVecchiaPagina = new System.Windows.Forms.RadioButton();
			this.rbNuovaPagina = new System.Windows.Forms.RadioButton();
			this.pb = new System.Windows.Forms.ProgressBar();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.prodBox = new System.Windows.Forms.TextBox();
			this.creatorBox = new System.Windows.Forms.TextBox();
			this.kwBox = new System.Windows.Forms.TextBox();
			this.subjectBox = new System.Windows.Forms.TextBox();
			this.titleBox = new System.Windows.Forms.TextBox();
			this.authorBox = new System.Windows.Forms.TextBox();
			this.inputBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.ApriSingoloPDF = new System.Windows.Forms.Button();
			this.sigPanel = new System.Windows.Forms.Panel();
			this.cbPDFA = new System.Windows.Forms.CheckBox();
			this.cbRagioneSingolo = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.Contacttext = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.Locationtext = new System.Windows.Forms.TextBox();
			this.sigPanel2 = new System.Windows.Forms.Panel();
			this.clearBtn = new System.Windows.Forms.Button();
			this.sigImgBox = new System.Windows.Forms.PictureBox();
			this.browseBtn = new System.Windows.Forms.Button();
			this.label27 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.sigPanel1 = new System.Windows.Forms.Panel();
			this.label33 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.sigHeight = new System.Windows.Forms.NumericUpDown();
			this.sigWidth = new System.Windows.Forms.NumericUpDown();
			this.label30 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.sigPosY = new System.Windows.Forms.NumericUpDown();
			this.sigPosX = new System.Windows.Forms.NumericUpDown();
			this.previewPanel = new System.Windows.Forms.Panel();
			this.pagePreviewPanel = new System.Windows.Forms.Panel();
			this.sigPicture = new System.Windows.Forms.PictureBox();
			this.label28 = new System.Windows.Forms.Label();
			this.numberOfPagesUpDown = new System.Windows.Forms.NumericUpDown();
			this.SigVisible = new System.Windows.Forms.CheckBox();
			this.multiSigChkBx = new System.Windows.Forms.CheckBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.TSALbl3 = new System.Windows.Forms.Label();
			this.TSALbl2 = new System.Windows.Forms.Label();
			this.tsaLogin = new System.Windows.Forms.TextBox();
			this.tsaPwd = new System.Windows.Forms.TextBox();
			this.TSALbl1 = new System.Windows.Forms.Label();
			this.TSAUrlTextBox = new System.Windows.Forms.TextBox();
			this.tsaCbx = new System.Windows.Forms.CheckBox();
			this.ofd2 = new System.Windows.Forms.OpenFileDialog();
			this.cm1.SuspendLayout();
			this.gbFirma.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.sigPanel.SuspendLayout();
			this.sigPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sigImgBox)).BeginInit();
			this.sigPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sigHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sigWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sigPosY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sigPosX)).BeginInit();
			this.previewPanel.SuspendLayout();
			this.pagePreviewPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sigPicture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numberOfPagesUpDown)).BeginInit();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// lb
			// 
			this.lb.AllowDrop = true;
			this.lb.ContextMenuStrip = this.cm1;
			this.lb.FormattingEnabled = true;
			this.lb.Location = new System.Drawing.Point(159, 10);
			this.lb.Name = "lb";
			this.lb.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lb.Size = new System.Drawing.Size(598, 251);
			this.lb.TabIndex = 0;
			this.lb.DragDrop += new System.Windows.Forms.DragEventHandler(this.LbDragDrop);
			this.lb.DragEnter += new System.Windows.Forms.DragEventHandler(this.LbDragEnter);
			this.lb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LbKeyUp);
			// 
			// cm1
			// 
			this.cm1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.eliminaToolStripMenuItem});
			this.cm1.Name = "contextMenuStrip1";
			this.cm1.Size = new System.Drawing.Size(153, 26);
			// 
			// eliminaToolStripMenuItem
			// 
			this.eliminaToolStripMenuItem.Name = "eliminaToolStripMenuItem";
			this.eliminaToolStripMenuItem.ShortcutKeyDisplayString = "CANC";
			this.eliminaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.eliminaToolStripMenuItem.Text = "Elimina";
			this.eliminaToolStripMenuItem.Click += new System.EventHandler(this.EliminaToolStripMenuItemClick);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(6, 194);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(143, 37);
			this.button1.TabIndex = 1;
			this.button1.Text = "Firma";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(4, 6);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(143, 40);
			this.button2.TabIndex = 2;
			this.button2.Text = "CARICA PDF";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// ofd
			// 
			this.ofd.Filter = "File PDF (*.pdf)|*.pdf";
			this.ofd.Multiselect = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 93);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(123, 53);
			this.label1.TabIndex = 3;
			this.label1.Text = "Carica o trascina nello spazio a fianco i file pdf che vuoi firmare";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbFirmaVisibile
			// 
			this.cbFirmaVisibile.Checked = true;
			this.cbFirmaVisibile.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbFirmaVisibile.Location = new System.Drawing.Point(6, 237);
			this.cbFirmaVisibile.Name = "cbFirmaVisibile";
			this.cbFirmaVisibile.Size = new System.Drawing.Size(104, 24);
			this.cbFirmaVisibile.TabIndex = 4;
			this.cbFirmaVisibile.Text = "Firma visibile";
			this.cbFirmaVisibile.UseVisualStyleBackColor = true;
			this.cbFirmaVisibile.CheckedChanged += new System.EventHandler(this.CbVisibileCheckedChanged);
			// 
			// gbFirma
			// 
			this.gbFirma.Controls.Add(this.cbRagione);
			this.gbFirma.Controls.Add(this.lbPosizioneFirma);
			this.gbFirma.Controls.Add(this.label2);
			this.gbFirma.Controls.Add(this.tbContatto);
			this.gbFirma.Controls.Add(this.label3);
			this.gbFirma.Controls.Add(this.tbLuogo);
			this.gbFirma.Controls.Add(this.label4);
			this.gbFirma.Controls.Add(this.rbVecchiaPagina);
			this.gbFirma.Controls.Add(this.rbNuovaPagina);
			this.gbFirma.Location = new System.Drawing.Point(6, 269);
			this.gbFirma.Name = "gbFirma";
			this.gbFirma.Size = new System.Drawing.Size(751, 169);
			this.gbFirma.TabIndex = 6;
			this.gbFirma.TabStop = false;
			this.gbFirma.Text = "Firma visibile";
			// 
			// cbRagione
			// 
			this.cbRagione.FormattingEnabled = true;
			this.cbRagione.Items.AddRange(new object[] {
									"Certifico la conformità all\'originale del presente documento che consiste di pagi" +
												"ne ",
									"Sottoscrivo quanto contenuto",
									"Si rilascia per gli usi consentiti"});
			this.cbRagione.Location = new System.Drawing.Point(68, 23);
			this.cbRagione.Name = "cbRagione";
			this.cbRagione.Size = new System.Drawing.Size(338, 21);
			this.cbRagione.TabIndex = 42;
			this.cbRagione.Text = "Certifico la conformità all\'originale del presente documento che consiste di pagi" +
			"ne ";
			// 
			// lbPosizioneFirma
			// 
			this.lbPosizioneFirma.FormattingEnabled = true;
			this.lbPosizioneFirma.Items.AddRange(new object[] {
									"Prima Pagina in Alto a Sinistra",
									"Prima Pagina in Alto a Destra",
									"Prima Pagina in Basso a Sinistra",
									"Prima Pagina in Basso a Destra",
									"Ultima Pagina in Alto a Sinistra",
									"Ultima Pagina in Alto a Destra",
									"Ultima Pagina in Basso a Sinistra",
									"Ultima Pagina in Basso a Destra"});
			this.lbPosizioneFirma.Location = new System.Drawing.Point(542, 55);
			this.lbPosizioneFirma.Name = "lbPosizioneFirma";
			this.lbPosizioneFirma.Size = new System.Drawing.Size(203, 108);
			this.lbPosizioneFirma.TabIndex = 41;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 35;
			this.label2.Text = "Ragione";
			// 
			// tbContatto
			// 
			this.tbContatto.Location = new System.Drawing.Point(68, 83);
			this.tbContatto.Name = "tbContatto";
			this.tbContatto.Size = new System.Drawing.Size(338, 20);
			this.tbContatto.TabIndex = 36;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 13);
			this.label3.TabIndex = 37;
			this.label3.Text = "Contatto";
			// 
			// tbLuogo
			// 
			this.tbLuogo.Location = new System.Drawing.Point(68, 138);
			this.tbLuogo.Name = "tbLuogo";
			this.tbLuogo.Size = new System.Drawing.Size(338, 20);
			this.tbLuogo.TabIndex = 38;
			this.tbLuogo.Text = "Preganziol";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(25, 141);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 13);
			this.label4.TabIndex = 39;
			this.label4.Text = "Luogo";
			// 
			// rbVecchiaPagina
			// 
			this.rbVecchiaPagina.Checked = true;
			this.rbVecchiaPagina.Location = new System.Drawing.Point(542, 13);
			this.rbVecchiaPagina.Name = "rbVecchiaPagina";
			this.rbVecchiaPagina.Size = new System.Drawing.Size(163, 40);
			this.rbVecchiaPagina.TabIndex = 1;
			this.rbVecchiaPagina.TabStop = true;
			this.rbVecchiaPagina.Text = "Inserisci la firma in una pagina esistente";
			this.rbVecchiaPagina.UseVisualStyleBackColor = true;
			this.rbVecchiaPagina.CheckedChanged += new System.EventHandler(this.RbVecchiaPaginaCheckedChanged);
			// 
			// rbNuovaPagina
			// 
			this.rbNuovaPagina.Location = new System.Drawing.Point(412, 16);
			this.rbNuovaPagina.Name = "rbNuovaPagina";
			this.rbNuovaPagina.Size = new System.Drawing.Size(124, 35);
			this.rbNuovaPagina.TabIndex = 0;
			this.rbNuovaPagina.Text = "Crea una nuova pagina per la firma";
			this.rbNuovaPagina.UseVisualStyleBackColor = true;
			// 
			// pb
			// 
			this.pb.Location = new System.Drawing.Point(4, 607);
			this.pb.Name = "pb";
			this.pb.Size = new System.Drawing.Size(767, 23);
			this.pb.TabIndex = 8;
			this.pb.Visible = false;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(629, 1);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(139, 24);
			this.checkBox1.TabIndex = 9;
			this.checkBox1.Text = "Sempre in primo piano";
			this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(4, 5);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(771, 462);
			this.tabControl1.TabIndex = 10;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.button2);
			this.tabPage2.Controls.Add(this.button1);
			this.tabPage2.Controls.Add(this.lb);
			this.tabPage2.Controls.Add(this.gbFirma);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this.cbFirmaVisibile);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(763, 436);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "PDF Multi";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.inputBox);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.ApriSingoloPDF);
			this.tabPage1.Controls.Add(this.sigPanel);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(763, 436);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "PDF Singolo";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button3.Location = new System.Drawing.Point(671, 3);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(88, 35);
			this.button3.TabIndex = 60;
			this.button3.Text = "FIRMA";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.prodBox);
			this.groupBox1.Controls.Add(this.creatorBox);
			this.groupBox1.Controls.Add(this.kwBox);
			this.groupBox1.Controls.Add(this.subjectBox);
			this.groupBox1.Controls.Add(this.titleBox);
			this.groupBox1.Controls.Add(this.authorBox);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(10, 334);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(747, 99);
			this.groupBox1.TabIndex = 59;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Metadati";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(385, 74);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 13);
			this.label9.TabIndex = 7;
			this.label9.Text = "Produttore";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(394, 48);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(47, 13);
			this.label8.TabIndex = 7;
			this.label8.Text = "Creatore";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(388, 22);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 13);
			this.label7.TabIndex = 7;
			this.label7.Text = "Keywords";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(26, 74);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(45, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Oggetto";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(38, 48);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(33, 13);
			this.label10.TabIndex = 5;
			this.label10.Text = "Titolo";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(33, 22);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(38, 13);
			this.label14.TabIndex = 4;
			this.label14.Text = "Autore";
			// 
			// prodBox
			// 
			this.prodBox.Location = new System.Drawing.Point(441, 71);
			this.prodBox.Name = "prodBox";
			this.prodBox.Size = new System.Drawing.Size(293, 20);
			this.prodBox.TabIndex = 3;
			// 
			// creatorBox
			// 
			this.creatorBox.Location = new System.Drawing.Point(441, 45);
			this.creatorBox.Name = "creatorBox";
			this.creatorBox.Size = new System.Drawing.Size(293, 20);
			this.creatorBox.TabIndex = 3;
			// 
			// kwBox
			// 
			this.kwBox.Location = new System.Drawing.Point(441, 19);
			this.kwBox.Name = "kwBox";
			this.kwBox.Size = new System.Drawing.Size(293, 20);
			this.kwBox.TabIndex = 3;
			// 
			// subjectBox
			// 
			this.subjectBox.Location = new System.Drawing.Point(71, 71);
			this.subjectBox.Name = "subjectBox";
			this.subjectBox.Size = new System.Drawing.Size(293, 20);
			this.subjectBox.TabIndex = 2;
			// 
			// titleBox
			// 
			this.titleBox.Location = new System.Drawing.Point(72, 45);
			this.titleBox.Name = "titleBox";
			this.titleBox.Size = new System.Drawing.Size(293, 20);
			this.titleBox.TabIndex = 1;
			// 
			// authorBox
			// 
			this.authorBox.Location = new System.Drawing.Point(72, 19);
			this.authorBox.Name = "authorBox";
			this.authorBox.Size = new System.Drawing.Size(293, 20);
			this.authorBox.TabIndex = 0;
			// 
			// inputBox
			// 
			this.inputBox.Location = new System.Drawing.Point(104, 12);
			this.inputBox.Name = "inputBox";
			this.inputBox.Size = new System.Drawing.Size(444, 20);
			this.inputBox.TabIndex = 56;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(51, 12);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 13);
			this.label5.TabIndex = 58;
			this.label5.Text = "File PDF";
			// 
			// ApriSingoloPDF
			// 
			this.ApriSingoloPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ApriSingoloPDF.Location = new System.Drawing.Point(554, 3);
			this.ApriSingoloPDF.Name = "ApriSingoloPDF";
			this.ApriSingoloPDF.Size = new System.Drawing.Size(88, 35);
			this.ApriSingoloPDF.TabIndex = 57;
			this.ApriSingoloPDF.Text = "SFOGLIA";
			this.ApriSingoloPDF.UseVisualStyleBackColor = true;
			this.ApriSingoloPDF.Click += new System.EventHandler(this.ApriSingoloPDFClick);
			// 
			// sigPanel
			// 
			this.sigPanel.Controls.Add(this.cbPDFA);
			this.sigPanel.Controls.Add(this.cbRagioneSingolo);
			this.sigPanel.Controls.Add(this.label11);
			this.sigPanel.Controls.Add(this.Contacttext);
			this.sigPanel.Controls.Add(this.label12);
			this.sigPanel.Controls.Add(this.Locationtext);
			this.sigPanel.Controls.Add(this.sigPanel2);
			this.sigPanel.Controls.Add(this.label13);
			this.sigPanel.Controls.Add(this.sigPanel1);
			this.sigPanel.Controls.Add(this.SigVisible);
			this.sigPanel.Location = new System.Drawing.Point(5, 41);
			this.sigPanel.Name = "sigPanel";
			this.sigPanel.Size = new System.Drawing.Size(752, 287);
			this.sigPanel.TabIndex = 55;
			// 
			// cbPDFA
			// 
			this.cbPDFA.Location = new System.Drawing.Point(613, 11);
			this.cbPDFA.Name = "cbPDFA";
			this.cbPDFA.Size = new System.Drawing.Size(136, 24);
			this.cbPDFA.TabIndex = 51;
			this.cbPDFA.Text = "Salva come PDF/A-1B";
			this.cbPDFA.UseVisualStyleBackColor = true;
			// 
			// cbRagioneSingolo
			// 
			this.cbRagioneSingolo.FormattingEnabled = true;
			this.cbRagioneSingolo.Items.AddRange(new object[] {
									"Certifico la conformità all\'originale del presente documento",
									"Sottoscrivo quanto contenuto",
									"Si rilascia per gli usi consentiti"});
			this.cbRagioneSingolo.Location = new System.Drawing.Point(66, 15);
			this.cbRagioneSingolo.Name = "cbRagioneSingolo";
			this.cbRagioneSingolo.Size = new System.Drawing.Size(219, 21);
			this.cbRagioneSingolo.TabIndex = 50;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(11, 18);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(47, 13);
			this.label11.TabIndex = 29;
			this.label11.Text = "Ragione";
			// 
			// Contacttext
			// 
			this.Contacttext.Location = new System.Drawing.Point(66, 44);
			this.Contacttext.Name = "Contacttext";
			this.Contacttext.Size = new System.Drawing.Size(218, 20);
			this.Contacttext.TabIndex = 30;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(11, 44);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(47, 13);
			this.label12.TabIndex = 31;
			this.label12.Text = "Contatto";
			// 
			// Locationtext
			// 
			this.Locationtext.Location = new System.Drawing.Point(66, 70);
			this.Locationtext.Name = "Locationtext";
			this.Locationtext.Size = new System.Drawing.Size(218, 20);
			this.Locationtext.TabIndex = 32;
			this.Locationtext.Text = "Preganziol";
			// 
			// sigPanel2
			// 
			this.sigPanel2.Controls.Add(this.clearBtn);
			this.sigPanel2.Controls.Add(this.sigImgBox);
			this.sigPanel2.Controls.Add(this.browseBtn);
			this.sigPanel2.Controls.Add(this.label27);
			this.sigPanel2.Enabled = false;
			this.sigPanel2.Location = new System.Drawing.Point(5, 96);
			this.sigPanel2.Name = "sigPanel2";
			this.sigPanel2.Size = new System.Drawing.Size(280, 187);
			this.sigPanel2.TabIndex = 49;
			this.sigPanel2.Visible = false;
			// 
			// clearBtn
			// 
			this.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.clearBtn.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clearBtn.Location = new System.Drawing.Point(137, 3);
			this.clearBtn.Name = "clearBtn";
			this.clearBtn.Size = new System.Drawing.Size(62, 22);
			this.clearBtn.TabIndex = 48;
			this.clearBtn.Text = "Pulisci";
			this.clearBtn.UseVisualStyleBackColor = true;
			this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
			// 
			// sigImgBox
			// 
			this.sigImgBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.sigImgBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.sigImgBox.Location = new System.Drawing.Point(8, 31);
			this.sigImgBox.Name = "sigImgBox";
			this.sigImgBox.Size = new System.Drawing.Size(269, 151);
			this.sigImgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.sigImgBox.TabIndex = 40;
			this.sigImgBox.TabStop = false;
			// 
			// browseBtn
			// 
			this.browseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.browseBtn.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.browseBtn.Location = new System.Drawing.Point(205, 3);
			this.browseBtn.Name = "browseBtn";
			this.browseBtn.Size = new System.Drawing.Size(62, 22);
			this.browseBtn.TabIndex = 43;
			this.browseBtn.Text = "Sfoglia";
			this.browseBtn.UseVisualStyleBackColor = true;
			this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(26, 7);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(98, 13);
			this.label27.TabIndex = 44;
			this.label27.Text = "Immagine di sfondo";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(11, 70);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(37, 13);
			this.label13.TabIndex = 33;
			this.label13.Text = "Luogo";
			// 
			// sigPanel1
			// 
			this.sigPanel1.Controls.Add(this.label33);
			this.sigPanel1.Controls.Add(this.label31);
			this.sigPanel1.Controls.Add(this.label32);
			this.sigPanel1.Controls.Add(this.sigHeight);
			this.sigPanel1.Controls.Add(this.sigWidth);
			this.sigPanel1.Controls.Add(this.label30);
			this.sigPanel1.Controls.Add(this.label29);
			this.sigPanel1.Controls.Add(this.sigPosY);
			this.sigPanel1.Controls.Add(this.sigPosX);
			this.sigPanel1.Controls.Add(this.previewPanel);
			this.sigPanel1.Controls.Add(this.label28);
			this.sigPanel1.Controls.Add(this.numberOfPagesUpDown);
			this.sigPanel1.Enabled = false;
			this.sigPanel1.Location = new System.Drawing.Point(298, 35);
			this.sigPanel1.Name = "sigPanel1";
			this.sigPanel1.Size = new System.Drawing.Size(446, 248);
			this.sigPanel1.TabIndex = 47;
			this.sigPanel1.Visible = false;
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label33.ForeColor = System.Drawing.Color.MediumBlue;
			this.label33.Location = new System.Drawing.Point(5, 6);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(190, 26);
			this.label33.TabIndex = 55;
			this.label33.Text = "Sposta/Ridimensiona il box \r\noppure usa i controlli sotto\r\n";
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(82, 194);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(41, 13);
			this.label31.TabIndex = 54;
			this.label31.Text = "Altezza";
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(67, 167);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(56, 13);
			this.label32.TabIndex = 53;
			this.label32.Text = "Larghezza";
			// 
			// sigHeight
			// 
			this.sigHeight.Location = new System.Drawing.Point(124, 192);
			this.sigHeight.Maximum = new decimal(new int[] {
									200,
									0,
									0,
									0});
			this.sigHeight.Name = "sigHeight";
			this.sigHeight.Size = new System.Drawing.Size(71, 20);
			this.sigHeight.TabIndex = 52;
			this.sigHeight.Value = new decimal(new int[] {
									65,
									0,
									0,
									0});
			// 
			// sigWidth
			// 
			this.sigWidth.Location = new System.Drawing.Point(124, 165);
			this.sigWidth.Maximum = new decimal(new int[] {
									200,
									0,
									0,
									0});
			this.sigWidth.Name = "sigWidth";
			this.sigWidth.Size = new System.Drawing.Size(71, 20);
			this.sigWidth.TabIndex = 51;
			this.sigWidth.Value = new decimal(new int[] {
									100,
									0,
									0,
									0});
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(82, 123);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(36, 13);
			this.label30.TabIndex = 50;
			this.label30.Text = "Basso";
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(77, 96);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(41, 13);
			this.label29.TabIndex = 49;
			this.label29.Text = "Sinistra";
			// 
			// sigPosY
			// 
			this.sigPosY.Location = new System.Drawing.Point(124, 121);
			this.sigPosY.Maximum = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.sigPosY.Name = "sigPosY";
			this.sigPosY.Size = new System.Drawing.Size(71, 20);
			this.sigPosY.TabIndex = 48;
			// 
			// sigPosX
			// 
			this.sigPosX.Location = new System.Drawing.Point(124, 94);
			this.sigPosX.Maximum = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.sigPosX.Name = "sigPosX";
			this.sigPosX.Size = new System.Drawing.Size(71, 20);
			this.sigPosX.TabIndex = 47;
			// 
			// previewPanel
			// 
			this.previewPanel.BackColor = System.Drawing.SystemColors.ControlDark;
			this.previewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.previewPanel.Controls.Add(this.pagePreviewPanel);
			this.previewPanel.Location = new System.Drawing.Point(201, 3);
			this.previewPanel.Name = "previewPanel";
			this.previewPanel.Size = new System.Drawing.Size(240, 240);
			this.previewPanel.TabIndex = 46;
			// 
			// pagePreviewPanel
			// 
			this.pagePreviewPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.pagePreviewPanel.Controls.Add(this.sigPicture);
			this.pagePreviewPanel.Location = new System.Drawing.Point(21, 53);
			this.pagePreviewPanel.Name = "pagePreviewPanel";
			this.pagePreviewPanel.Size = new System.Drawing.Size(200, 72);
			this.pagePreviewPanel.TabIndex = 1;
			// 
			// sigPicture
			// 
			this.sigPicture.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.sigPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.sigPicture.Location = new System.Drawing.Point(27, 38);
			this.sigPicture.Name = "sigPicture";
			this.sigPicture.Size = new System.Drawing.Size(50, 20);
			this.sigPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.sigPicture.TabIndex = 0;
			this.sigPicture.TabStop = false;
			this.sigPicture.Move += new System.EventHandler(this.sigPictureMove);
			this.sigPicture.Resize += new System.EventHandler(this.sigPictureResize);
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(28, 54);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(90, 13);
			this.label28.TabIndex = 45;
			this.label28.Text = "Numero di pagina";
			// 
			// numberOfPagesUpDown
			// 
			this.numberOfPagesUpDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numberOfPagesUpDown.Location = new System.Drawing.Point(124, 48);
			this.numberOfPagesUpDown.Maximum = new decimal(new int[] {
									0,
									0,
									0,
									0});
			this.numberOfPagesUpDown.Name = "numberOfPagesUpDown";
			this.numberOfPagesUpDown.Size = new System.Drawing.Size(71, 26);
			this.numberOfPagesUpDown.TabIndex = 35;
			this.numberOfPagesUpDown.ValueChanged += new System.EventHandler(this.numberOfPagesUpDown_ValueChanged);
			// 
			// SigVisible
			// 
			this.SigVisible.AutoSize = true;
			this.SigVisible.Location = new System.Drawing.Point(298, 14);
			this.SigVisible.Name = "SigVisible";
			this.SigVisible.Size = new System.Drawing.Size(85, 17);
			this.SigVisible.TabIndex = 34;
			this.SigVisible.Text = "Firma visibile";
			this.SigVisible.UseVisualStyleBackColor = true;
			this.SigVisible.CheckedChanged += new System.EventHandler(this.SigVisibleCheckedChanged);
			// 
			// multiSigChkBx
			// 
			this.multiSigChkBx.AutoSize = true;
			this.multiSigChkBx.Checked = true;
			this.multiSigChkBx.CheckState = System.Windows.Forms.CheckState.Checked;
			this.multiSigChkBx.Location = new System.Drawing.Point(4, 584);
			this.multiSigChkBx.Name = "multiSigChkBx";
			this.multiSigChkBx.Size = new System.Drawing.Size(489, 17);
			this.multiSigChkBx.TabIndex = 32;
			this.multiSigChkBx.Text = "Abilita la multi firma (puoi firmare più volte lo stesso documento senza invalida" +
			"re le firme già presenti";
			this.multiSigChkBx.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.TSALbl3);
			this.groupBox5.Controls.Add(this.TSALbl2);
			this.groupBox5.Controls.Add(this.tsaLogin);
			this.groupBox5.Controls.Add(this.tsaPwd);
			this.groupBox5.Controls.Add(this.TSALbl1);
			this.groupBox5.Controls.Add(this.TSAUrlTextBox);
			this.groupBox5.Controls.Add(this.tsaCbx);
			this.groupBox5.Location = new System.Drawing.Point(4, 473);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(761, 109);
			this.groupBox5.TabIndex = 31;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "TimeStamp";
			// 
			// TSALbl3
			// 
			this.TSALbl3.AutoSize = true;
			this.TSALbl3.Enabled = false;
			this.TSALbl3.Location = new System.Drawing.Point(25, 86);
			this.TSALbl3.Name = "TSALbl3";
			this.TSALbl3.Size = new System.Drawing.Size(77, 13);
			this.TSALbl3.TabIndex = 34;
			this.TSALbl3.Text = "TSA Password";
			// 
			// TSALbl2
			// 
			this.TSALbl2.AutoSize = true;
			this.TSALbl2.Enabled = false;
			this.TSALbl2.Location = new System.Drawing.Point(45, 59);
			this.TSALbl2.Name = "TSALbl2";
			this.TSALbl2.Size = new System.Drawing.Size(57, 13);
			this.TSALbl2.TabIndex = 33;
			this.TSALbl2.Text = "TSA Login";
			// 
			// tsaLogin
			// 
			this.tsaLogin.Enabled = false;
			this.tsaLogin.Location = new System.Drawing.Point(108, 56);
			this.tsaLogin.Name = "tsaLogin";
			this.tsaLogin.Size = new System.Drawing.Size(414, 20);
			this.tsaLogin.TabIndex = 32;
			// 
			// tsaPwd
			// 
			this.tsaPwd.Enabled = false;
			this.tsaPwd.Location = new System.Drawing.Point(108, 83);
			this.tsaPwd.Name = "tsaPwd";
			this.tsaPwd.PasswordChar = '*';
			this.tsaPwd.Size = new System.Drawing.Size(414, 20);
			this.tsaPwd.TabIndex = 31;
			// 
			// TSALbl1
			// 
			this.TSALbl1.AutoSize = true;
			this.TSALbl1.Enabled = false;
			this.TSALbl1.Location = new System.Drawing.Point(58, 32);
			this.TSALbl1.Name = "TSALbl1";
			this.TSALbl1.Size = new System.Drawing.Size(44, 13);
			this.TSALbl1.TabIndex = 30;
			this.TSALbl1.Text = "TSA Url";
			// 
			// TSAUrlTextBox
			// 
			this.TSAUrlTextBox.Enabled = false;
			this.TSAUrlTextBox.Location = new System.Drawing.Point(108, 29);
			this.TSAUrlTextBox.Name = "TSAUrlTextBox";
			this.TSAUrlTextBox.Size = new System.Drawing.Size(414, 20);
			this.TSAUrlTextBox.TabIndex = 29;
			this.TSAUrlTextBox.Text = "http://10.0.0.245:8080/signserver/process?workerName=TimeStampSigner";
			// 
			// tsaCbx
			// 
			this.tsaCbx.AutoSize = true;
			this.tsaCbx.Location = new System.Drawing.Point(108, 10);
			this.tsaCbx.Name = "tsaCbx";
			this.tsaCbx.Size = new System.Drawing.Size(105, 17);
			this.tsaCbx.TabIndex = 0;
			this.tsaCbx.Text = "Marca temporale";
			this.tsaCbx.UseVisualStyleBackColor = true;
			this.tsaCbx.CheckedChanged += new System.EventHandler(this.tsaCbx_CheckedChanged);
			// 
			// ofd2
			// 
			this.ofd2.FileName = "*.pdf";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(779, 636);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.multiSigChkBx);
			this.Controls.Add(this.pb);
			this.ForeColor = System.Drawing.SystemColors.WindowText;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SignPDF";
			this.cm1.ResumeLayout(false);
			this.gbFirma.ResumeLayout(false);
			this.gbFirma.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.sigPanel.ResumeLayout(false);
			this.sigPanel.PerformLayout();
			this.sigPanel2.ResumeLayout(false);
			this.sigPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.sigImgBox)).EndInit();
			this.sigPanel1.ResumeLayout(false);
			this.sigPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.sigHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sigWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sigPosY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sigPosX)).EndInit();
			this.previewPanel.ResumeLayout(false);
			this.pagePreviewPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sigPicture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numberOfPagesUpDown)).EndInit();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.CheckBox cbPDFA;
		private System.Windows.Forms.ComboBox cbRagioneSingolo;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox authorBox;
		private System.Windows.Forms.TextBox titleBox;
		private System.Windows.Forms.TextBox subjectBox;
		private System.Windows.Forms.TextBox kwBox;
		private System.Windows.Forms.TextBox creatorBox;
		private System.Windows.Forms.TextBox prodBox;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button ApriSingoloPDF;
		private System.Windows.Forms.OpenFileDialog ofd2;
		private System.Windows.Forms.CheckBox tsaCbx;
		private System.Windows.Forms.TextBox TSAUrlTextBox;
		private System.Windows.Forms.Label TSALbl1;
		private System.Windows.Forms.TextBox tsaPwd;
		private System.Windows.Forms.TextBox tsaLogin;
		private System.Windows.Forms.Label TSALbl2;
		private System.Windows.Forms.Label TSALbl3;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.CheckBox multiSigChkBx;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.CheckBox SigVisible;
		private System.Windows.Forms.NumericUpDown numberOfPagesUpDown;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.PictureBox sigPicture;
		private System.Windows.Forms.Panel pagePreviewPanel;
		private System.Windows.Forms.Panel previewPanel;
		private System.Windows.Forms.NumericUpDown sigPosX;
		private System.Windows.Forms.NumericUpDown sigPosY;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.NumericUpDown sigWidth;
		private System.Windows.Forms.NumericUpDown sigHeight;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Panel sigPanel1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Button browseBtn;
		private System.Windows.Forms.PictureBox sigImgBox;
		private System.Windows.Forms.Button clearBtn;
		private System.Windows.Forms.Panel sigPanel2;
		private System.Windows.Forms.TextBox Locationtext;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox Contacttext;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Panel sigPanel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox inputBox;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ComboBox cbRagione;
		private System.Windows.Forms.ContextMenuStrip cm1;
		private System.Windows.Forms.ToolStripMenuItem eliminaToolStripMenuItem;
		private System.Windows.Forms.CheckBox cbFirmaVisibile;
		private System.Windows.Forms.TextBox tbContatto;
		private System.Windows.Forms.TextBox tbLuogo;
		private System.Windows.Forms.ProgressBar pb;
		private System.Windows.Forms.ListBox lbPosizioneFirma;
		private System.Windows.Forms.GroupBox gbFirma;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton rbVecchiaPagina;
		private System.Windows.Forms.RadioButton rbNuovaPagina;
		private System.Windows.Forms.ToolTip tt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox lb;
	}
}
