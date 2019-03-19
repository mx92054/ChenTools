using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Threading;
using WSMBS;
using WSMBT;


namespace Modbus_Tools
{
    public class adr_area : IComparable<adr_area>
    {
        private ushort adr1;
        private ushort adr2;
        public int length { get; set;}
        public int index { get; set; }

        public ushort start_adr
        {
            get
            {
                return adr1;
            }
            set
            {
                adr1 = value;
                length = adr2 - adr1 + 1;
            }
        }

        public ushort end_adr
        {
            get
            {
                return adr2;
            }

            set
            {
                adr2 = value;
                length = adr2 - adr1 + 1;
            }
        }

        public int CompareTo(adr_area other)
        {
            if (null == other)
                return 1;

            return this.adr1.CompareTo(other.adr1);
        }

        public adr_area(ushort i = 0, ushort j = 0)
        {
            adr1 = i;
            adr2 = j;
            length = adr2 - adr1 + 1;
        }
    }

    public class WrReg_Coil
    {
        public ushort adr { get; set; }
        public short val { get; set; }
        public int cmd { get; set; }
        public WrReg_Coil(int nCmd = 0, ushort usAdr = 0, short sVal = 0)
        {
            cmd = nCmd;
            adr = usAdr;
            val = sVal;
        }
    }

    /// <summary>
    /// 设备连接类
    /// </summary>
    [Serializable]
    public class Equipment
    {
        public int m_nProcotol;     //协议类型
        public string m_sSerPort;   //串口端口号
        public int m_nBaudrate;     //波特率
        public string m_sIPAddress; //tcp地址
        public int m_nIPPort;       //tcp端口号

        public int m_nFunc;         //功能号
        public string[] m_sArea;      //读取范围定义
        public int m_nStation;       //主机地址

        public string sAlaisFile;   //注释文件名
        public bool bAlais;         //注释是否启用
        public int m_nCycle;
        public bool bHex;

        [NonSerialized]
        public int nSucc;   //成功通信次数
        [NonSerialized]
        public int nFail;   //失败通信次数

        [NonSerialized]
        public List<adr_area> m_listArea;

        [NonSerialized]
        public List<adr_area> m_scanArea;

        [NonSerialized]
        public short[][] m_sValue;     //读写值寄存器

        [NonSerialized]
        public bool[][] m_bValue;     //读写值开关量

        [NonSerialized]
        public int[][] m_nRWFlag;      //读写标记

        [NonSerialized]
        private WSMBSControl ser_svr;

        [NonSerialized]
        private WSMBTControl tcp_svr;

        [NonSerialized]
        public bool bWorking;

        [NonSerialized]
        Queue<WrReg_Coil> queue;

        [NonSerialized]
        public string err_msg;

