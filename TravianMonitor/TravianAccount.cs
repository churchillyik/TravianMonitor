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
		public int nID;
		public int nPosX;
		public int nPosY;
		public string strName;
		public int nSquareLvl;
		public int[] Troops = new int[11];
	}
	
	/// <summary>
	/// Description of TravianAccount.
	/// </summary>
	public class TravianAccount
	{
		public int nTribe;
		public List<TravianVillage> lstVillages = new List<TravianVillage>();
		public List<Task> lstTask = new List<Task>();
		
		public string strName;
		public string strPassword;
		
		public TravianWebClient trWebClient = null;
		
		public TravianAccount(string name, string passwd)
		{
			strName = name;
			strPassword = passwd;
			
			trWebClient = new TravianWebClient();
		}
		
	}
}
