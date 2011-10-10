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
		public int nID;
		public int nPosX;
		public int nPosY;
		public string strName;
		public int nSquareLvl;
		public int[] Troops = new int[11];
		public string TroopString
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < Troops.Length; i++)
    			{
					if (i + 1 == Troops.Length)
					{
						sb.Append(Troops[i]);
					}
					else
					{
						sb.Append(Troops[i] + ", ");
					}
    			}
				return sb.ToString();
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
		
		public TravianAccount(string name, string passwd)
		{
			strName = name;
			strPassword = passwd;
		}
		
	}
}
