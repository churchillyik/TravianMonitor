﻿/*
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
		private List<TravianAccount> lstAccs;
		public TaskStatistics(List<TravianAccount> all_accs) : base()
		{
			lstAccs = all_accs;
			bIsTaskDirect = true;
		}
		
		public override void DirectExec()
		{
			if (lstAccs == null)
				return;
			
			int[,] trStsc = new int[3, 3];
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					trStsc[i, j] = 0;
				}
			}
			foreach (TravianAccount trAccount in lstAccs)
			{
				if (trAccount.lstVillages == null || trAccount.bIsDead)
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
			
			TravianAccessor.TrAcsr.TrpStaUpdate(trStsc, UIUpdateTypes.TroopStatistics);
		}
	}
}
