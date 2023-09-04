using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Application
{
    public class HmacCrypto
    {
        public static async Task<string> EncryptAsync(string data, string secretKey, HmacAlgorithmVersion algorithm)
        {
            if (data is null) throw new ArgumentNullException("data");

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));

            byte[] key = Encoding.UTF8.GetBytes(secretKey);
            byte[] hash;

            using (var hmac = new HmacAlgorithm(algorithm, key))
            {
                hash = await hmac.ComputeHashAsync(stream);
            }

            return Convert.ToHexString(hash);
        }

        public static bool VerifyHash(string data, string secretKey, byte[] saltHash, HmacAlgorithmVersion algorithm)
        {
            byte[] key = Encoding.UTF8.GetBytes(secretKey);

            using (var hmac = new HmacAlgorithm(algorithm, key))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != saltHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
