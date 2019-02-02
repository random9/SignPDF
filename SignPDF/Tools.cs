using System;
using System.Collections.Generic;
using System.Text;

namespace SignPDF
{
    public static class Tools
    {
        public static byte[] StrToByteArray(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }
    }
}
