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
        
        public GlobalConfig glbCfg = new GlobalConfig();
        public ReinTgs rTgs = new ReinTgs();
        public List<TravianAccount> lstAccounts = new List<TravianAccount>();
        public WorkerMgr wk_mgr = new WorkerMgr(0);

        public TravianAccessor()
        {
        	TravianData.InitTRData();
        }
        
        public void RemoveDeadAccount()
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
    }
}
