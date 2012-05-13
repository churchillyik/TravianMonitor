using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TravianMonitor
{
    partial class TravianAccessor
    {
        static public TravianAccessor TrAcsr = null;

        public bool bIsTaskSet = false;
        
        public WorkerTaskExec tskWkr = new WorkerTaskExec();
        
        public GlobalConfig glbCfg = new GlobalConfig();
        public ReinTgs rTgs = new ReinTgs();
        public List<TravianAccount> lstAccounts = new List<TravianAccount>();
        public List<TravianVillage> lstAllVillagesForSndTrps = new List<TravianVillage>();

        public TravianAccessor()
        {
        	TravianData.InitTRData();
        }
        
        public void RemoveDeadAccounts()
        {
        	for (int i = 0; i < lstAccounts.Count;)
        	{
        		TravianAccount trAccount = lstAccounts[i];
        		if (trAccount.bIsDead)
        		{
        			lstAccounts.Remove(trAccount);
        		}
        		else
        		{
        			i++;
        		}
        	}
        }
        
        public void RemoveVillagesWithNoDefTroops()
        {
        	foreach (TravianAccount trAccount in lstAccounts)
        	{
        		for (int i = 0; i < trAccount.lstVillages.Count;)
        		{
        			TravianVillage trVillage = trAccount.lstVillages[i];
        			if (trVillage.nMinTroopSpeed == 100)
        			{
        				trAccount.lstVillages.Remove(trVillage);
        			}
        			else
        			{
        				i++;
        			}
        		}
        	}
        }
    }
}
