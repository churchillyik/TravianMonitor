﻿/*
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
				if (bIsActive && curTask.status == TaskStatus.ReadyForPageQuery)
				{
					
				}
				Thread.Sleep(1);
			}
        }
	}
}