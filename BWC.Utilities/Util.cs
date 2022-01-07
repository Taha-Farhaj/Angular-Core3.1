using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BWC.Utilities
{
    public static class Util
    {
        private static Random random = new Random();
        public static string RandomString()
        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
