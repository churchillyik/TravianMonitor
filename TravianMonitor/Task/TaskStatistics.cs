/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-10-11
 * Time: 1:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace TravianMonitor
{
	/// <summary>
	/// Description of TaskStatistics.
	/// </summary>
	public class TaskStatistics : Task
	{
		public TaskStatistics() : base()
		{
			bIsForAccounts = false;
			uiType = UIUpdateTypes.None;
			logType = UIUpdateTypes.TroopsMonitorLog;
		}
		
		protected override void DirectExec()
		{
			if (TravianAccessor.TrAcsr.lstAccounts == null)
				return;
			
			int[,] trStsc = new int[3, 3];
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					trStsc[i, j] = 0;
				}
			}
			foreach (TravianAccount trAccount in TravianAccessor.TrAcsr.lstAccounts)
			{
				if (trAccount.lstVillages == null)
					continue;
				
				int nTribe = trAccount.nTribe;
				List<TroopData> lstTd = TravianData.dicDefenseTroop[nTribe];
				foreach (TravianVillage trVillage in trAccount.lstVillages)
				{
					for (int k = 0; k < 3; k++)
					{
						trStsc[nTribe - 1, k] += trVillage.Troops[lstTd[k].nSeq];
					}
				}
				
			}
			
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < 3; i++)
			{
				List<TroopData> lstTd = TravianData.dicDefenseTroop[i + 1];
				sb.AppendLine(TravianData.strTribeName[i] + "：");
				for (int j = 0; j < 3; j++)
				{
					if (j != 2)
					{
						sb.Append(lstTd[j].strName + " " + trStsc[i, j] + "，");
					}
					else
					{
						sb.Append(lstTd[j].strName + " " + trStsc[i, j] + "\r\n");
					}
				}
			}
			
			DebugLog(sb.ToString());
		}
	}
}
