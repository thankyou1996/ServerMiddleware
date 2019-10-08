using Ini;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMiddleware
{
    public class PubMethod
    {
        public static void WriteIniFile(string strFilePath, string strSec, string strKey, string strValue)
        {
            IniFile ini = new IniFile(strFilePath);
            ini.IniWriteValue(strSec, strKey, strValue);
        }
    }
}
