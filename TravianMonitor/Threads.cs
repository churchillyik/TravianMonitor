using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace TravianMonitor
{
    public class LogArgs : EventArgs
    {
        public string strLog;
    }
    partial class TravianAccessor
    {
        Thread thrdPageQueryWorker = null;
        public void StartPageQueryWorker()
        {
            thrdPageQueryWorker = new Thread(new ThreadStart(PageQueryWorker));
            thrdPageQueryWorker.Name = "PageQueryWorker";
            thrdPageQueryWorker.Start();
        }

        private void PageQueryWorker()
        {

        }

        public event EventHandler<LogArgs> OnLog;
        private void DebugLog(string log)
        {
            LogArgs arg = new LogArgs();
            arg.strLog = log;
            OnLog(this, arg);
        }
    }
}