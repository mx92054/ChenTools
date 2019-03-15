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
        private Equipment svr;

        public frMain()
        {
            InitializeComponent();
        }

        private void frMain_Load(object sender, EventArgs e)
        {
            SerialHelper.ReserializeMethod(ref svr);
            //svr = new Equipment();

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

            lstFunc.SelectedIndex = svr.m_nFunc;
            txtArea.Text = svr.m_sArea;

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
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            dataView.Rows.Clear();

            svr.m_nFunc = lstFunc.SelectedIndex;
            svr.m_sArea = txtArea.Text;
            svr.m_nStation = (int)numStation.Value;

            if (!svr.ProcessFunc())
                return;

            
            for(int i=0 ; i < svr.m_scanArea.Count; i++)
                for (int j = 0; j < svr.m_nRWFlag[i].Length; j++)
                {
                    if (svr.m_nRWFlag[i][j] == 1)
                    {
                        int no = dataView.Rows.Add();
                        dataView.Rows[no].Cells[0].Value = (svr.m_scanArea[i].start_adr + j).ToString();
                    }
                }

            svr.MB_Scan();

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int nCur = 0;

            for (int i = 0; i < svr.m_scanArea.Count; i++)
                for (int j = 0; j < svr.m_nRWFlag[i].Length; j++)
                {
                    if (svr.m_nRWFlag[i][j] == 1)
                    {
                        if ( svr.m_nFunc > 1 )
                            dataView.Rows[nCur++].Cells[1].Value = svr.m_sValue[i][j].ToString();
                        else
                            dataView.Rows[nCur++].Cells[1].Value = svr.m_bValue[i][j].ToString();
                    }
                }
            labStatus.Text = svr.nSucc.ToString() + "/" + svr.nFail.ToString();
        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            svr.bWorking = false;
            timer1.Enabled = false;
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
    }
}
