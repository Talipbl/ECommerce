using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.Utilities
{
    public class RsaCrypto
    {
        public static string Encrypt(string data)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                string publicKey = rsa.ToXmlString(false);
                rsa.FromXmlString(publicKey);

                byte[] encodedData = Encoding.UTF8.GetBytes(data);
                byte[] encryptedData = rsa.Encrypt(encodedData, true);

                return Convert.ToHexString(encryptedData);
            }
        }

        public static string Decrypt(string data)
        {
            string privateKeyXml = "";
            byte[] encryptedData = Encoding.UTF8.GetBytes(data);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKeyXml);

                byte[] decryptedData = rsa.Decrypt(encryptedData, true);

                return Encoding.UTF8.GetString(decryptedData);
            }
        }
    }
}
