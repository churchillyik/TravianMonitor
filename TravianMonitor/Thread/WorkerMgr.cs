using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TravianMonitor
{
    public class WorkerMgr
    {
    	public WorkerTaskExec WkrTaskExec = null;
    	private Queue<WorkerPageQuery> WkrPageQueryPool = new Queue<WorkerPageQuery>();
    	private int nWorkerPageQueryCnt;

    	public WorkerMgr(int nWkPageQueryCnt)
    	{
    		WkrTaskExec = new WorkerTaskExec();
    		for (int i = 0; i < nWorkerPageQueryCnt; i++)
    		{
    			WorkerPageQuery wk = new WorkerPageQuery(i + 1);
    			WkrPageQueryPool.Enqueue(wk);
    		}
    		nWorkerPageQueryCnt = nWkPageQueryCnt;
    	}
    	
        public void StartPageQueryWorker(string strURL, 
    	                                 Dictionary<string, string> dicPostData, 
    	                                 Task tsk,
    	                                 TravianAccount trAccount)
        {
    		WorkerPageQuery wk = null;
    		if (WkrPageQueryPool.Count == 0)
    		{
    			nWorkerPageQueryCnt++;
    			wk = new WorkerPageQuery(nWorkerPageQueryCnt);
    		}
    		else
    		{
            	wk = WkrPageQueryPool.Dequeue();
    		}
            wk.strURL = strURL;
            wk.dicPostData = dicPostData;
            wk.curTask = tsk;
            wk.trAccount = trAccount;
            wk.bIsActive = true;
            wk.ThreadResume();
        }

    	public void StopPageQueryWorker(WorkerPageQuery wk)
    	{
    		if (wk == null)
    			return;
    		
    		wk.bIsActive = false;
    		WkrPageQueryPool.Enqueue(wk);
    	}
    }
}