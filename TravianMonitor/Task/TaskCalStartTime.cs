/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-10-11
 * Time: 0:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TravianMonitor
{
	/// <summary>
	/// Description of TaskCalStartTime.
	/// </summary>
	public class TaskCalStartTime : Task
	{
		private DateTime dtArrTime;
		private int nTgX;
		private int nTgY;
		public TaskCalStartTime(DateTime arrTime, int x, int y) : base()
		{
			dtArrTime = arrTime;
			nTgX = x;
			nTgY = y;
			
			bIsForAccounts = false;
			uiType = UIUpdateTypes.VillageList;
			logType = UIUpdateTypes.TroopsMonitorLog;
		}
				
		protected override void DirectExec()
		{
			if (TravianAccessor.TrAcsr.lstAccounts == null)
				return;
			
			foreach (TravianAccount trAccount in TravianAccessor.TrAcsr.lstAccounts)
			{
				if (trAccount.lstVillages == null || trAccount.bIsDead)
					continue;
				
				foreach (TravianVillage trVillage in trAccount.lstVillages)
				{
					int min_speed = trVillage.nMinTroopSpeed;
					
					if (min_speed == 100)
						continue;
					
					double time_cost = 0.00000001;
					double distance =
                    Math.Sqrt((trVillage.nPosX - nTgX) * (trVillage.nPosX - nTgX)
                    + (trVillage.nPosY - nTgY) * (trVillage.nPosY - nTgY));

					int sqrt_mul_X10 = 10 + Convert.ToInt32(trVillage.nSquareLvl);
					
	                if (distance <= 30)
	                {
	                    time_cost = distance * 3600 / min_speed;
	                }
	                else
	                {
	                    time_cost = (distance - 30) * 3600 * 10
                        / (min_speed * sqrt_mul_X10)
                        + 30 * 3600 / (min_speed);
	                }
	                
	                if (time_cost < 0.000001)
	                	continue;
	                
	                trVillage.dtStartTime = dtArrTime.AddSeconds(-time_cost);
				}
			}
			
			TravianAccessor.TrAcsr.UIUpdate(UIUpdateTypes.VillageList);
		}
	}
}
