using MiddlewareDS;
using MiddlewareDS.DBModel;
using MiddlewareDS.DBService;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServerMiddleware
{
    public partial class FrmClientTest : Form
    {
        string file = System.Windows.Forms.Application.ExecutablePath;
        private delegate void ShowMsg(string msg);
        private ShowMsg AddMsgDelegate;
        private AppState appState = AppState.Stoped;
        public FrmClientTest()
        {
            InitializeComponent();
        }
        TcpClient client = new TcpClient();
        NetworkStream ns;
        StreamReader sr;
        StreamWriter sw;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Init();
        }
        public void Init()
        {
            // 加个委托显示msg,因为on系列都是在工作线程中调用的,ui不允许直接操作
            AddMsgDelegate = new ShowMsg(AddMsg);
            Init_Config();
            //client.OnPrepareConnect += new TcpClientEvent.OnPrepareConnectEventHandler(OnPrepareConnect);
            //client.OnConnect += new TcpClientEvent.OnConnectEventHandler(OnConnect);
            //client.OnSend += new TcpClientEvent.OnSendEventHandler(OnSend);
            //client.OnReceive += new TcpClientEvent.OnReceiveEventHandler(OnReceive);
            //client.OnClose += new TcpClientEvent.OnCloseEventHandler(OnClose);
            SetAppState(AppState.Stoped);
        }

        public void Init_Config()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            MiddlewareDS.Para.EventDBConnectStr = config.AppSettings.Settings["SM_EventDBConnectStr"].Value;
            MiddlewareDS.Para.ServerAddress = config.AppSettings.Settings["SM_ServerAddress"].Value;
            MiddlewareDS.Para.ServerPort = Convert.ToUInt16(config.AppSettings.Settings["SM_ServerPort"].Value);
            MiddlewareDS.Para.SyncIDFlag = Convert.ToUInt16(config.AppSettings.Settings["SM_SyncIDFlag"].Value);
            txtIpAddress.Text = MiddlewareDS.Para.ServerAddress;
            txtPort.Text = Convert.ToString(MiddlewareDS.Para.ServerPort);
        }


        #region Client初始化相关函数

        //HandleResult OnPrepareConnect(TcpClient sender, IntPtr socket)
        //{
        //    string strMsg = string.Format(" > [{0},OnPrepareConnect]", sender.ConnectionId);
        //    AddLog(strMsg);
        //    AddMsg(strMsg);
        //    return HandleResult.Ok;
        //}

        //HandleResult OnConnect(TcpClient sender)
        //{
        //    // 已连接 到达一次
        //    // 如果是异步联接,更新界面状态
        //    //this.Invoke(new ConnectUpdateUiDelegate(ConnectUpdateUi));
        //    string strMsg = string.Format(" > [{0},OnConnect]", sender.ConnectionId);
        //    AddLog(strMsg);
        //    AddMsg(strMsg);
        //    return HandleResult.Ok;
        //}

        //HandleResult OnSend(TcpClient sender, byte[] bytes)
        //{
        //    // 客户端发数据了
        //    string strSend = Encoding.UTF8.GetString(bytes);
        //    string strMsg = string.Format(" > [{0},OnSend] -> ({1} )", sender.ConnectionId, strSend);
        //    AddLog(strMsg);
        //    if (chkSend.Checked)
        //    {
        //        AddMsg(strMsg);
        //    }
        //    return HandleResult.Ok;
        //}

        //HandleResult OnReceive(TcpClient sender, byte[] bytes)
        //{
        //    string strSend = Encoding.UTF8.GetString(bytes);
        //    string strMsg = string.Format(" > [{0},OnReceive] -> ({1} )", sender.ConnectionId, strSend);
        //    AddLog(strMsg);
        //    AddMsg(strMsg);
        //    return HandleResult.Ok;
        //}

        //HandleResult OnClose(TcpClient sender, SocketOperation enOperation, int errorCode)
        //{
        //    if (errorCode == 0)
        //    {
        //        // 连接关闭了
        //        string strMsg = string.Format(" > [{0},OnClose]", sender.ConnectionId);
        //        AddLog(strMsg);
        //        AddMsg(strMsg);
        //    }

        //    else
        //    {    // 出错了
        //        string strMsg = string.Format(" > [{0},OnError] -> OP:{1},CODE:{2}", sender.ConnectionId, enOperation, errorCode);
        //        AddLog(strMsg);
        //        AddMsg(strMsg);
        //    }
        //    this.BeginInvoke(new EventHandler(delegate
        //    {
        //        SetAppState(AppState.Stoped);
        //    }));
        //    return HandleResult.Ok;
        //}

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="msg"></param>


        #endregion
        public void AddLog(string msg)
        {
            LogManager.GetLogger("ServerConnLog").Log(LogLevel.Info, msg);
        }

        void AddMsg(string msg)
        {
            if (this.lbxMsg.InvokeRequired)
            {
                // 很帅的调自己
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

        private void BtnSend_Click(object sender, EventArgs e)
        {
            string send = this.txtSend.Text;
            if (send.Length == 0)
            {
                return;
            }
            SendCmd(send);
            //byte[] bytes = Encoding.Default.GetBytes(send);

            //IntPtr connId = client.ConnectionId;
            //// 发送
            //if (client.Send(bytes, bytes.Length))
            //{
            //    string strMsg = string.Format("$ ({0}) Send OK --> {1}", connId, send);
            //    AddLog(strMsg);
            //    AddMsg(strMsg);
            //}
            //else
            //{
            //    string strMsg = string.Format("$ ({0}) Send Fail --> {1} ({2})", connId, send, bytes.Length);
            //    AddLog(strMsg);
            //    AddMsg(strMsg);
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            //定时获取数据
            if (!client.Connected)//已经连接
            {
                timer1.Enabled = true;
                return;
            }
            DbContext<T_Test1> db = new DbContext<T_Test1>();
            List<T_Test1> Temp_lstEvent = db.GetList(item => item.ID > Para.SyncIDFlag);
            foreach (T_Test1 item in Temp_lstEvent)
            {
                SendCmd(Agreement.GetEventCmd(item));
            }
            timer1.Enabled = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

            string ip = txtIpAddress.Text;
            ushort port = Convert.ToUInt16(txtPort.Text);
            SetAppState(AppState.Starting);
            try
            {
                client.Connect(IPAddress.Parse(ip), port);
                ns = client.GetStream();
                sr = new StreamReader(ns, Encoding.UTF8);
                sw = new StreamWriter(ns, Encoding.UTF8);
                AddLog("Conect OK");
                AddMsg("Conect OK");
                SetAppState(AppState.Started);
            }
            catch
            {
                SetAppState(AppState.Stoped);
                AddLog("Connect Fail");
                AddMsg("Connect Fail");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            client.Close();
            string strMsg = string.Format("$Stop Success");
            AddLog(strMsg);
            AddMsg(strMsg);
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


        /// <summary>
        /// 延时操作_毫秒
        /// </summary>
        /// <param name="Millisecond"></param>
        public static void Delay_Millisecond(int Millisecond)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                Application.DoEvents();
            }
            return;
        }

        public bool SendCmd(string send)
        {
            try
            {
                //ns = client.GetStream();
                //sw = new StreamWriter(ns);
                //sw.Write(send);
                //sw.Flush();
                byte[] byt = Encoding.UTF8.GetBytes(send);
                ns.Write(byt, 0, byt.Length);
                ns.Flush();
                //sw.Close();
                //ns.Flush();
                //ns.Close();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Close();
        }
    }
}
