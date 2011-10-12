/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-10-13
 * Time: 3:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TravianMonitor
{
	/// <summary>
	/// Description of TaskAddToTroopSending.
	/// </summary>
	public class TaskAddToTroopSending : Task
	{
		List<int> lstTravianVillageSelected = null;
		
		public TaskAddToTroopSending(List<int> lstTVSel) : base()
		{
			lstTravianVillageSelected = lstTVSel;
			
			bIsForAccounts = false;
			uiType = UIUpdateTypes.TroopSendingList;
			logType = UIUpdateTypes.TroopsMonitorLog;
		}
		
		protected override void DirectExec()
		{
			if (TravianAccessor.TrAcsr.lstAccounts == null)
				return;
			
			List<TravianVillage> lstAllVillages = new List<TravianVillage>();
			foreach (TravianAccount trAccount in TravianAccessor.TrAcsr.lstAccounts)
			{
				if (trAccount.lstVillages == null || trAccount.bIsDead)
					continue;
				
				foreach (TravianVillage trVillage in trAccount.lstVillages)
				{
					lstAllVillages.Add(trVillage);
				}
			}
			
			foreach (int nSel in lstTravianVillageSelected)
			{
				if (nSel >= lstAllVillages.Count)
					continue;
				
				TravianVillage trVillage = lstAllVillages[nSel];
				bool bIsInTrpSnd = false;
				foreach (TravianVillage v in TravianAccessor.TrAcsr.lstAllVillagesForSndTrps)
				{
					if (v.nID == trVillage.nID)
					{
						bIsInTrpSnd = true;
						break;
					}
				}
				
				if (bIsInTrpSnd)
					continue;
				
				TravianVillage trVillageForWar = new TravianVillage(trVillage);
				TravianAccessor.TrAcsr.lstAllVillagesForSndTrps.Add(trVillageForWar);
			}
		}
	}
}
