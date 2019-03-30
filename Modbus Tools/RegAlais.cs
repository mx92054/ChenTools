using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace Modbus_Tools
{
    public class RegAlais
    {
        public string[] asFileName;
        public int[] lsNum;
        public string[] lsAlais;
        public int lsLen;

        public RegAlais()
        {
            int i = 0;

            DirectoryInfo folder = new DirectoryInfo(".");
            FileInfo[] afinfo = folder.GetFiles("*.csv");
            asFileName = new string[afinfo.Length];
            foreach (FileInfo finfo in afinfo)
                asFileName[i++] = finfo.Name;

            lsLen = 0;
        }

        public string GetAlais(int nAddr)
        {
            string alais = "";
            for (int i = 0; i < lsLen; i++)
                if (lsNum[i] == nAddr)
                    return lsAlais[i];

            return alais;
        }

        public void ReadCSVFile(string strName)
        {
            string line = "";
            string[] lsStr;
            try
            {
                StreamReader fil = new StreamReader(strName, System.Text.Encoding.Default);

                lsNum = new int[1024];
                lsAlais = new string[1024];
                lsLen = 0;
                while (line != null)
                {
                    line = fil.ReadLine();
                    if (line != null && line.Length > 0)
                    {
                        lsStr = line.Split(',');
                        if (lsStr.Length >= 2)
                        {
                            lsNum[lsLen] = int.Parse(lsStr[0]);
                            lsAlais[lsLen] = lsStr[1];
                            lsLen++;
                        }
                    }
                }

                fil.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
