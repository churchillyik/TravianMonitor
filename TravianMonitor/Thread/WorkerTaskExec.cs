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

namespace TravianMonitor
{
	/// <summary>
	/// Description of WorkerTaskExec.
	/// </summary>
	public class WorkerTaskExec
	{
		private Thread thrdWorker;
		
		public Task curTask;
		
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
				switch (curTask.status)
				{
					case TaskStatus.ReadyForPageParse:
						break;
					
				}
				Thread.Sleep(1);
			}
		}
	}
}