        /// <summary>
        /// 初始化函数
        /// </summary>
        public Equipment()
        {
            m_nProcotol = 0;
            m_sSerPort = "COM1";
            m_nBaudrate = 9600;
            m_sIPAddress = "192.168.0.254";
            m_nIPPort = 502;

            m_nFunc = 0;

            m_sArea = new string[4];
            for (int i = 0; i < 4; i++)
                m_sArea[i] = "0-99";

            sAlaisFile = "";
            bAlais = false;

            m_nCycle = 500;
            bHex = false;
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~Equipment()
        {
            SerialHelper.SerializeMethod(this);
        }

        /// <summary>
        /// 端口连接函数
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="nPort"></param>
        /// <returns></returns>
        public bool MB_Connect(string sName, int nPort)
        {
            if (m_nProcotol == 2)
            {
                tcp_svr = new WSMBTControl();
                tcp_svr.LicenseKey("2222222222222222222222222AAF2");
               return (WSMBT.Result.SUCCESS == tcp_svr.Connect(sName, nPort));
            }

            ser_svr = new WSMBSControl();
            ser_svr.LicenseKey("2222222222222222222222222F3AA");
            ser_svr.PortName = sName;
            ser_svr.Parity = Parity.None;
            ser_svr.DataBits = 8;
            ser_svr.StopBits = 1;
            ser_svr.BaudRate = nPort;
            return (WSMBS.Result.SUCCESS == ser_svr.Open());
        }

        /// <summary>
        /// 端口关闭函数
        /// </summary>
        public void MB_Close()
        {
            bWorking = false;

            if (m_nProcotol == 2)
                tcp_svr.Close();
            else
                ser_svr.Close();
        }

        /// <summary>
        /// 开始进行寄存器读取
        /// </summary>
        public void MB_Scan()
        {
            /*
            task = new Thread(new ParameterizedThreadStart(Scan_Task));
            task.IsBackground = true;
            bWorking = true;
            task.Start(this);
            */

            queue = new Queue<WrReg_Coil>();
            err_msg = "No error";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private static void Scan_Task(object obj)
        {
            Equipment eq = obj as Equipment;

            WSMBS.Result sres;
            WSMBT.Result tres;

            while( eq.bWorking)
            {
                sres = WSMBS.Result.SUCCESS;
                tres = WSMBT.Result.SUCCESS;
                for (int Index = 0; Index < eq.m_scanArea.Count; Index++)
                {
                    if (eq.m_nProcotol == 2)
                    {
                        //write register
                        if (eq.queue.Count > 0)
                        {

                            WrReg_Coil node = eq.queue.Dequeue();
                            bool val = (node.val != 0);
                            if (node.cmd == 0)
                                tres = eq.tcp_svr.WriteSingleCoil((byte)eq.m_nStation, node.adr, val);
                            if (node.cmd == 2)
                                tres = eq.tcp_svr.WriteSingleRegister((byte)eq.m_nStation, node.adr, node.val);
                        }
                        else
                        {
                            //read register
                            switch (eq.m_nFunc)
                            {
                                case 0:
                                    tres = eq.tcp_svr.ReadCoils((byte)eq.m_nStation, eq.m_scanArea[Index].start_adr, (ushort)eq.m_scanArea[Index].length, eq.m_bValue[Index]);
                                    break;
                                case 1:
                                    tres = eq.tcp_svr.ReadDiscreteInputs((byte)eq.m_nStation, eq.m_scanArea[Index].start_adr, (ushort)eq.m_scanArea[Index].length, eq.m_bValue[Index]);
                                    break;
                                case 2:
                                    tres = eq.tcp_svr.ReadHoldingRegisters((byte)eq.m_nStation, eq.m_scanArea[Index].start_adr, (ushort)eq.m_scanArea[Index].length, eq.m_sValue[Index]);
                                    break;
                                case 3:
                                    tres = eq.tcp_svr.ReadInputRegisters((byte)eq.m_nStation, eq.m_scanArea[Index].start_adr, (ushort)eq.m_scanArea[Index].length, eq.m_sValue[Index]);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        //write register
                        if (eq.queue.Count > 0)
                        {

                            WrReg_Coil node = eq.queue.Dequeue();
                            bool val = (node.val != 0);
                            if (node.cmd == 0)
                                sres = eq.ser_svr.WriteSingleCoil((byte)eq.m_nStation, node.adr, val);
                            if (node.cmd == 2)
                                sres = eq.ser_svr.WriteSingleRegister((byte)eq.m_nStation, node.adr, node.val);
                        }
                        else
                        {
                            //read register
                            switch (eq.m_nFunc)
                            {
                                case 0:
                                    sres = eq.ser_svr.ReadCoils((byte)eq.m_nStation, eq.m_scanArea[Index].start_adr, (ushort)eq.m_scanArea[Index].length, eq.m_bValue[Index]);
                                    break;
                                case 1:
                                    sres = eq.ser_svr.ReadDiscreteInputs((byte)eq.m_nStation, eq.m_scanArea[Index].start_adr, (ushort)eq.m_scanArea[Index].length, eq.m_bValue[Index]);
                                    break;
                                case 2:
                                    sres = eq.ser_svr.ReadHoldingRegisters((byte)eq.m_nStation, eq.m_scanArea[Index].start_adr, (ushort)eq.m_scanArea[Index].length, eq.m_sValue[Index]);
                                    break;
                                case 3:
                                    sres = eq.ser_svr.ReadInputRegisters((byte)eq.m_nStation, eq.m_scanArea[Index].start_adr, (ushort)eq.m_scanArea[Index].length, eq.m_sValue[Index]);
                                    break;
                            }
                        }
                    }

                    if (sres == WSMBS.Result.SUCCESS && tres == WSMBT.Result.SUCCESS)
                        eq.nSucc++;
                    else
                        eq.nFail++;
                }
            }
        }

        public bool ScanOnce()
        {
            bool bRet = true ;

            WSMBS.Result sres;
            WSMBT.Result tres;

            sres = WSMBS.Result.SUCCESS;
            tres = WSMBT.Result.SUCCESS;
            for (int Index = 0; Index < m_scanArea.Count; Index++)
            {
                if (m_nProcotol == 2)
                {
                    //write register
                    if (queue.Count > 0)
                    {

                        WrReg_Coil node = queue.Dequeue();
                        bool val = (node.val != 0);
                        if (node.cmd == 0)
                            tres = tcp_svr.WriteSingleCoil((byte)m_nStation, node.adr, val);
                        if (node.cmd == 2)
                            tres = tcp_svr.WriteSingleRegister((byte)m_nStation, node.adr, node.val);
                    }
                    else
                    {
                        //read register
                        switch (m_nFunc)
                        {
                            case 0:
                                tres = tcp_svr.ReadCoils((byte)m_nStation, m_scanArea[Index].start_adr, (ushort)m_scanArea[Index].length, m_bValue[Index]);
                                break;
                            case 1:
                                tres = tcp_svr.ReadDiscreteInputs((byte)m_nStation, m_scanArea[Index].start_adr, (ushort)m_scanArea[Index].length, m_bValue[Index]);
                                break;
                            case 2:
                                tres = tcp_svr.ReadHoldingRegisters((byte)m_nStation, m_scanArea[Index].start_adr, (ushort)m_scanArea[Index].length, m_sValue[Index]);
                                break;
                            case 3:
                                tres = tcp_svr.ReadInputRegisters((byte)m_nStation, m_scanArea[Index].start_adr, (ushort)m_scanArea[Index].length, m_sValue[Index]);
                                break;
                        }
                    }
                    if ( tres == WSMBT.Result.SUCCESS)
                        nSucc++;
                    else
                    {
                        nFail++;
                        err_msg = tres.ToString();
                        bRet = false;
                    }
                }
                else
                {
                    //write register
                    if (queue.Count > 0)
                    {

                        WrReg_Coil node = queue.Dequeue();
                        bool val = (node.val != 0);
                        if (node.cmd == 0)
                            sres = ser_svr.WriteSingleCoil((byte)m_nStation, node.adr, val);
                        if (node.cmd == 2)
                            sres = ser_svr.WriteSingleRegister((byte)m_nStation, node.adr, node.val);
                    }
                    else
                    {
                        //read register
                        switch (m_nFunc)
                        {
                            case 0:
                                sres = ser_svr.ReadCoils((byte)m_nStation, m_scanArea[Index].start_adr, (ushort)m_scanArea[Index].length, m_bValue[Index]);
                                break;
                            case 1:
                                sres = ser_svr.ReadDiscreteInputs((byte)m_nStation,m_scanArea[Index].start_adr, (ushort)m_scanArea[Index].length, m_bValue[Index]);
                                break;
                            case 2:
                                sres = ser_svr.ReadHoldingRegisters((byte)m_nStation, m_scanArea[Index].start_adr, (ushort)m_scanArea[Index].length, m_sValue[Index]);
                                break;
                            case 3:
                                sres = ser_svr.ReadInputRegisters((byte)m_nStation, m_scanArea[Index].start_adr, (ushort)m_scanArea[Index].length, m_sValue[Index]);
                                break;
                        }
                        if (sres == WSMBS.Result.SUCCESS )
                            nSucc++;
                        else
                        {
                            nFail++;
                            err_msg = sres.ToString();
                            bRet = false ;
                        }                  
                    }
                }
            }
            return bRet ;
        }

        public void In_Queue(int nIndex, short uVal)
        {
            int grp = 0;
            int offset = 0;

            if ( FindPosintion(nIndex, ref grp, ref offset))
            {
                WrReg_Coil wr = new WrReg_Coil(m_nFunc, (ushort)(m_scanArea[grp].start_adr + offset), uVal);
                queue.Enqueue(wr) ;
            }
        }


        public bool FindPosintion(int nAddr, ref int nGrp, ref int nOffset)
        {
            for (int i = 0; i < m_scanArea.Count; i++)
                for (int j = 0; j < m_nRWFlag[i].Length; j++)
                {
                    if (m_nRWFlag[i][j] == 1)
                    {
                        if ((m_scanArea[i].start_adr + j) == nAddr)
                        {
                            nGrp = i;
                            nOffset = j;
                            return true ;
                        }
                    }
                }

            return false;
        }

        /// <summary>+
        /// 对读写区域的字符串进行处理
        /// </summary>
        /// <returns></returns>
        public bool ProcessFunc()
        {
            string[] tmp;
            int x, y;
            m_listArea = new List<adr_area>();

            try
            {
                string[] astr = m_sArea[m_nFunc].Split(',');
                foreach (string s in astr)
                {
                    tmp = s.Split('-');
                    if (tmp.Length > 2)
                    {
                        MessageBox.Show("Parameter Error! (" + s + ")");
                        return false; ;
                    }
                    else if (tmp.Length == 1)
                    {
                        x = Int32.Parse(tmp[0]);
                        adr_area adr1 = new adr_area();
                        adr1.start_adr = (ushort)x;
                        adr1.end_adr = (ushort)x;
                        m_listArea.Add(adr1);
                    }
                    else if (tmp.Length == 2)
                    {
                        x = Int32.Parse(tmp[0]);
                        y = Int32.Parse(tmp[1]);
                        if (Math.Abs(x - y) > 120)
                        {
                            MessageBox.Show("Parameter Error! (" + s + ")");
                            return false; ;
                        }
                        adr_area adr1 = new adr_area();
                        if (x < y)
                        {
                            adr1.start_adr = (ushort)x;
                            adr1.end_adr = (ushort)y;
                        }
                        else
                        {
                            adr1.start_adr = (ushort)y;
                            adr1.end_adr = (ushort)x;
                        }
                        m_listArea.Add(adr1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Parameter Error! (" + ex.Message + ")");
                return false;
            }

            m_listArea.Sort();
            OragnizeArea();
            return true;
        }

        /// <summary>
        /// 组织存储区域
        /// </summary>
        private void OragnizeArea()
        {
            ushort start_area;
            ushort end_area;
            int flag;
            adr_area node ;
            adr_area t = new adr_area();

            m_scanArea = new List<adr_area>();


            for(int index = 0 ; index < m_listArea.Count; index++ )
            {
                t.start_adr = m_listArea[index].start_adr ;
                t.end_adr = m_listArea[index].end_adr ;
                
                flag = 0;                 
                for (int i = 0; i < m_scanArea.Count; i++)
                {
                    start_area = m_scanArea[i].start_adr;
                    end_area = m_scanArea[i].end_adr;

                    //调整当前的起始指针，避免重复
                    if (t.start_adr > start_area && t.start_adr < end_area && t.end_adr >= end_area)
                        t.start_adr = end_area;

                    //调整当前的结束指针，避免重复
                    if (t.end_adr < end_area && t.end_adr > start_area && t.start_adr <= start_area)
                        t.end_adr = start_area;

                    //情况1  当前包含在里面
                    if (t.start_adr >= start_area && t.end_adr <= end_area)
                    {
                        flag = 1;
                        m_listArea[index].index = i ;
                        break;
                    }
                    //情况2 起始地址小，结束地址已包含，总和小于120
                    if (t.start_adr <= start_area && t.end_adr <= end_area && end_area - t.start_adr <= 120)
                    {
                        flag = 1;
                        m_listArea[index].index = i ;
                        m_scanArea[i].start_adr = t.start_adr;
                        break;
                    }

                    //情况3 起始地址小，结束地址大，总和小于120
                    if (t.start_adr <= start_area && t.end_adr > end_area && t.end_adr - t.start_adr <= 120)
                    {
                        flag = 1;
                        m_listArea[index].index = i ;
                        m_scanArea[i].start_adr = t.start_adr;
                        m_scanArea[i].end_adr = t.end_adr;
                        break;
                    }

                    //情况4 起始地址包含，结束地址大，总和小于120
                    if (t.start_adr > start_area && t.end_adr > end_area && t.end_adr - start_area <= 120)
                    {
                        flag = 1;
                        m_listArea[index].index = i ;
                        m_scanArea[i].end_adr = t.end_adr;
                        break;
                    }
                }

                //未发现匹配的
                if (flag == 0)
                {
                    node = new adr_area(t.start_adr, t.end_adr);
                    m_listArea[index].index = m_scanArea.Count ;
                    m_scanArea.Add(node);
                }
            }

            //申请内存
            m_sValue = new short[m_scanArea.Count][];
            m_bValue = new bool[m_scanArea.Count][];
            m_nRWFlag = new int[m_scanArea.Count][];

            for (int i = 0; i < m_scanArea.Count; i++)
            {
                m_sValue[i] = new short[m_scanArea[i].length];
                m_bValue[i] = new bool[m_scanArea[i].length];
                m_nRWFlag[i] = new int[m_scanArea[i].length];
            }

            for (int i = 0; i < m_listArea.Count; i++)
                for (int j = m_listArea[i].start_adr; j <= m_listArea[i].end_adr; j++)
                    m_nRWFlag[m_listArea[i].index][j - m_scanArea[m_listArea[i].index].start_adr] = 1;
        }
    }

    class SerialHelper
    {
        public static void ReserializeMethod(ref Equipment eq)
        {
            //反序列化
            using (FileStream fs = new FileStream("1.bin", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                eq = bf.Deserialize(fs) as Equipment;
            }
        }

        public static void SerializeMethod(Equipment listPers)
        {
            //序列化
            using (FileStream fs = new FileStream("1.bin", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, listPers);
            }
        }
    }

}
