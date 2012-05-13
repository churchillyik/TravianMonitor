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
				if (curTask.bIsTaskDirect)
				{
					curTask.DirectExec();
				}
				else
				{
					bTaskFinished = curTask.AllPhasesExec();
				}
				
				if (bTaskFinished)
				{
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
