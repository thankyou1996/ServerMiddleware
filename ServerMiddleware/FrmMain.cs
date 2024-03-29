﻿using HPSocketCS;
using MiddlewareDS;
using MiddlewareDS.DBModel;
using MiddlewareDS.DBService;
using NLog;
using ServerMiddleware.SystemSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServerMiddleware
{
    public partial class FrmMain : Form
    {
        string file = System.Windows.Forms.Application.ExecutablePath;
        private delegate void ShowMsg(string msg);
        private ShowMsg AddMsgDelegate;
        private AppState appState = AppState.Stoped;
        public FrmMain()
        {
            InitializeComponent();
        }
        HPSocketCS.TcpClient client = new HPSocketCS.TcpClient();
        private void FrmMain_Load(object sender, EventArgs e)
        {
            Init();
        }
        public void Init()
        {
            if (!WatchDogRunning())
            {
                WatchDogStart();
            }
            // 加个委托显示msg,因为on系列都是在工作线程中调用的,ui不允许直接操作
            AddMsgDelegate = new ShowMsg(AddMsg);
            Init_Config();
            client.OnPrepareConnect += new TcpClientEvent.OnPrepareConnectEventHandler(OnPrepareConnect);
            client.OnConnect += new TcpClientEvent.OnConnectEventHandler(OnConnect);
            client.OnSend += new TcpClientEvent.OnSendEventHandler(OnSend);
            client.OnReceive += new TcpClientEvent.OnReceiveEventHandler(OnReceive);
            client.OnClose += new TcpClientEvent.OnCloseEventHandler(OnClose);
            SetAppState(AppState.Stoped);
            string ip = txtIpAddress.Text;
            ushort port = Convert.ToUInt16(txtPort.Text);
            Connect(ip, port);
        }

        public void Init_Config()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            MiddlewareDS.Para.EventDBConnectStr = config.AppSettings.Settings["SM_EventDBConnectStr"].Value;
            MiddlewareDS.Para.ServerAddress = config.AppSettings.Settings["SM_ServerAddress"].Value;
            MiddlewareDS.Para.ServerPort = Convert.ToUInt16(config.AppSettings.Settings["SM_ServerPort"].Value);
            MiddlewareDS.Para.SyncIDFlag = Convert.ToUInt16(config.AppSettings.Settings["SM_SyncIDFlag"].Value);
            MiddlewareDS.Para.CmdAddNewLine = Convert.ToBoolean(config.AppSettings.Settings["SM_AutoAddNewLine"].Value);
            txtIpAddress.Text = MiddlewareDS.Para.ServerAddress;
            txtPort.Text = Convert.ToString(MiddlewareDS.Para.ServerPort);
            chkAddNewLine.Checked = MiddlewareDS.Para.CmdAddNewLine;
        }

        #region Client初始化相关函数

        HandleResult OnPrepareConnect(TcpClient sender, IntPtr socket)
        {
            string strMsg = string.Format(" > [{0},OnPrepareConnect]", sender.ConnectionId);
            AddLog(strMsg);
            AddMsg(strMsg);
            return HandleResult.Ok;
        }

        HandleResult OnConnect(TcpClient sender)
        {
            // 已连接 到达一次
            // 如果是异步联接,更新界面状态
            //this.Invoke(new ConnectUpdateUiDelegate(ConnectUpdateUi));
            string strMsg = string.Format(" > [{0},OnConnect]", sender.ConnectionId);
            AddLog(strMsg);
            AddMsg(strMsg);
            this.BeginInvoke(new EventHandler(delegate
            {
                SetAppState(AppState.Started);
            }));
            return HandleResult.Ok;
        }

        HandleResult OnSend(TcpClient sender, byte[] bytes)
        {
            // 客户端发数据了
            string strSend = Encoding.UTF8.GetString(bytes);
            string strMsg = string.Format(" > [{0},OnSend] -> ({1} )", sender.ConnectionId, strSend);
            AddLog(strMsg);
            if (chkSend.Checked)
            {
                AddMsg(strMsg);
            }
            return HandleResult.Ok;
        }

        HandleResult OnReceive(TcpClient sender, byte[] bytes)
        {
            string strSend = Encoding.UTF8.GetString(bytes);
            string strMsg = string.Format(" > [{0},OnReceive] -> ({1} )", sender.ConnectionId, strSend);
            AddLog(strMsg);
            AddMsg(strMsg);
            return HandleResult.Ok;
        }

        HandleResult OnClose(TcpClient sender, SocketOperation enOperation, int errorCode)
        {
            if (errorCode == 0)
            {
                // 连接关闭了
                string strMsg = string.Format(" > [{0},OnClose]", sender.ConnectionId);
                AddLog(strMsg);
                AddMsg(strMsg);
            }
            else
            {    // 出错了
                string strMsg = string.Format(" > [{0},OnError] -> OP:{1},CODE:{2}", sender.ConnectionId, enOperation, errorCode);
                AddLog(strMsg);
                AddMsg(strMsg);
            }
            this.BeginInvoke(new EventHandler(delegate
            {
                SetAppState(AppState.Stoped);
                CommonMethod.Common.Delay_Millisecond(3000);
                if (!this.IsDisposed)
                {
                    string ip = txtIpAddress.Text;
                    ushort port = Convert.ToUInt16(txtPort.Text);
                    Connect(ip, port);
                }
            }));
            return HandleResult.Ok;
        }

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="msg"></param>
        public void AddLog(string msg)
        {
            LogManager.GetLogger("ServerConnLog").Log(LogLevel.Info, msg);
        }

        void AddMsg(string msg)
        {
            if (this.lbxMsg.InvokeRequired)
            {
                this.lbxMsg.Invoke(AddMsgDelegate, msg);
            }
            else
            {
                if (this.lbxMsg.Items.Count > 100)
                {
                    this.lbxMsg.Items.RemoveAt(0);
                }
                this.lbxMsg.Items.Add(msg);
                this.lbxMsg.TopIndex = this.lbxMsg.Items.Count - (int)(this.lbxMsg.Height / this.lbxMsg.ItemHeight);
            }
        }
        #endregion

        #region 数据通讯相关

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="strIP"></param>
        /// <param name="uPort"></param>
        public void Connect(string strIP, ushort uPort)
        {
            SetAppState(AppState.Starting);
            client.Connect(strIP, uPort, true);
            //if (client.Connect(strIP, uPort, false))
            //{
            //    SetAppState(AppState.Started);
            //    AddLog("Conect OK");
            //    AddMsg("Conect OK");
            //}
            //else
            //{
            //    SetAppState(AppState.Stoped);
            //    AddLog("Connect Fail");
            //    AddMsg("Connect Fail");
            //}
        }
        #endregion

        #region 看门狗相关

        /// <summary>
        /// 看门狗是否存在
        /// </summary>
        /// <returns></returns>
        public bool WatchDogRunning()
        {
            if ((Process.GetProcessesByName("ServerMiddlewareWatchDog").Length > 0))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 启动看门狗
        /// </summary>
        /// <returns></returns>
        public bool WatchDogStart()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\ServerMiddlewareWatchDog.exe"))
            {
                LogManager.GetLogger("WatchDogLog").Log(LogLevel.Info, "运行看门狗程序");
                Process.Start("ServerMiddlewareWatchDog.exe");
                return true;
            }
            else
            {
                LogManager.GetLogger("WatchDogLog").Log(LogLevel.Info, "看门狗程序不存在");
            }
            
            return false;
        }

        /// <summary>
        ///关闭看门狗
        /// </summary>
        /// <returns></returns>
        public bool WatchDogStop()
        {
            LogManager.GetLogger("WatchDogLog").Log(LogLevel.Info, "停止看门狗程序");
            CommonMethod.ProcessControl.KillProcess("ServerMiddlewareWatchDog");
            return true;
        }

        #endregion


        private void BtnSend_Click(object sender, EventArgs e)
        {
            string send = this.txtSend.Text;
            if (send.Length == 0)
            {
                return;
            }
            if (chkAddNewLine.Checked)
            {
                send += Environment.NewLine;
            }
            byte[] bytes = Encoding.UTF8.GetBytes(send);
            IntPtr connId = client.ConnectionId;
            // 发送
            if (client.Send(bytes, bytes.Length))
            {
                string strMsg = string.Format("$ ({0}) Send OK --> {1}", connId, send);
                AddLog(strMsg);
                AddMsg(strMsg);
            }
            else
            {
                string strMsg = string.Format("$ ({0}) Send Fail --> {1} ({2})", connId, send, bytes.Length);
                AddLog(strMsg);
                AddMsg(strMsg);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            //写入看门狗日志
            PubMethod.WriteIniFile(SystemSet_Basic.WatchDogSetIniFilePath, "Basic", "WatchDogFlag", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //定时获取数据
            if (!client.IsStarted)//已经连接
            {
                timer1.Enabled = true;
                return;
            }
            DbContext<T_Test1> db = new DbContext<T_Test1>();
            List<T_Test1> Temp_lstEvent = db.GetList(item => item.ID > Para.SyncIDFlag);
            foreach (T_Test1 item in Temp_lstEvent)
            {
                string send = Agreement.GetEventCmd(item);
                byte[] bytes = Encoding.UTF8.GetBytes(send);

                if (client.Send(bytes, bytes.Length))
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(file);
                    Para.SyncIDFlag = item.ID;
                    config.AppSettings.Settings["SM_SyncIDFlag"].Value = Convert.ToString(item.ID);
                    config.Save();
                    CommonMethod.Common.Delay_Millisecond(100);
                }
                else if (!client.IsStarted)
                {
                    string strMsg = string.Format("$ ({0}) Send Fail --> {1} ({2})", client.ConnectionId, item.NameT, item.NameT.Length);
                    AddLog(strMsg);
                    AddMsg(strMsg);
                    timer1.Enabled = true;
                    return;
                }
            }
            timer1.Enabled = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ip = txtIpAddress.Text;
            ushort port = Convert.ToUInt16(txtPort.Text);
            Connect(ip, port);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (client.Stop())
            {
                string strMsg = string.Format("$Stop Success -> {0}({1})", client.ErrorMessage, client.ErrorCode);
                AddLog(strMsg);
                AddMsg(strMsg);
            }
            else
            {
                string strMsg = string.Format("$Stop Error -> {0}({1})", client.ErrorMessage, client.ErrorCode);
                AddLog(strMsg);
                AddMsg(strMsg);
            }
            SetAppState(AppState.Stoped);
        }



        /// <summary>
        /// 设置程序状态
        /// </summary>
        /// <param name="state"></param>
        void SetAppState(AppState state)
        {
            appState = state;
            this.btnStart.Enabled = (appState == AppState.Stoped);
            this.btnStop.Enabled = (appState == AppState.Started);
            this.txtIpAddress.Enabled = (appState == AppState.Stoped);
            this.txtPort.Enabled = (appState == AppState.Stoped);
            this.btnSend.Enabled = (appState == AppState.Started);
        }

        private void btnDBTest_Click(object sender, EventArgs e)
        {
            try
            {
                DbContext<T_Test1> db = new DbContext<T_Test1>();
                List<T_Test1> Temp_lstEvent = db.GetList(item => item.ID > Para.SyncIDFlag);
                MessageBox.Show("数据库正常");
            }
            catch(Exception ex)
            {
                string strMsg = "数据库异常" + Environment.NewLine + ex.ToString();
                MessageBox.Show(strMsg);
            }
        }
        

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            client.Stop();
            WatchDogStop();
        }

        private void chkAddNewLine_CheckedChanged(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            Para.CmdAddNewLine = chkAddNewLine.Checked;
            config.AppSettings.Settings["SM_AutoAddNewLine"].Value = Convert.ToString(Para.CmdAddNewLine).ToLower();
            config.Save();
        }
    }
}
