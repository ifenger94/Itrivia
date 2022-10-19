using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Helpers
{
    public class ConstantsHelper
    {
        public static readonly string BearerAuthenticationScheme = "Bearer";
        public static readonly string TokenIssuer = "localhost";
        public static readonly string TokenAudience = "http://localhost";
        public static readonly byte[] KeyForHmacSha256 = new byte[64];

        static ConstantsHelper()
        {
            RNGCryptoServiceProvider cryptoProvider = new RNGCryptoServiceProvider();
            cryptoProvider.GetNonZeroBytes(KeyForHmacSha256);
        }
    }
}
