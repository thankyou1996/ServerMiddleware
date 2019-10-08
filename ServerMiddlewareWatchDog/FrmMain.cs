using Ini;
using NLog;
using ServerMiddlewareWatchDog.SystemSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServerMiddlewareWatchDog
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void timCheck_Tick(object sender, EventArgs e)
        {

            timCheck.Enabled = false;
            if (NeedStartProg())
            {
                StartProgram();
            }
            timCheck.Enabled = true;
        }

        /// <summary>
        /// 启动程序
        /// </summary>
        /// <returns></returns>
        public bool StartProgram()
        {
            bool bolResult = false;
            //判断程序名称是否存在（未响应情况）
            if ((Process.GetProcessesByName(SystemSet_Basic.ProcessName).Length > 0))
            {
                //关闭程序
                LogManager.GetLogger("WatchDogLog").Log(LogLevel.Info, "开始关闭程序:" + SystemSet_Basic.ProgramName);
                Common.KillProcess(SystemSet_Basic.ProcessName);

                LogManager.GetLogger("WatchDogLog").Log(LogLevel.Info, "结束关闭程序:" + SystemSet_Basic.ProgramName);
                //写入ini文件
                IniFile ini = new IniFile(SystemSet_Basic.WatchDogSetIniFilePath);
                ini.IniWriteValue("Basic", "WatchDogFlag", DateTime.Now.ToString()); //标识 已更新
                Common.Delay_Millisecond(3000);
            }

            LogManager.GetLogger("WatchDogLog").Log(LogLevel.Info, "开始启动程序:" + SystemSet_Basic.ProgramName);
            Process.Start(SystemSet_Basic.ProgramName);
            LogManager.GetLogger("WatchDogLog").Log(LogLevel.Info, "结束启动程序:" + SystemSet_Basic.ProgramName);
            return bolResult;
        }

        /// <summary>
        /// 是否需要启动程序
        /// </summary>
        /// <returns></returns>
        public bool NeedStartProg()
        {
            bool bolResult =  (Process.GetProcessesByName(SystemSet_Basic.ProcessName).Length < 1);
            if (!bolResult)
            {
                IniFile ini = new IniFile(SystemSet_Basic.WatchDogSetIniFilePath);
                string Temp_strValue = ini.IniReadValue("Basic", "WatchDogFlag");
                if (!string.IsNullOrEmpty(Temp_strValue))
                {
                    DateTime tim = Convert.ToDateTime(Temp_strValue);
                    //超过1分钟未响应
                    bolResult = (DateTime.Now - tim).TotalSeconds > 3600;
                }
            }
            return bolResult;
        }
    }
}
