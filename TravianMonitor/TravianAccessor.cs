using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TravianMonitor
{
    partial class TravianAccessor
    {
        static public TravianAccessor TrAcsr = null;

        public GlobalConfig glbCfg = new GlobalConfig();
        public ReinTgs rTgs = new ReinTgs();
        public WorkerMgr wk_mgr = new WorkerMgr();
        
        public TravianAccessor()
        {
            
        }
    }
}
