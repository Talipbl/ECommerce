using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.Utilities
{
    public class HmacAlgorithm : HMAC
    {
        public HMAC Hmac { get; set; }
        public HmacAlgorithm(HmacAlgorithmVersion algorithm, byte[] key)
        {
            switch (algorithm)
            {
                case HmacAlgorithmVersion.HmacMD5:
                    Hmac = new HMACMD5(key);
                    break;
                case HmacAlgorithmVersion.HmacSHA1:
                    Hmac = new HMACSHA1(key);
                    break;
                case HmacAlgorithmVersion.HmacSHA256:
                    Hmac = new HMACSHA256(key);
                    break;
                case HmacAlgorithmVersion.HmacSHA384:
                    Hmac = new HMACSHA384(key);
                    break;
                case HmacAlgorithmVersion.HmacSHA512:
                    Hmac = new HMACSHA512(key);
                    break;
                default:
                    throw new ArgumentException("Invalid HMAC algorithm.");
            }
        }
    }
}
