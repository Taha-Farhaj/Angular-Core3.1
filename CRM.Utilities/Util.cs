using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace CRM.Utilities
{
    public static class Util
    {
        public static string Hash(string s)
        {
            SHA1 sha = new SHA1Managed();
            var hash = new StringBuilder();
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            foreach (byte a in bytes)
            {
                var h = a.ToString("x2");
                hash.Append(h);
            }
            return hash.ToString();
        }
    }
}
