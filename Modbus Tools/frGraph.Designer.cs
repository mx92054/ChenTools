namespace Modbus_Tools
{
    partial class frGraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frGraph));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstFmt = new System.Windows.Forms.ListBox();
            this.btnSuspend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstGrp = new System.Windows.Forms.ListBox();
            this.lstAdr = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.zd = new ZedGraph.ZedGraphControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.zd);
            this.splitContainer1.Size = new System.Drawing.Size(1279, 633);
            this.splitContainer1.SplitterDistance = 159;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lstFmt);
            this.groupBox1.Controls.Add(this.btnSuspend);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lstGrp);
            this.groupBox1.Controls.Add(this.lstAdr);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 609);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "曲线";
            // 
            // lstFmt
            // 
            this.lstFmt.FormattingEnabled = true;
            this.lstFmt.ItemHeight = 17;
            this.lstFmt.Location = new System.Drawing.Point(81, 339);
            this.lstFmt.Name = "lstFmt";
            this.lstFmt.Size = new System.Drawing.Size(43, 123);
            this.lstFmt.TabIndex = 5;
            this.lstFmt.DoubleClick += new System.EventHandler(this.lstFmt_DoubleClick);
            // 
            // btnSuspend
            // 
            this.btnSuspend.Location = new System.Drawing.Point(19, 474);
            this.btnSuspend.Name = "btnSuspend";
            this.btnSuspend.Size = new System.Drawing.Size(96, 39);
            this.btnSuspend.TabIndex = 4;
            this.btnSuspend.Text = "暂停";
            this.btnSuspend.UseVisualStyleBackColor = true;
            this.btnSuspend.Click += new System.EventHandler(this.btnSuspend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "趋势曲线";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "地址选择";
            // 
            // lstGrp
            // 
            this.lstGrp.FormattingEnabled = true;
            this.lstGrp.ItemHeight = 17;
            this.lstGrp.Location = new System.Drawing.Point(6, 339);
            this.lstGrp.Name = "lstGrp";
            this.lstGrp.Size = new System.Drawing.Size(69, 123);
            this.lstGrp.TabIndex = 2;
            this.lstGrp.SelectedIndexChanged += new System.EventHandler(this.lstGrp_SelectedIndexChanged);
            this.lstGrp.DoubleClick += new System.EventHandler(this.lstGrp_DoubleClick);
            // 
            // lstAdr
            // 
            this.lstAdr.FormattingEnabled = true;
            this.lstAdr.ItemHeight = 17;
            this.lstAdr.Location = new System.Drawing.Point(6, 41);
            this.lstAdr.Name = "lstAdr";
            this.lstAdr.Size = new System.Drawing.Size(127, 259);
            this.lstAdr.TabIndex = 1;
            this.lstAdr.SelectedIndexChanged += new System.EventHandler(this.lstAdr_SelectedIndexChanged);
            this.lstAdr.DoubleClick += new System.EventHandler(this.lstAdr_DoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(19, 519);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 39);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(19, 564);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 39);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // zd
            // 
            this.zd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zd.IsShowPointValues = false;
            this.zd.Location = new System.Drawing.Point(0, 0);
            this.zd.Name = "zd";
            this.zd.PointValueFormat = "G";
            this.zd.Size = new System.Drawing.Size(1116, 633);
            this.zd.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "符号";
            // 
            // frGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 633);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "趋势曲线";
            this.Load += new System.EventHandler(this.frGraph_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ZedGraph.ZedGraphControl zd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox lstAdr;
        private System.Windows.Forms.ListBox lstGrp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSuspend;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListBox lstFmt;
        private System.Windows.Forms.Label label3;

    }
}