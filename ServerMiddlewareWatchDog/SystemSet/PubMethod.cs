using Ini;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerMiddlewareWatchDog.SystemSet
{
    public class PubMethod
    {
        public static bool ReadSystem()
        {
            bool bolResult = false;
            ReadSystem_Basic();
            return bolResult;
        }

        public static bool ReadSystem_Basic()
        {
            bool bolResult = false;

            IniFile ini = new IniFile(SystemSet_Basic.WatchDogSetIniFilePath);
            string Temp_strValue = ini.IniReadValue("Basic", "ProgramName");
            if (!string.IsNullOrEmpty(Temp_strValue))
            {
                SystemSet_Basic.ProgramName = Temp_strValue;
            }
            Temp_strValue = ini.IniReadValue("Basic", "ProcessName");
            if (!string.IsNullOrEmpty(Temp_strValue))
            {
                SystemSet_Basic.ProcessName = Temp_strValue;
            }
            return bolResult;
        }

        /// <summary>
        /// 写入配置文件
        /// </summary>
        /// <param name="strFilePath">ini文件地址</param>
        /// <param name="strSec">标签</param>
        /// <param name="strKey">Key</param>
        /// <param name="strValue">Value</param>
        public static void WriteIniFile(string strFilePath, string strSec, string strKey, string strValue)
        {
            IniFile ini = new IniFile(strFilePath);
            ini.IniWriteValue(strSec, strKey, strValue);
        }
    }
}
