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
				
				if (TravianAccessor.TrAcsr.bIsAccountRefreshing)
				{
					continue;
				}
				
				foreach (TravianAccount account in TravianAccessor.TrAcsr.lstAccounts)
				{					
					foreach (Task tsk in account.lstTask)
					{
						if (tsk.bToBeDeleted)
						{
							account.lstTask.Remove(tsk);
							continue;
						}
						tsk.TakeActionAsk();
					}
				}
			}
		}
	}
}
