namespace ServerMiddleware
{
    partial class FrmClientTest
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbxMsg = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDBTest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkRece = new System.Windows.Forms.CheckBox();
            this.chkSend = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(3, 11);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(139, 21);
            this.txtIpAddress.TabIndex = 0;
            this.txtIpAddress.Text = "192.168.2.18";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(148, 11);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(57, 21);
            this.txtPort.TabIndex = 0;
            this.txtPort.Text = "6800";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(211, 9);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "连接";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(3, 3);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(637, 21);
            this.txtSend.TabIndex = 2;
            this.txtSend.Text = "$8888@@@8888@@@实验中学@@@明溪商会@@@校园报警@@@紧急求助@@@24.88823@@@119.360012@@@rtsp://172.10." +
    "22.20/video.mts?id=9000233@@@562002@@@350955522001@@@三元分局@@@张先生@@@13799897063|*|" +
    "";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(646, 1);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(292, 9);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "关闭";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(709, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "$报警编号@@@报警号码@@@报警单位@@@报警地址@@@报警类别（如：校园报警、银行报警、公交报警等等）@@@报警内容@@@经度@@@纬度@@@视频地址@@@行" +
    "政区划@@@管辖单位（省厅12位编码）@@@所属分局@@@联系人@@@联系电话|*|";
            // 
            // lbxMsg
            // 
            this.lbxMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxMsg.FormattingEnabled = true;
            this.lbxMsg.ItemHeight = 12;
            this.lbxMsg.Location = new System.Drawing.Point(0, 65);
            this.lbxMsg.Name = "lbxMsg";
            this.lbxMsg.Size = new System.Drawing.Size(724, 423);
            this.lbxMsg.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSend);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 488);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 68);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDBTest);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.chkRece);
            this.panel2.Controls.Add(this.chkSend);
            this.panel2.Controls.Add(this.txtIpAddress);
            this.panel2.Controls.Add(this.txtPort);
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Controls.Add(this.btnStop);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(724, 65);
            this.panel2.TabIndex = 13;
            // 
            // btnDBTest
            // 
            this.btnDBTest.Location = new System.Drawing.Point(373, 9);
            this.btnDBTest.Name = "btnDBTest";
            this.btnDBTest.Size = new System.Drawing.Size(75, 23);
            this.btnDBTest.TabIndex = 9;
            this.btnDBTest.Text = "数据库测试";
            this.btnDBTest.UseVisualStyleBackColor = true;
            this.btnDBTest.Click += new System.EventHandler(this.btnDBTest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "过滤数据";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(231, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(234, 21);
            this.textBox1.TabIndex = 7;
            // 
            // chkRece
            // 
            this.chkRece.AutoSize = true;
            this.chkRece.Checked = true;
            this.chkRece.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRece.Location = new System.Drawing.Point(83, 40);
            this.chkRece.Name = "chkRece";
            this.chkRece.Size = new System.Drawing.Size(72, 16);
            this.chkRece.TabIndex = 6;
            this.chkRece.Text = "接收数据";
            this.chkRece.UseVisualStyleBackColor = true;
            // 
            // chkSend
            // 
            this.chkSend.AutoSize = true;
            this.chkSend.Checked = true;
            this.chkSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSend.Location = new System.Drawing.Point(5, 40);
            this.chkSend.Name = "chkSend";
            this.chkSend.Size = new System.Drawing.Size(72, 16);
            this.chkSend.TabIndex = 6;
            this.chkSend.Text = "发送数据";
            this.chkSend.UseVisualStyleBackColor = true;
            // 
            // FrmClientTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 556);
            this.Controls.Add(this.lbxMsg);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmClientTest";
            this.Text = "服务中间件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbxMsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkSend;
        private System.Windows.Forms.CheckBox chkRece;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnDBTest;
    }
}

