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
        public WorkerMgr wk_mgr = new WorkerMgr(20);

        public TravianAccessor()
        {
        	TravianData.InitTRData();
        }
    }
}
