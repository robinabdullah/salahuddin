﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace salahuddinahmed.HelperClasses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    namespace TestConsole
    {
    }
    static class ParameterEncryption
    {
        public static string EncryptionKey = "ABTECH";

        public static string Encrypt(string textToEncrypt)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(textToEncrypt);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    textToEncrypt = Convert.ToBase64String(ms.ToArray());
                }
            }
            return textToEncrypt;
        }

        public static string Decrypt(string textToDecrypt)
        {
            textToDecrypt = textToDecrypt.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(textToDecrypt);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    textToDecrypt = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return textToDecrypt;
        }
    }

}