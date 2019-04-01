using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ZedGraph;

namespace Modbus_Tools
{
    public partial class frGraph : Form
    {
        public frMain parentFrm;
        public RegAlais parentAlais;
        public GraphPane gp;
        public int cycle ;

        public int ticks;
        private bool bFirst = true;
        private int address;
        private string caption;
        private int curColor;
        private Color[] colorlist = new Color[10]
        {
            Color.LightBlue,        Color.LightCoral,
            Color.LightCyan,Color.LightGoldenrodYellow,
            Color.LightGray,Color.LightGreen,
            Color.LightPink,Color.LightSalmon,
            Color.LightSeaGreen,Color.LightSkyBlue
        };

        public frGraph()
        {
            InitializeComponent();
            curColor = 0;
        }

        public void StartDraw(int nCycle)
        {
            cycle = nCycle;
            switch (parentFrm.svr.m_nFunc)
            {
                case 0:
                    caption = "Coil ";
                    break;
                case 1:
                    caption = "Directe ";
                    break;
                case 2:
                    caption = "Register ";
                    break;
                case 3:
                    caption = "Input ";
                    break;
            }
        }

        public void SetCycle(int ntimerval)
        {
            timer1.Interval = ntimerval;
        }
            

        private void frGraph_Load(object sender, EventArgs e)
        {
            zd.Location = new Point(670, 67);

            GraphPane pan = zd.GraphPane;

            pan.XAxis.Title = "Counter";
            pan.XAxis.IsShowGrid = true;
            pan.XAxis.TitleFontSpec.Size = 5;
            pan.XAxis.ScaleFontSpec.Size = 5;
            pan.XAxis.Color = Color.WhiteSmoke;
            pan.XAxis.GridColor = Color.WhiteSmoke;

            pan.YAxis.IsShowGrid = true;
            pan.YAxis.TitleFontSpec.Size = 5;
            pan.YAxis.ScaleFontSpec.Size = 5;
            pan.YAxis.IsShowTitle = false;
            pan.YAxis.Color = Color.WhiteSmoke;
            pan.YAxis.GridColor = Color.WhiteSmoke;

            // Fill the axis area with a gradient                
            pan.AxisFill = new Fill(Color.Black, Color.Black, 90F);
            // Fill the pane area with a solid color
            pan.PaneFill = new Fill(Color.White);


            gp = zd.GraphPane;
            gp.IsShowTitle = false;
            gp.Legend.FontSpec.Size = 5;

            gp.AxisFill.Color = Color.White;

            //-----------------------------------------------------
            for (int i = 0; i < parentFrm.svr.m_scanArea.Count; i++)
                for (int j = 0; j < parentFrm.svr.m_nRWFlag[i].Length; j++)
                {
                    if (parentFrm.svr.m_nRWFlag[i][j] == 1)
                    {
                        lstAdr.Items.Add((parentFrm.svr.m_scanArea[i].start_adr + j).ToString());
                    }
                }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bFirst)
            {
                timer1.Interval = cycle;
                bFirst = false;
            }

            int adr_grp = 0;
            int adr_offset = 0;
            int adr;

            for(int i = 0 ; i < lstGrp.Items.Count ; i++)
            {
                adr = Int32.Parse(lstGrp.Items[i].ToString());
                if (parentFrm.svr.FindPosintion(adr, ref adr_grp, ref adr_offset))
                {
                    CurveItem curve = gp.CurveList[i];
                    if (parentFrm.svr.m_nFunc > 1)
                        curve.AddPoint((double)(ticks++), (double)parentFrm.svr.m_sValue[adr_grp][adr_offset]);
                    else
                    {
                        if (parentFrm.svr.m_bValue[adr_grp][adr_offset])
                            curve.AddPoint((double)(ticks++), 1.0);
                        else
                            curve.AddPoint((double)(ticks++), 0.0);
                    }
                }
                zd.AxisChange();
                zd.Refresh();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string txtLine;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text file(*.txt)|*.txt|All file|*.*";      //设置文件类型
            sfd.FileName = caption;
            sfd.DefaultExt = "txt";//设置默认格式（可以不设）
            sfd.AddExtension = true;//设置自动在文件名中添加扩展名
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter fil = new StreamWriter(sfd.FileName);
                    for (int no = 0; no < lstGrp.Items.Count; no++)
                    {
                        fil.WriteLine("--------" + caption + lstGrp.Items[no].ToString() + "---------");
                        CurveItem curve = gp.CurveList[no];
                        for (int i = 0; i < curve.Points.Count; i++)
                        {
                            txtLine = string.Format("{0},{1}", curve.Points[i].X, curve.Points[i].Y);
                            fil.WriteLine(txtLine);
                        }
                    }

                    fil.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A error happend when saving data! " + ex.Message, "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void lstAdr_DoubleClick(object sender, EventArgs e)
        {
            string s = lstAdr.SelectedItem.ToString();
            foreach(object it in lstGrp.Items)
                if ( it.ToString() == s )
                    return ;

            lstGrp.Items.Add(s);
            lstGrp.SelectedIndex = lstGrp.Items.Count - 1;
            PointPairList ppl = new PointPairList();
            gp.AddCurve(caption + s, ppl,colorlist[curColor], SymbolType.None);
            curColor++;
        }

        private void lstGrp_DoubleClick(object sender, EventArgs e)
        {
            gp.CurveList.RemoveAt(lstGrp.SelectedIndex);
            lstGrp.Items.RemoveAt(lstGrp.SelectedIndex);
        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                btnSuspend.Text = "恢复";
            }
            else
            {
                timer1.Enabled = true;
                btnSuspend.Text = "暂停";
            }
        }

        private void lstAdr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAdr.SelectedItem == null )
                return;

            int adr = Int32.Parse(lstAdr.SelectedItem.ToString());
            string str = parentAlais.GetAlais(adr) ;
            if (str != "")
            {
                toolTip1.Active = true;
                toolTip1.SetToolTip(lstAdr, str);
            }
            else
                toolTip1.Active = false;
        }

        private void lstGrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGrp.SelectedItem == null)
                return;

            int adr = Int32.Parse(lstGrp.SelectedItem.ToString());
            string str = parentAlais.GetAlais(adr);
            if (str != "")
            {
                toolTip1.Active = true;
                toolTip1.SetToolTip(lstGrp, str);
            }
            else
                toolTip1.Active = false;
        }
    }
}
