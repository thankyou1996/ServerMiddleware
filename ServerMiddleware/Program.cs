﻿using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ServerMiddleware
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            LogManager.GetLogger("ServerConnLog").Log(LogLevel.Info, "Program Start");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
            LogManager.GetLogger("ServerConnLog").Log(LogLevel.Info, "Program End");
        }
    }
}
