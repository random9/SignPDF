namespace SignPDF
{
    partial class PwdDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PwdDialog));
        	this.pwdTextBox = new System.Windows.Forms.TextBox();
        	this.OKBtn = new System.Windows.Forms.Button();
        	this.CancelBtn = new System.Windows.Forms.Button();
        	this.label1 = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// pwdTextBox
        	// 
        	this.pwdTextBox.Location = new System.Drawing.Point(12, 44);
        	this.pwdTextBox.Name = "pwdTextBox";
        	this.pwdTextBox.PasswordChar = '*';
        	this.pwdTextBox.Size = new System.Drawing.Size(359, 20);
        	this.pwdTextBox.TabIndex = 0;
        	// 
        	// OKBtn
        	// 
        	this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.OKBtn.Location = new System.Drawing.Point(12, 85);
        	this.OKBtn.Name = "OKBtn";
        	this.OKBtn.Size = new System.Drawing.Size(102, 23);
        	this.OKBtn.TabIndex = 1;
        	this.OKBtn.Text = "OK";
        	this.OKBtn.UseVisualStyleBackColor = true;
        	// 
        	// CancelBtn
        	// 
        	this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.CancelBtn.Location = new System.Drawing.Point(261, 85);
        	this.CancelBtn.Name = "CancelBtn";
        	this.CancelBtn.Size = new System.Drawing.Size(110, 23);
        	this.CancelBtn.TabIndex = 2;
        	this.CancelBtn.Text = "Cancel";
        	this.CancelBtn.UseVisualStyleBackColor = true;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label1.Location = new System.Drawing.Point(12, 9);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(322, 15);
        	this.label1.TabIndex = 3;
        	this.label1.Text = "Il Documento è protetto, inserisci la password qui sotto:";
        	// 
        	// PwdDialog
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(394, 127);
        	this.ControlBox = false;
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.CancelBtn);
        	this.Controls.Add(this.OKBtn);
        	this.Controls.Add(this.pwdTextBox);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "PwdDialog";
        	this.ShowIcon = false;
        	this.ShowInTaskbar = false;
        	this.Text = "iSafePDF - Password required";
        	this.TopMost = true;
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox pwdTextBox;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label label1;
    }
}