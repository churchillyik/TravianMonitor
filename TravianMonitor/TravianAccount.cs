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

namespace TravianMonitor
{
	public class TravianVillage
	{
		public int VillageID;
		public int Tribe;
		public int nSquareLvl;
		public int[] Troops = new int[11];
	}
	
	/// <summary>
	/// Description of TravianAccount.
	/// </summary>
	public class TravianAccount
	{
		public List<TravianVillage> lstVillages = new List<TravianVillage>();
		private string strName;
		private string strPassword;
		private TravianWebClient trWebClent = null;
		public TravianAccount(string name, string passwd)
		{
			strName = name;
			strPassword = passwd;
		}
		
	}
}
