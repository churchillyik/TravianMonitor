/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-11-5
 * Time: 0:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TravianMonitor
{
	/// <summary>
	/// Description of TravianAccount.
	/// </summary>
	public class TravianAccount
	{
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
