using HPSocketCS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            client.OnPrepareConnect += new TcpClientEvent.OnPrepareConnectEventHandler(OnPrepareConnect);
            client.OnConnect += new TcpClientEvent.OnConnectEventHandler(OnConnect);
            client.OnSend += new TcpClientEvent.OnSendEventHandler(OnSend);
            client.OnReceive += new TcpClientEvent.OnReceiveEventHandler(OnReceive);
            client.OnClose += new TcpClientEvent.OnCloseEventHandler(OnClose);
        }

        #region 初始化相关函数

        HandleResult OnPrepareConnect(TcpClient sender, IntPtr socket)
        {
            return HandleResult.Ok;
        }

        HandleResult OnConnect(TcpClient sender)
        {
            // 已连接 到达一次

            // 如果是异步联接,更新界面状态
            //this.Invoke(new ConnectUpdateUiDelegate(ConnectUpdateUi));

            AddMsg(string.Format(" > [{0},OnConnect]", sender.ConnectionId));

            return HandleResult.Ok;
        }

        HandleResult OnSend(TcpClient sender, byte[] bytes)
        {
            // 客户端发数据了
            AddMsg(string.Format(" > [{0},OnSend] -> ({1} bytes)", sender.ConnectionId, bytes.Length));

            return HandleResult.Ok;
        }

        HandleResult OnReceive(TcpClient sender, byte[] bytes)
        {

            AddMsg(string.Format(" > [{0},OnReceive] -> ({1} bytes)", sender.ConnectionId, bytes.Length));
            return HandleResult.Ok;
        }

        HandleResult OnClose(TcpClient sender, SocketOperation enOperation, int errorCode)
        {
            if (errorCode == 0)
                // 连接关闭了
                AddMsg(string.Format(" > [{0},OnClose]", sender.ConnectionId));
            else
                // 出错了
                AddMsg(string.Format(" > [{0},OnError] -> OP:{1},CODE:{2}", sender.ConnectionId, enOperation, errorCode));

            // 通知界面,只处理了连接错误,也没进行是不是连接错误的判断,所以有错误就会设置界面
            // 生产环境请自己控制
            //this.Invoke(new SetAppStateDelegate(SetAppState), AppState.Stoped);

            return HandleResult.Ok;
        }

        /// <summary>
        /// 往listbox加一条项目
        /// </summary>
        /// <param name="msg"></param>
        void AddMsg(string msg)
        {
            Console.WriteLine(msg);

            //if (this.lbxMsg.InvokeRequired)
            //{
            //    // 很帅的调自己
            //    this.lbxMsg.Invoke(AddMsgDelegate, msg);
            //}
            //else
            //{
            //    if (this.lbxMsg.Items.Count > 100)
            //    {
            //        this.lbxMsg.Items.RemoveAt(0);
            //    }
            //    this.lbxMsg.Items.Add(msg);
            //    this.lbxMsg.TopIndex = this.lbxMsg.Items.Count - (int)(this.lbxMsg.Height / this.lbxMsg.ItemHeight);
            //}
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
    }
}
