/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-10-10
 * Time: 22:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TravianMonitor
{
	public class TroopData
	{
		public int nSeq;
		public string strName;
		public int nSpeed;
		
		public TroopData(int seq, string name, int speed)
		{
			nSeq = seq;
			strName = name;
			nSpeed = speed;
		}
	}
	/// <summary>
	/// Description of TravianData.
	/// </summary>
	public class TravianData
	{
		public static string[] strTribeName = {"罗马", "条顿", "高卢"};
		public static Dictionary<int, List<TroopData>> dicDefenseTroop = new Dictionary<int, List<TroopData>>();
		
		public static void InitTRData()
		{
			List<TroopData> lst_t1 = new List<TroopData>();
			lst_t1.Add(new TroopData(0, "古罗", 6));
			lst_t1.Add(new TroopData(1, "禁卫", 5));
			lst_t1.Add(new TroopData(5, "将骑", 10));

			List<TroopData> lst_t2 = new List<TroopData>();
			lst_t2.Add(new TroopData(1, "矛兵", 7));
			lst_t2.Add(new TroopData(4, "圣骑", 10));
			lst_t2.Add(new TroopData(5, "日骑", 9));
			
			List<TroopData> lst_t3 = new List<TroopData>();
			lst_t3.Add(new TroopData(0, "方阵", 7));
			lst_t3.Add(new TroopData(4, "德骑", 16));
			lst_t3.Add(new TroopData(5, "海骑", 13));

			dicDefenseTroop.Add(1, lst_t1);
			dicDefenseTroop.Add(2, lst_t2);
			dicDefenseTroop.Add(3, lst_t3);
		}
	}
}
