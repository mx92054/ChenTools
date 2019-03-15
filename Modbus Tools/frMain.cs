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

            lstFunc.SelectedIndex = svr.m_nFunc;
            txtArea.Text = svr.m_sArea;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            svr.m_nProcotol = cbProcotol.SelectedIndex;
            svr.m_sSerPort = cbSerial.SelectedItem.ToString();
            svr.m_nBaudrate = Int32.Parse(cbBaudrate.SelectedItem.ToString());            
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {

        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            dataView.Rows.Clear();

            svr.m_nFunc = lstFunc.SelectedIndex;
            svr.m_sArea = txtArea.Text;

            if (!svr.ProcessFunc())
                return;

            for(int i=0 ; i < svr.m_scanArea.Count; i++)
                for (int j = 0; j < svr.m_aWRAddress[i].Length; j++)
                {
                    if (svr.m_aWRAddress[i][j] == 1)
                    {
                        int no = dataView.Rows.Add();
                        dataView.Rows[no].Cells[0].Value = (svr.m_scanArea[i].start_adr + j).ToString();
                    }
                }
        }
    }
}
