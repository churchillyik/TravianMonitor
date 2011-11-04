/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-11-3
 * Time: 4:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TravianMonitor
{
	public class Target
	{
		public int nCoordX;
		public int nCoordY;
		public int nZ
		{
			get
			{
				return 801 * (400 -nCoordY) + (nCoordX + 401);
			}
			set
			{
				nCoordX = (value - 1) % 801 - 400;
				nCoordY = 400 - (value - 1) / 801;
			}
		}
		
		public Target()
		{}
		public Target(int nX, int nY)
		{
			nCoordX = nX;
			nCoordY = nY;
		}
	}
	/// <summary>
	/// Description of ReinTgs.
	/// </summary>
	public class ReinTgs
	{
		private List<Target> lstTgs;
		public ReinTgs()
		{
			lstTgs = new List<Target>();
		}
		
		public List<Target> LoadReinTgs()
		{
			if (!File.Exists("Reinforcement"))
            {
                return lstTgs;
            }

            FileStream fs = new FileStream("Reinforcement", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            lstTgs.Clear();
            while (!sr.EndOfStream)
            {
                string[] coord = sr.ReadLine().Split('|');
                if (coord.Length == 2)
                {
                	int nX = Convert.ToInt32(coord[0].Trim());
                	int nY = Convert.ToInt32(coord[1].Trim());
                	lstTgs.Add(new Target(nX, nY));
                }
            }
            sr.Close();
            
            return lstTgs;
		}
		
		private void SaveReinTgs()
		{
			FileStream fs = new FileStream("Reinforcement", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            foreach (Target tg in lstTgs)
            {
                sw.WriteLine("{0}|{1}",
                    tg.nCoordX,
                    tg.nCoordY
                );
            }
            sw.Close();
		}
		
		public List<Target> AddReinTg(int nX, int nY)
		{
			if (nX == 0 && nY == 0)
			{
				return lstTgs;
			}
			
			foreach (Target tg in lstTgs)
			{
				if (tg.nCoordX == nX && tg.nCoordY == nY)
				{
					return lstTgs;
				}
			}
			
			Target new_tg = new Target(nX, nY);
			lstTgs.Add(new_tg);
			
			SaveReinTgs();
			return lstTgs;
		}
		
		public List<Target> DelReinTg(int nSel)
		{
			lstTgs.RemoveAt(nSel);
			SaveReinTgs();
			return lstTgs;
		}
	}
}
