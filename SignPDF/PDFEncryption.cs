using System;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text.pdf;
using System.Collections;

namespace SignPDF
{

    public enum permissionType
    {
        Assembly = PdfWriter.ALLOW_ASSEMBLY,
        Copy = PdfWriter.ALLOW_COPY,
        DegradedPrinting = PdfWriter.ALLOW_DEGRADED_PRINTING,
        FillIn = PdfWriter.ALLOW_FILL_IN,
        ModifyAnnotation = PdfWriter.ALLOW_MODIFY_ANNOTATIONS,
        ModifyContent = PdfWriter.ALLOW_MODIFY_CONTENTS,
        Printing = PdfWriter.ALLOW_PRINTING,
        ScreenReaders = PdfWriter.ALLOW_SCREENREADERS
    };

    public class PDFEncryption
    {        
        public string UserPwd { get; set; }
        public string OwnerPwd { get; set; }
        public bool Encryption { get; set; }
        public List<permissionType> Permissions = new List<permissionType>();

        public PDFEncryption()
        {
        }

        public void Encrypt(PdfStamper stamper)
        {
            int permission = 0;
            foreach (int permissionType in this.Permissions)
            {
                permission |= (int)permissionType;
            }
            stamper.SetEncryption(this.Encryption, this.UserPwd, this.OwnerPwd, permission);
        }
    }
}
