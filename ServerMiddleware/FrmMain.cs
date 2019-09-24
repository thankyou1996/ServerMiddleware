using HPSocketCS;
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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServerMiddleware
{
    public partial class FrmMain : Form
    {
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
            Init_Config();
            client.OnPrepareConnect += new TcpClientEvent.OnPrepareConnectEventHandler(OnPrepareConnect);
            client.OnConnect += new TcpClientEvent.OnConnectEventHandler(OnConnect);
            client.OnSend += new TcpClientEvent.OnSendEventHandler(OnSend);
            client.OnReceive += new TcpClientEvent.OnReceiveEventHandler(OnReceive);
            client.OnClose += new TcpClientEvent.OnCloseEventHandler(OnClose);
        }

        public void Init_Config()
        {
            string file = System.Windows.Forms.Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            MiddlewareDS.Para.EventDBConnectStr = config.AppSettings.Settings["EventDBConnectStr"].Value;
            MiddlewareDS.Para.ServerAddress = config.AppSettings.Settings["ServerAddress"].Value;
            MiddlewareDS.Para.ServerPort = Convert.ToUInt16(config.AppSettings.Settings["ServerPort"].Value);
            txtAddress.Text = MiddlewareDS.Para.ServerAddress;
            txtPort.Text = Convert.ToString(MiddlewareDS.Para.ServerPort);
        }


        #region Client初始化相关函数

        HandleResult OnPrepareConnect(TcpClient sender, IntPtr socket)
        {
            string strMsg = string.Format(" > [{0},OnPrepareConnect]", sender.ConnectionId);
            AddMsg(strMsg);
            return HandleResult.Ok;
        }

        HandleResult OnConnect(TcpClient sender)
        {
            // 已连接 到达一次

            // 如果是异步联接,更新界面状态
            //this.Invoke(new ConnectUpdateUiDelegate(ConnectUpdateUi));
            string strMsg = string.Format(" > [{0},OnConnect]", sender.ConnectionId);
            AddMsg(strMsg);
            return HandleResult.Ok;
        }

        HandleResult OnSend(TcpClient sender, byte[] bytes)
        {
            // 客户端发数据了
            string strSend = Encoding.UTF8.GetString(bytes);
            string strMsg = string.Format(" > [{0},OnSend] -> ({1} )", sender.ConnectionId, strSend);
            AddMsg(strMsg);
            return HandleResult.Ok;
        }

        HandleResult OnReceive(TcpClient sender, byte[] bytes)
        {
            string strSend = Encoding.UTF8.GetString(bytes);
            string strMsg = string.Format(" > [{0},OnReceive] -> ({1} )", sender.ConnectionId, strSend);
            AddMsg(strMsg);
            return HandleResult.Ok;
        }

        HandleResult OnClose(TcpClient sender, SocketOperation enOperation, int errorCode)
        {
            if (errorCode == 0)
            {
                // 连接关闭了
                AddMsg(string.Format(" > [{0},OnClose]", sender.ConnectionId));
            }

            else
            {    // 出错了
                AddMsg(string.Format(" > [{0},OnError] -> OP:{1},CODE:{2}", sender.ConnectionId, enOperation, errorCode));
            }
            return HandleResult.Ok;
        }

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="msg"></param>
        void AddMsg(string msg)
        {
            Console.WriteLine(msg);
            LogManager.GetLogger("ServerConnLog").Log(LogLevel.Info, msg);
        }
        #endregion

        private void Button1_Click(object sender, EventArgs e)
        {
            string ip = txtAddress.Text;
            ushort port = Convert.ToUInt16(txtPort.Text);
            if (client.Connect(ip, port, false))
            {
                AddMsg("Conect OK");
            }
            else
            {
                AddMsg("Connect Fail");
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            string send = this.txtSend.Text;
            if (send.Length == 0)
            {
                return;
            }

            byte[] bytes = Encoding.Default.GetBytes(send);
            IntPtr connId = client.ConnectionId;

            // 发送
            if (client.Send(bytes, bytes.Length))
            {
                AddMsg(string.Format("$ ({0}) Send OK --> {1}", connId, send));
            }
            else
            {
                AddMsg(string.Format("$ ({0}) Send Fail --> {1} ({2})", connId, send, bytes.Length));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //定时获取数据
            if (!client.IsStarted)//已经连接
            {
                return;
            }
            DbContext<CK_ALARM> db = new DbContext<CK_ALARM>();
            List<CK_ALARM> Temp_lstEvent = db.GetList();
            foreach (CK_ALARM item in Temp_lstEvent)
            {
                string send = Agreement.GetEventCmd(item);
                byte[] bytes = Encoding.UTF8.GetBytes(send);
                client.Send(bytes, bytes.Length);
            }
        }
    }
}
