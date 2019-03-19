using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Modbus_Tools
{
    public partial class frMain : Form
    {
        public Equipment svr;
        private bool bScan;
        private RegAlais rAlais;
        private frGraph fp;
        private int err_disp_timer ;
        private int err_couter;
        private int ticks = 0;

        public frMain()
        {
            InitializeComponent();
        }

        private void frMain_Load(object sender, EventArgs e)
        {
            try
            {
                SerialHelper.ReserializeMethod(ref svr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始设置函数出现异常，采用默认配置！");
                svr = new Equipment();
            }

            string[] astr = PortEnum.MulGetHardwareInfo(PortEnum.HardwareEnum.Win32_PnPEntity, "Name");
            foreach (string vPortName in astr)
            {
                cbSerial.Items.Add(vPortName);
            }
            cbSerial.SelectedItem = svr.m_sSerPort;

            cbProcotol.SelectedIndex = svr.m_nProcotol;
            cbBaudrate.SelectedItem = svr.m_nBaudrate.ToString();

            txtIPAdr.Text = svr.m_sIPAddress;
            numPortNo.Value = svr.m_nIPPort;
            numStation.Value = svr.m_nStation;

            lstFunc.SelectedIndex = svr.m_nFunc;
            txtArea.Text = svr.m_sArea[svr.m_nFunc];

            if (svr.m_nProcotol == 2)
            {
                labPara1.Text = "网络地址";
                labPara2.Text = "端口号";
                cbBaudrate.Visible = false;
                cbSerial.Visible = false;
                txtIPAdr.Visible = true;
                numPortNo.Visible = true;
            }
            else
            {
                labPara1.Text = "串口选择";
                labPara2.Text = "波特率";
                cbBaudrate.Visible = true;
                cbSerial.Visible = true;
                txtIPAdr.Visible = false;
                numPortNo.Visible = false;
            }

            rAlais = new RegAlais();
            foreach (string s in rAlais.asFileName)
                cbFileName.Items.Add(s);

            ckAlais.Checked = svr.bAlais;
            cbFileName.SelectedItem = svr.sAlaisFile;
            if (ckAlais.Checked)
            {
                rAlais.ReadCSVFile(svr.sAlaisFile);
                btnFlash.Enabled = true;
            }
            else
                btnFlash.Enabled = false;

            timer1.Interval = svr.m_nCycle;
            numScanCycle.Value = svr.m_nCycle;
            ckHex.Checked = svr.bHex;

            err_disp_timer = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            bool bSucc;

            svr.m_nProcotol = cbProcotol.SelectedIndex;
            if (svr.m_nProcotol == 2)
            {
                svr.m_sIPAddress = txtIPAdr.Text;
                svr.m_nIPPort = (int)numPortNo.Value;
                bSucc = svr.MB_Connect(svr.m_sIPAddress, svr.m_nIPPort);
            }
            else
            {
                svr.m_sSerPort = cbSerial.SelectedItem.ToString();
                svr.m_nBaudrate = Int32.Parse(cbBaudrate.SelectedItem.ToString());
                string comx = cbSerial.SelectedItem.ToString();
                int s1 = comx.IndexOf('(');
                int s2 = comx.IndexOf(')');
                comx = comx.Substring(s1 + 1, s2 - s1 - 1);
                int nPort = Int32.Parse(cbBaudrate.SelectedItem.ToString());
                bSucc = svr.MB_Connect(comx, nPort);
            }

            if (!bSucc) 
                MessageBox.Show("连接Modbus主机出现故障!");
            else
            {
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                btnScan.Enabled = true;
                btnSuspend.Enabled = true;
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            svr.MB_Close();
            btnConnect.Enabled = true ;
            btnDisconnect.Enabled = false;
            btnScan.Enabled = false;
            btnSuspend.Enabled = false;
            bScan = false;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            svr.m_nFunc = lstFunc.SelectedIndex;
            svr.m_sArea[svr.m_nFunc] = txtArea.Text;
            svr.m_nStation = (int)numStation.Value;

            if (!svr.ProcessFunc())
                return;

            dataView.Rows.Clear();
           
            for(int i=0 ; i < svr.m_scanArea.Count; i++)
                for (int j = 0; j < svr.m_nRWFlag[i].Length; j++)
                {
                    if (svr.m_nRWFlag[i][j] == 1)
                    {
                        int no = dataView.Rows.Add();
                        int adr = svr.m_scanArea[i].start_adr + j ;
                        dataView.Rows[no].Cells[0].Value = adr.ToString();
                        if (ckAlais.Checked)
                            dataView.Rows[no].Cells[2].Value = rAlais.GetAlais(adr);
                    }
                }

            svr.MB_Scan();

            err_couter = 0;
            timer1.Enabled = true;
            bScan = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int nCur = 0;

            if (!svr.ScanOnce())
            {
                labErr.Text = svr.err_msg;
                err_disp_timer = 10000;
                err_couter++;
                if (err_couter > 3)
                {
                    timer1.Enabled = false;
                }
            }
            else
            {
                if (err_disp_timer > 0)
                {
                    err_disp_timer -= timer1.Interval;
                    if (err_disp_timer <= 0)
                        labErr.Text = "No error";
                }  
                
                err_couter = 0;
                ticks++;
                for (int i = 0; i < svr.m_scanArea.Count; i++)
                    for (int j = 0; j < svr.m_nRWFlag[i].Length; j++)
                    {
                        if (svr.m_nRWFlag[i][j] == 1)
                        {
                            if (svr.m_nFunc > 1)
                                dataView.Rows[nCur++].Cells[1].Value = svr.m_sValue[i][j].ToString(svr.bHex ? "X4" : "");
                            else
                                dataView.Rows[nCur++].Cells[1].Value = svr.m_bValue[i][j].ToString();
                        }
                    }
            }
            labStatus.Text = svr.nSucc.ToString() + "/" + svr.nFail.ToString();
        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            svr.bWorking = false;
            timer1.Enabled = false;
            bScan = false;
        }

        private void cbProcotol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProcotol.SelectedIndex == 2)
            {
                labPara1.Text = "网络地址";
                labPara2.Text = "端口号";
                cbBaudrate.Visible = false;
                cbSerial.Visible = false;
                txtIPAdr.Visible = true;
                numPortNo.Visible = true;
            }
            else
            {
                labPara1.Text = "串口选择";
                labPara2.Text = "波特率";
                cbBaudrate.Visible = true;
                cbSerial.Visible = true;
                txtIPAdr.Visible = false;
                numPortNo.Visible = false;
            }
        }

        private void dataView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1 || !bScan)
                return;

            try
            {
                short val = Int16.Parse(dataView.Rows[e.RowIndex].Cells[1].Value.ToString());
                svr.In_Queue(e.RowIndex, val);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ckAlais_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAlais.Checked && cbFileName.SelectedIndex >= 0)
            {
                svr.sAlaisFile = cbFileName.SelectedItem.ToString();
                rAlais.ReadCSVFile(svr.sAlaisFile);
                btnFlash.Enabled = true;
            }
            else
                btnFlash.Enabled = false;

            svr.bAlais = ckAlais.Checked;
        }

        private void btnFlash_Click(object sender, EventArgs e)
        {
            if (!bScan)
                return;

            if (!ckAlais.Checked || cbFileName.SelectedIndex < 0)
                return;

            svr.sAlaisFile = cbFileName.SelectedItem.ToString();
            rAlais.ReadCSVFile(svr.sAlaisFile);

            int counter = 0;
            for (int i = 0; i < svr.m_scanArea.Count; i++)
                for (int j = 0; j < svr.m_nRWFlag[i].Length; j++)
                {
                    if (svr.m_nRWFlag[i][j] == 1)
                    {
                        int adr = svr.m_scanArea[i].start_adr + j;
                        dataView.Rows[counter++].Cells[2].Value = rAlais.GetAlais(adr);
                    }
                }
        }

        private void lstFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtArea.Text = svr.m_sArea[lstFunc.SelectedIndex];
        }

        private void ckHex_CheckedChanged(object sender, EventArgs e)
        {
            svr.bHex = ckHex.Checked;
        }

        private void numScanCycle_ValueChanged(object sender, EventArgs e)
        {
            svr.m_nCycle = (int)numScanCycle.Value;
            timer1.Interval = svr.m_nCycle;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fp = new frGraph();
            fp.parentFrm = this;

            int addr = Int32.Parse(dataView.Rows[e.RowIndex].Cells[0].Value.ToString());
            fp.StartDraw(addr,svr.m_nCycle);
            fp.ticks = ticks;
            fp.Show();
        }
    }
}
