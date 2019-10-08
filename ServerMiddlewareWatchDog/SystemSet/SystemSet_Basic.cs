using System;
using System.Collections.Generic;
using System.Text;

namespace ServerMiddlewareWatchDog.SystemSet
{
    public class SystemSet_Basic
    {
        public static string WatchDogSetIniFilePath = Environment.CurrentDirectory + "\\System_WatchDog_Basic.ini";//必须要使用完整的文件名

        public const string ProgramName_Default = "ServerMiddleware.exe";
        static string strProgramName = ProgramName_Default;

        /// <summary>
        /// 程序名称
        /// </summary>
        public static string ProgramName
        {
            get { return strProgramName; }
            set
            {
                strProgramName = value;
            }
        }

        public const string ProcessName_Default= "ServerMiddleware";

        static string strProcessName = ProcessName_Default;

        /// <summary>
        /// 程序处理名称
        /// </summary>
        public static string ProcessName
        {
            get { return strProcessName; }
            set { strProcessName = value; }
        }
        
    }
}
