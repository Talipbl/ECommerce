using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Shared.Utilities.Cryptography.AesCrypto
{
    public class AesCrypto
    {
        public static string Encrpty(string data, string privateKey)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(privateKey);
                aes.GenerateIV();

                ICryptoTransform cryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream stream = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(stream, cryptoTransform, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(data);
                    }

                    return Convert.ToBase64String(aes.IV) + "|" + Convert.ToBase64String(stream.ToArray());
                }
            }
        }

        public static string Decrypt(string encryptedText, string privateKey)
        {
            string[] parts = encryptedText.Split('|');
            byte[] iv = Convert.FromBase64String(parts[0]);
            byte[] cipherText = Convert.FromBase64String(parts[1]);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(privateKey);
                aes.IV = iv;

                ICryptoTransform cryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream stream = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(stream, cryptoTransform, CryptoStreamMode.Read))
                    using (StreamReader swEncrypt = new StreamReader(csEncrypt))
                    {
                        return swEncrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}
