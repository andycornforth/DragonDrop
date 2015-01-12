using DragDetails.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace DragDetails
{
    public class Cryptography
    {
        public static string EncryptString(string input, int pin)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(input);
            string encodedString = System.Convert.ToBase64String(data);

            if (pin != 0)
            {
                return encodedString + (pin * 86028121);
            }
            return encodedString;
        }

        public static string DecryptFile(string input, int pin)
        {
            StreamReader streamReader = File.OpenText(input);
            string encodedString = streamReader.ReadToEnd();
            if (pin != 0)
            {
                string pinString = Convert.ToString(pin * 86028121);
                encodedString = encodedString.Replace(pinString, string.Empty);
            }
            byte[] encodedDataBytes = System.Convert.FromBase64String(encodedString);
            string decodedString = System.Text.Encoding.UTF8.GetString(encodedDataBytes);

            return decodedString;
        }
    }
}