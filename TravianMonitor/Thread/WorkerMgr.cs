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
    	private Queue<WorkerPageQuery> WkrPageQueryPool = new Queue<WorkerPageQuery>();
    	private int nWorkerPageQueryCnt;

    	public WorkerMgr(int nWkPageQueryCnt)
    	{
    		WkrTaskExec = new WorkerTaskExec();
    		for (int i = 0; i < nWkPageQueryCnt; i++)
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
    			TravianAccessor.TrAcsr.DebugLog("新增线程[" + wk.nGuid + "]", UIUpdateTypes.TroopsMonitorLog);
    		}
    		else
    		{
            	wk = WkrPageQueryPool.Dequeue();
    		}
    		TravianAccessor.TrAcsr.DebugLog("通讯线程[" + wk.nGuid + "]启动。", UIUpdateTypes.TroopsMonitorLog);
            wk.strURL = strURL;
            wk.dicPostData = dicPostData;
            wk.curTask = tsk;
            wk.trAccount = trAccount;
            while (true)
            {
            	if (wk.thrdState == ThreadState.Suspended)
            	{
            		wk.bIsActive = true;
            		break;
            	}
            	else
            	{
            		Thread.Sleep(1);
            		continue;
            	}
            }
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