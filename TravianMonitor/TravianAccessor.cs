using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TravianMonitor
{
    class GlobalConfig
    {
        public string strSvrURL = "";
        public int nInterval;
    }

    partial class TravianAccessor
    {
        static public TravianAccessor TrAcsr = null;

        public GlobalConfig glbCfg = new GlobalConfig();
        private Dictionary<string, string> Options = new Dictionary<string, string>();
        
        public TravianAccessor()
        {
            LoadOptions();

            if (Options.ContainsKey("SvrURL"))
            {
                glbCfg.strSvrURL = Options["SvrURL"];
            }

            if (Options.ContainsKey("Interval"))
            {
                glbCfg.nInterval = Convert.ToInt32(Options["Interval"]);
            }
        }

        private void LoadOptions()
        {
            if (!File.Exists("Options.ini"))
            {
                return;
            }

            FileStream fs = new FileStream("Options.ini", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                string[] opt = sr.ReadLine().Split('=');
                if (opt.Length == 2)
                {
                    Options.Add(opt[0].Trim(), opt[1].Trim());
                }
            }
            sr.Close();
        }

        public void SaveOptions()
        {
            if (Options.ContainsKey("SvrURL"))
            {
                Options["SvrURL"] = glbCfg.strSvrURL;
            }
            else
            {
                Options.Add("SvrURL", glbCfg.strSvrURL);
            }

            if (Options.ContainsKey("Interval"))
            {
                Options["Interval"] = glbCfg.nInterval.ToString();
            }
            else
            {
                Options.Add("Interval", glbCfg.nInterval.ToString());
            }

            FileStream fs = new FileStream("Options.ini", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            foreach (KeyValuePair<string, string> pair in Options)
            {
                sw.WriteLine("{0}={1}",
                    pair.Key,
                    pair.Value
                );
            }
            sw.Close();
        }
    }
}
