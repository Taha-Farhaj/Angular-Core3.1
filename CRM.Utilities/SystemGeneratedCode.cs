using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Utilities
{
    public static class SystemGeneratedCode
    {
        public static string SystemGenerate(int totalFiles, string officeCode, ref long LastCode)
        {
            LastCode++;
            String formatted = officeCode + "-" + DateTime.Now.Day + DateTime.Now.Month + "-" + totalFiles + "-" + String.Format("{0:0000}", LastCode);
            return formatted;
        }
    }
}
