/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-9-13
 * Time: 16:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TravianMonitor
{
	/// <summary>
	/// Description of GlobalConfig.
	/// </summary>
	public class GlobalConfig
	{
		public string strSvrURL
		{
			get
			{
				if (Options.ContainsKey("SvrURL"))
	            {
	                return Options["SvrURL"];
	            }
				else
				{
					return "";
				}
			}
		}
		
        public int nInterval
        {
			get
			{
				if (Options.ContainsKey("Interval"))
	            {
					return Convert.ToInt32(Options["Interval"]);
	            }
				else
				{
					return 0;
				}
			}
		}
        
        public int nReturnDelay
        {
			get
			{
				if (Options.ContainsKey("ReturnDelay"))
	            {
					return Convert.ToInt32(Options["ReturnDelay"]);
	            }
				else
				{
					return 0;
				}
			}
		}
        
        private Dictionary<string, string> Options = new Dictionary<string, string>();
        
		public GlobalConfig()
		{			
			LoadOptions();
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

        public void SaveOptions(string strURL, string strInterval, string strReturnDelay)
        {
            if (Options.ContainsKey("SvrURL"))
            {
                Options["SvrURL"] = strURL;
            }
            else
            {
                Options.Add("SvrURL", strURL);
            }

            if (Options.ContainsKey("Interval"))
            {
                Options["Interval"] = strInterval;
            }
            else
            {
                Options.Add("Interval", strInterval);
            }
            
            if (Options.ContainsKey("ReturnDelay"))
            {
                Options["ReturnDelay"] = strReturnDelay;
            }
            else
            {
                Options.Add("ReturnDelay", strReturnDelay);
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
