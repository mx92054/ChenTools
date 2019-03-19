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
        public GraphPane gp;
        public int cycle ;

        public int ticks;
        private bool bFirst = true;
        private int address;
        private string caption;

        public frGraph()
        {
            InitializeComponent();
        }

        public void StartDraw( int Addr,int nCycle)
        {
            cycle = nCycle;
            address = Addr;
            switch (parentFrm.svr.m_nFunc)
            {
                case 0:
                    caption = "Coil " + address.ToString();
                    break;
                case 1:
                    caption = "Directe " + address.ToString();
                    break;
                case 2:
                    caption = "Register " + address.ToString();
                    break;
                case 3:
                    caption = "Input " + address.ToString();
                    break;
            }
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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bFirst)
            {
                PointPairList ppl = new PointPairList();
                gp.AddCurve(caption, ppl, Color.Blue, SymbolType.None);
                timer1.Interval = cycle;
                bFirst = false;
            }

            int adr_grp = 0;
            int adr_offset = 0;

            if (parentFrm.svr.FindPosintion(address, ref adr_grp, ref adr_offset))
            {
                CurveItem curve = gp.CurveList[0];
                if (parentFrm.svr.m_nFunc > 1)
                    curve.AddPoint((double)(ticks++), (double)parentFrm.svr.m_sValue[adr_grp][adr_offset]);
                else
                {
                    if (parentFrm.svr.m_bValue[adr_grp][adr_offset])
                        curve.AddPoint((double)(ticks++), 1.0);
                    else
                        curve.AddPoint((double)(ticks++), 0.0);
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
                    CurveItem curve = gp.CurveList[0];
                    for (int i = 0; i < curve.Points.Count; i++)
                    {
                        txtLine = string.Format("{0},{1}", curve.Points[i].X, curve.Points[i].Y);
                        fil.WriteLine(txtLine);
                    }

                    fil.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A error happend when saving data!", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
    }
}
