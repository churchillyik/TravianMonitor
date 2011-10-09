/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-11-4
 * Time: 5:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Threading;

namespace TravianMonitor
{
	/// <summary>
	/// Description of WorkerPageQuery.
	/// </summary>
	public class WorkerPageQuery
	{
		private int nGuid;
		private Thread thrdWorker;
		
		public string strURL;
		public Dictionary<string, string> dicPostData;
		public Task curTask;
		public TravianAccount trAccount;
		public bool bIsActive;
		
		public WorkerPageQuery(int nID)
		{
			nGuid = nID;
			bIsActive = false;
			thrdWorker = new Thread(new ThreadStart(PageQuery));
			thrdWorker.Name = "PageQuery" + nGuid.ToString();
            thrdWorker.Start();
		}
		
		private void PageQuery()
        {
			while(true)
			{
				if (!bIsActive)
				{
					ThreadSuspend();
				}
				
				TravianWebClient trWebClient = trAccount.trWebClient;
				trAccount.tskStatus.strQueryResult = trWebClient.HttpQuery(strURL, dicPostData);
				
				curTask.TakeActionRep(trAccount);
				
				TravianAccessor.TrAcsr.wk_mgr.StopPageQueryWorker(this);
				Thread.Sleep(1);
			}
        }
		
		public void ThreadSuspend()
		{
			thrdWorker.Suspend();
		}
		
		public void ThreadResume()
		{
			if (thrdWorker.ThreadState == ThreadState.Suspended)
				thrdWorker.Resume();
		}
	}
}
