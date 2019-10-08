using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ServerMiddlewareWatchDog
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            LogManager.GetLogger("WatchDogLog").Log(LogLevel.Info, "看门狗程序启动");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
            LogManager.GetLogger("WatchDogLog").Log(LogLevel.Info, "看门狗程序关闭");
        }
    }
}
