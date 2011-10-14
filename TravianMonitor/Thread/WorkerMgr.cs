using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace TravianMonitor
{
    public class WorkerMgr
    {
    	public WorkerTaskExec WkrTaskExec = null;
    	public WorkerMgr(int nWkPageQueryCnt)
    	{
    		WkrTaskExec = new WorkerTaskExec();
    	}
    	
        public void StartPageQueryWorker(string strURL, 
    	                                 Dictionary<string, string> dicPostData, 
    	                                 Task tsk,
    	                                 TravianAccount trAccount)
        {
    		WorkerPageQuery wk = new WorkerPageQuery(strURL, dicPostData, tsk, trAccount);
            ThreadPool.QueueUserWorkItem(wk.PageQuery);
        }
    }
}