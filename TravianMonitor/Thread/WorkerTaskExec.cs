/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-11-4
 * Time: 5:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Threading;

namespace TravianMonitor
{
	/// <summary>
	/// Description of WorkerTaskExec.
	/// </summary>
	public class WorkerTaskExec
	{
		public Task curTask = null;
		
		private Thread thrdWorker;
		
		public WorkerTaskExec()
		{
			thrdWorker = new Thread(new ThreadStart(TaskExec));
			thrdWorker.Name = "WorkerTaskExec";
            thrdWorker.Start();
		}
		
		private void TaskExec()
		{
			while(true)
			{
				Thread.Sleep(1);
				
				if (TravianAccessor.TrAcsr == null)
				{
					continue;
				}
				if (!TravianAccessor.TrAcsr.bIsTaskSet)
				{
					continue;
				}
				
				bool bTaskFinished = true;
				if (curTask.bIsForAccounts)
				{
					int nPhasesFinished = 0;
					foreach (TravianAccount account in TravianAccessor.TrAcsr.lstAccounts)
					{
						bool bFinished = curTask.TakeActionAsk(account);
						bTaskFinished &= bFinished;
						nPhasesFinished += (account.tskStatus.nCurPhase - 1);
					}
					int nAllPhasesCnt = TravianAccessor.TrAcsr.lstAccounts.Count * curTask.lstPhase.Count;
					TravianAccessor.TrAcsr.TaskStatusUpdate(
						nPhasesFinished + " / " + nAllPhasesCnt, UIUpdateTypes.TaskProcess);
				}
				else
				{
					bTaskFinished = curTask.TakeActionAsk(null);
				}
				
				if (bTaskFinished)
				{
					TravianAccessor.TrAcsr.UIUpdate(curTask.uiType);
					TravianAccessor.TrAcsr.TaskStatusUpdate(
						"任务 " + curTask + " 已完成", UIUpdateTypes.TaskDetail);
					curTask = null;
					TravianAccessor.TrAcsr.bIsTaskSet = false;
				}
			}
		}
		
		public void AbortThread()
		{
			try
			{
				this.thrdWorker.Abort();
			}
			catch{}
		}
	}
}
