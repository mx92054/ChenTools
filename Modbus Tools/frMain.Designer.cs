namespace Modbus_Tools
{
    partial class frMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frMain));
            this.splMain = new System.Windows.Forms.SplitContainer();
            this.labErr = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ckHex = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numScanCycle = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFlash = new System.Windows.Forms.Button();
            this.ckAlais = new System.Windows.Forms.CheckBox();
            this.cbFileName = new System.Windows.Forms.ComboBox();
            this.labStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numStation = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSuspend = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.lstFunc = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numPortNo = new System.Windows.Forms.NumericUpDown();
            this.txtIPAdr = new System.Windows.Forms.TextBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cbBaudrate = new System.Windows.Forms.ComboBox();
            this.labPara2 = new System.Windows.Forms.Label();
            this.cbSerial = new System.Windows.Forms.ComboBox();
            this.labPara1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProcotol = new System.Windows.Forms.ComboBox();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labErrTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.Panel1.SuspendLayout();
            this.splMain.Panel2.SuspendLayout();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScanCycle)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStation)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPortNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // splMain
            // 
            this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splMain.Location = new System.Drawing.Point(0, 0);
            this.splMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splMain.Name = "splMain";
            // 
            // splMain.Panel1
            // 
            this.splMain.Panel1.Controls.Add(this.labErrTime);
            this.splMain.Panel1.Controls.Add(this.labErr);
            this.splMain.Panel1.Controls.Add(this.picLogo);
            this.splMain.Panel1.Controls.Add(this.btnExit);
            this.splMain.Panel1.Controls.Add(this.groupBox4);
            this.splMain.Panel1.Controls.Add(this.groupBox3);
            this.splMain.Panel1.Controls.Add(this.labStatus);
            this.splMain.Panel1.Controls.Add(this.groupBox2);
            this.splMain.Panel1.Controls.Add(this.groupBox1);
            this.splMain.Panel1.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // splMain.Panel2
            // 
            this.splMain.Panel2.Controls.Add(this.dataView);
            this.splMain.Size = new System.Drawing.Size(1126, 1628);
            this.splMain.SplitterDistance = 216;
            this.splMain.TabIndex = 0;
            // 
            // labErr
            // 
            this.labErr.AutoSize = true;
            this.labErr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labErr.Location = new System.Drawing.Point(26, 1401);
            this.labErr.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labErr.Name = "labErr";
            this.labErr.Size = new System.Drawing.Size(135, 33);
            this.labErr.TabIndex = 6;
            this.labErr.Text = "No error";
            // 
            // picLogo
            // 
            this.picLogo.Image = global::Modbus_Tools.Properties.Resources.idsse;
            this.picLogo.Location = new System.Drawing.Point(24, 1438);
            this.picLogo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(186, 190);
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::Modbus_Tools.Properties.Resources.system_log_out;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(276, 1494);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 128);
            this.btnExit.TabIndex = 5;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ckHex);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.numScanCycle);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(24, 1196);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox4.Size = new System.Drawing.Size(400, 178);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "显示参数";
            // 
            // ckHex
            // 
            this.ckHex.AutoSize = true;
            this.ckHex.Location = new System.Drawing.Point(32, 124);
            this.ckHex.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ckHex.Name = "ckHex";
            this.ckHex.Size = new System.Drawing.Size(227, 37);
            this.ckHex.TabIndex = 1;
            this.ckHex.Text = "十六进制显示";
            this.ckHex.UseVisualStyleBackColor = true;
            this.ckHex.CheckedChanged += new System.EventHandler(this.ckHex_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 33);
            this.label3.TabIndex = 5;
            // 
            // numScanCycle
            // 
            this.numScanCycle.Location = new System.Drawing.Point(186, 50);
            this.numScanCycle.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.numScanCycle.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numScanCycle.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numScanCycle.Name = "numScanCycle";
            this.numScanCycle.Size = new System.Drawing.Size(202, 40);
            this.numScanCycle.TabIndex = 0;
            this.numScanCycle.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numScanCycle.ValueChanged += new System.EventHandler(this.numScanCycle_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "扫描时间";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFlash);
            this.groupBox3.Controls.Add(this.ckAlais);
            this.groupBox3.Controls.Add(this.cbFileName);
            this.groupBox3.Location = new System.Drawing.Point(24, 964);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox3.Size = new System.Drawing.Size(400, 202);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "变量注释";
            // 
            // btnFlash
            // 
            this.btnFlash.Enabled = false;
            this.btnFlash.Location = new System.Drawing.Point(238, 130);
            this.btnFlash.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnFlash.Name = "btnFlash";
            this.btnFlash.Size = new System.Drawing.Size(150, 46);
            this.btnFlash.TabIndex = 2;
            this.btnFlash.Text = "刷新";
            this.btnFlash.UseVisualStyleBackColor = true;
            this.btnFlash.Click += new System.EventHandler(this.btnFlash_Click);
            // 
            // ckAlais
            // 
            this.ckAlais.AutoSize = true;
            this.ckAlais.Location = new System.Drawing.Point(18, 134);
            this.ckAlais.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ckAlais.Name = "ckAlais";
            this.ckAlais.Size = new System.Drawing.Size(107, 37);
            this.ckAlais.TabIndex = 1;
            this.ckAlais.Text = "启用";
            this.ckAlais.UseVisualStyleBackColor = true;
            this.ckAlais.CheckedChanged += new System.EventHandler(this.ckAlais_CheckedChanged);
            // 
            // cbFileName
            // 
            this.cbFileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFileName.FormattingEnabled = true;
            this.cbFileName.Location = new System.Drawing.Point(18, 46);
            this.cbFileName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbFileName.Name = "cbFileName";
            this.cbFileName.Size = new System.Drawing.Size(366, 41);
            this.cbFileName.TabIndex = 0;
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Location = new System.Drawing.Point(256, 1438);
            this.labStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(60, 33);
            this.labStatus.TabIndex = 2;
            this.labStatus.Text = "0/0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numStation);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnSuspend);
            this.groupBox2.Controls.Add(this.btnScan);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtArea);
            this.groupBox2.Controls.Add(this.lstFunc);
            this.groupBox2.Location = new System.Drawing.Point(24, 420);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Size = new System.Drawing.Size(400, 532);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "通信参数";
            // 
            // numStation
            // 
            this.numStation.Location = new System.Drawing.Point(184, 212);
            this.numStation.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.numStation.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numStation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStation.Name = "numStation";
            this.numStation.Size = new System.Drawing.Size(204, 40);
            this.numStation.TabIndex = 1;
            this.numStation.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 216);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 33);
            this.label5.TabIndex = 9;
            this.label5.Text = "站地址：";
            // 
            // btnSuspend
            // 
            this.btnSuspend.Enabled = false;
            this.btnSuspend.Location = new System.Drawing.Point(238, 462);
            this.btnSuspend.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSuspend.Name = "btnSuspend";
            this.btnSuspend.Size = new System.Drawing.Size(150, 46);
            this.btnSuspend.TabIndex = 4;
            this.btnSuspend.Text = "暂停";
            this.btnSuspend.UseVisualStyleBackColor = true;
            this.btnSuspend.Click += new System.EventHandler(this.btnSuspend_Click);
            // 
            // btnScan
            // 
            this.btnScan.Enabled = false;
            this.btnScan.Location = new System.Drawing.Point(12, 462);
            this.btnScan.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(150, 46);
            this.btnScan.TabIndex = 3;
            this.btnScan.Text = "开始";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 266);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(330, 33);
            this.label4.TabIndex = 4;
            this.label4.Text = "地址范围(可用，-符号)";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(12, 306);
            this.txtArea.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtArea.Multiline = true;
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(372, 140);
            this.txtArea.TabIndex = 2;
            // 
            // lstFunc
            // 
            this.lstFunc.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFunc.FormattingEnabled = true;
            this.lstFunc.ItemHeight = 33;
            this.lstFunc.Items.AddRange(new object[] {
            "01 读线圈状态",
            "02 读离散输入",
            "03 读保持寄存器",
            "04 读输入寄存器"});
            this.lstFunc.Location = new System.Drawing.Point(12, 46);
            this.lstFunc.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lstFunc.Name = "lstFunc";
            this.lstFunc.Size = new System.Drawing.Size(372, 136);
            this.lstFunc.TabIndex = 0;
            this.lstFunc.SelectedIndexChanged += new System.EventHandler(this.lstFunc_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numPortNo);
            this.groupBox1.Controls.Add(this.txtIPAdr);
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.cbBaudrate);
            this.groupBox1.Controls.Add(this.labPara2);
            this.groupBox1.Controls.Add(this.cbSerial);
            this.groupBox1.Controls.Add(this.labPara1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbProcotol);
            this.groupBox1.Location = new System.Drawing.Point(24, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(400, 384);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "接口参数";
            // 
            // numPortNo
            // 
            this.numPortNo.Location = new System.Drawing.Point(184, 224);
            this.numPortNo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.numPortNo.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numPortNo.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numPortNo.Name = "numPortNo";
            this.numPortNo.Size = new System.Drawing.Size(204, 40);
            this.numPortNo.TabIndex = 2;
            this.numPortNo.Value = new decimal(new int[] {
            502,
            0,
            0,
            0});
            // 
            // txtIPAdr
            // 
            this.txtIPAdr.Location = new System.Drawing.Point(84, 158);
            this.txtIPAdr.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtIPAdr.Name = "txtIPAdr";
            this.txtIPAdr.Size = new System.Drawing.Size(300, 40);
            this.txtIPAdr.TabIndex = 1;
            this.txtIPAdr.Text = "127.0.0.1";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(238, 322);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(150, 46);
            this.btnDisconnect.TabIndex = 6;
            this.btnDisconnect.Text = "断开";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(36, 322);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(150, 46);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cbBaudrate
            // 
            this.cbBaudrate.FormattingEnabled = true;
            this.cbBaudrate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbBaudrate.Location = new System.Drawing.Point(152, 224);
            this.cbBaudrate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbBaudrate.Name = "cbBaudrate";
            this.cbBaudrate.Size = new System.Drawing.Size(232, 41);
            this.cbBaudrate.TabIndex = 4;
            // 
            // labPara2
            // 
            this.labPara2.AutoSize = true;
            this.labPara2.Location = new System.Drawing.Point(30, 240);
            this.labPara2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labPara2.Name = "labPara2";
            this.labPara2.Size = new System.Drawing.Size(105, 33);
            this.labPara2.TabIndex = 3;
            this.labPara2.Text = "波特率";
            // 
            // cbSerial
            // 
            this.cbSerial.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSerial.FormattingEnabled = true;
            this.cbSerial.Location = new System.Drawing.Point(36, 162);
            this.cbSerial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSerial.Name = "cbSerial";
            this.cbSerial.Size = new System.Drawing.Size(348, 36);
            this.cbSerial.TabIndex = 3;
            // 
            // labPara1
            // 
            this.labPara1.AutoSize = true;
            this.labPara1.Location = new System.Drawing.Point(30, 120);
            this.labPara1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labPara1.Name = "labPara1";
            this.labPara1.Size = new System.Drawing.Size(135, 33);
            this.labPara1.TabIndex = 2;
            this.labPara1.Text = "串口选择";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "协议类型";
            // 
            // cbProcotol
            // 
            this.cbProcotol.FormattingEnabled = true;
            this.cbProcotol.Items.AddRange(new object[] {
            "RTU",
            "ASCII",
            "TCP"});
            this.cbProcotol.Location = new System.Drawing.Point(184, 44);
            this.cbProcotol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbProcotol.Name = "cbProcotol";
            this.cbProcotol.Size = new System.Drawing.Size(200, 41);
            this.cbProcotol.TabIndex = 0;
            this.cbProcotol.SelectedIndexChanged += new System.EventHandler(this.cbProcotol_SelectedIndexChanged);
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address,
            this.Value,
            this.Desc});
            this.dataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataView.Location = new System.Drawing.Point(0, 0);
            this.dataView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataView.Name = "dataView";
            this.dataView.RowTemplate.Height = 20;
            this.dataView.Size = new System.Drawing.Size(906, 1628);
            this.dataView.TabIndex = 0;
            this.dataView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataView_CellDoubleClick);
            this.dataView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataView_CellEndEdit);
            // 
            // Address
            // 
            this.Address.HeaderText = "地址";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 40;
            // 
            // Value
            // 
            this.Value.HeaderText = "值";
            this.Value.Name = "Value";
            this.Value.Width = 60;
            // 
            // Desc
            // 
            this.Desc.HeaderText = "描述";
            this.Desc.Name = "Desc";
            this.Desc.ReadOnly = true;
            this.Desc.Width = 200;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labErrTime
            // 
            this.labErrTime.AutoSize = true;
            this.labErrTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labErrTime.Location = new System.Drawing.Point(26, 1368);
            this.labErrTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labErrTime.Name = "labErrTime";
            this.labErrTime.Size = new System.Drawing.Size(135, 33);
            this.labErrTime.TabIndex = 7;
            this.labErrTime.Text = "No error";
            // 
            // frMain
            // 
            this.AcceptButton = this.btnScan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 1628);
            this.Controls.Add(this.splMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frMain";
            this.Text = "Modbus Tools  (Written by chenming  chenm@idsse.ac.cn)";
            this.Load += new System.EventHandler(this.frMain_Load);
            this.splMain.Panel1.ResumeLayout(false);
            this.splMain.Panel1.PerformLayout();
            this.splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScanCycle)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPortNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splMain;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbProcotol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labPara1;
        private System.Windows.Forms.ComboBox cbBaudrate;
        private System.Windows.Forms.Label labPara2;
        private System.Windows.Forms.ComboBox cbSerial;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstFunc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Button btnSuspend;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.NumericUpDown numStation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.NumericUpDown numPortNo;
        private System.Windows.Forms.TextBox txtIPAdr;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnFlash;
        private System.Windows.Forms.CheckBox ckAlais;
        private System.Windows.Forms.ComboBox cbFileName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox ckHex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numScanCycle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labErr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc;
        private System.Windows.Forms.Label labErrTime;
    }
}

