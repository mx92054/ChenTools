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

namespace Modbus_Tools
{
    class adr_area:IComparable
    {
        public ushort start_adr{get; set;}
        public ushort end_adr { get; set; }

        public int CompareTo(object obj)
        {
            int result;
            try
            {
                adr_area adr = obj as adr_area;
                if (this.start_adr < adr.start_adr)
                    result = 0;
                else
                    result = 1;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    [Serializable]
    class Equipment
    {
        public int m_nProcotol;     //协议类型
        public string m_sSerPort;   //串口端口号
        public int m_nBaudrate;     //波特率
        public string m_sIPAddress; //tcp地址
        public int m_nIPPort;       //tcp端口号

        public int m_nFunc;         //功能号
        public string m_sArea;      //读取范围定义
        public string m_sLine;
        [NonSerialized]
        List<adr_area> m_listArea; 

        public Equipment()
        {
            m_nProcotol = 0;
            m_sSerPort = "COM1";
            m_nBaudrate = 9600;
            m_sIPAddress = "192.168.0.254";
            m_nIPPort = 502;

            m_nFunc = 0;
            m_sArea = "0-10,10-20";

        }

        ~Equipment()
        {
            SerialHelper.SerializeMethod(this);
        }

        //对读写区域的字符串进行处理
        public bool ProcessFunc()
        {
            string[] tmp ;
            int x,y ;
            m_sLine = "Preocess Result:" ;
            m_listArea = new List<adr_area>() ;

            try
            {

                string[] astr = m_sArea.Split(',');
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

                        m_sLine += x.ToString() + "--" + x.ToString() + " | ";
                    }
                    else if ( tmp.Length == 2)
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

                        m_sLine += x.ToString() + "--" + y.ToString() + " | ";
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
            return true ;
        }


        private void OragnizeArea()
        {
            ushort[] start_area = new ushort[100];
            ushort[] end_area = new ushort[100];
            int cur = 0;
            int flag;

            foreach (adr_area t in m_listArea)
            {
                if (cur == 0)
                {
                    start_area[cur] = t.start_adr;
                    end_area[cur] = t.end_adr;
                    cur++;
                    continue;
                }
                flag = 0;
                for (int i = 0; i < cur; i++)
                {
                    //调整当前的起始指针，避免重复
                    if (t.start_adr > start_area[i] && t.start_adr < end_area[i] && t.end_adr >= end_area[i])
                        t.start_adr = end_area[i];

                    //调整当前的结束指针，避免重复
                    if (t.end_adr < end_area[i] && t.end_adr > start_area[i] && t.start_adr <= start_area[i])
                        t.end_adr = start_area[i];

                    //情况1  当前包含在里面
                    if (t.start_adr >= start_area[i] && t.end_adr <= end_area[i])
                    {
                        flag = 1;
                        break;
                    }
                    //情况2 起始地址小，结束地址已包含，总和小于120
                    if (t.start_adr <= start_area[i] && t.end_adr <= end_area[i] && end_area[i] - t.start_adr <= 120)
                    {
                        flag = 1;
                        start_area[i] = t.start_adr;
                        break;
                    }

                    //情况3 起始地址小，结束地址大，总和小于120
                    if (t.start_adr <= start_area[i] && t.end_adr > end_area[i] && t.end_adr - t.start_adr <= 120)
                    {
                        flag = 1;
                        start_area[i] = t.start_adr;
                        end_area[i] = t.end_adr;
                        break;
                    }

                    //情况4 起始地址包含，结束地址大，总和小于120
                    if (t.start_adr > start_area[i] && t.end_adr > end_area[i] && t.end_adr - start_area[i] <= 120)
                    {
                        flag = 1;
                        end_area[i] = t.end_adr;
                        break;
                    }
                }

                //未发现匹配的
                if (flag == 0)
                {
                    start_area[cur] = t.start_adr;
                    end_area[cur] = t.end_adr;
                    cur++;
                }
            }            

            string s = "Result :";
            for (int i = 0; i < cur; i++)
            {
                s += start_area[i].ToString() + "--" + end_area[i].ToString() + " | ";
            }
            MessageBox.Show(s);           
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
