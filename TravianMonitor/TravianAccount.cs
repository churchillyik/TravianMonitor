/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-11-5
 * Time: 0:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace TravianMonitor
{
	public class TravianVillage
	{
		public TravianAccount UpCall;
		public int nID;
		public int nPosX;
		public int nPosY;
		public string strName;
		public int nSquareLvl;
		public int[] Troops = new int[11];
		public DateTime dtStartTime = DateTime.MinValue;
		
		public string TroopString
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				int nTribe = UpCall.nTribe;
				List<TroopData> lstTd = TravianData.dicDefenseTroop[nTribe];
				for (int i = 0; i < lstTd.Count; i++)
				{
					TroopData td = lstTd[i];
					if (i == lstTd.Count - 1)
					{
						sb.Append(td.strName + " " + Troops[td.nSeq]);
					}
					else
					{
						sb.Append(td.strName + " " + Troops[td.nSeq] + "，");
					}
				}
				return sb.ToString();
			}
		}
		
		public int nMinTroopSpeed
		{
			get
			{
				int nTribe = UpCall.nTribe;
				List<TroopData> lstTd = TravianData.dicDefenseTroop[nTribe];
				int min_speed = 100;
				foreach (TroopData td in lstTd)
				{
					if (Troops[td.nSeq] != 0 && td.nSpeed < min_speed)
					{
						min_speed = td.nSpeed;
					}
				}
				return min_speed;
			}
		}
	}
	
	/// <summary>
	/// Description of TravianAccount.
	/// </summary>
	public class TravianAccount
	{
		public int nTribe;
		public List<TravianVillage> lstVillages = new List<TravianVillage>();
		
		public string strName;
		public string strPassword;
		
		public TravianWebClient trWebClient = new TravianWebClient();
		
		public TaskStatus tskStatus = new TaskStatus();
		public int nLoginFailtimes = 0;
		public static int nLoginFailLimit = 2;
		public bool bIsDead
		{
			get { return (nLoginFailtimes >= TravianAccount.nLoginFailLimit); }
		}
		
		public TravianAccount(string name, string passwd)
		{
			strName = name;
			strPassword = passwd;
		}
		
	}
}
