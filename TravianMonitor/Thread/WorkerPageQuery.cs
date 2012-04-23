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
	/// 通讯处理模块
	/// </summary>
	public class WorkerPageQuery
	{		
		private string strURL;
		private Dictionary<string, string> dicPostData;
		private Task curTask;
		private TravianAccount trAccount;
		
		public WorkerPageQuery(
			string url,
		    Dictionary<string, string> data,
		   	Task tsk,
		   	TravianAccount acc)
		{
			strURL = url;
			dicPostData = data;
			curTask = tsk;
			trAccount = acc;
		}
		
		public void PageQuery(Object threadContext)
        {				
			TravianWebClient trWebClient = trAccount.trWebClient;
			string strEx = "";
			trAccount.tskStatus.strQueryResult = trWebClient.HttpQuery(strURL, dicPostData, out strEx);
			if (trAccount.tskStatus.strQueryResult == "")
			{
				curTask.DebugLog("访问：" + strURL + "@[" 
				                 + trAccount.strName + "]时发生异常，准备重试");
				curTask.DebugLog(strEx.Substring(0, strEx.IndexOfAny(new char [] {'\r', '\n'})));
				trAccount.tskStatus.status = CommunicationStatus.Retry;
			}
			curTask.TakeActionRep(trAccount);
        }
	}
}
