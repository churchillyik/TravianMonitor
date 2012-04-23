/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-11-4
 * Time: 5:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TravianMonitor
{
	public enum CommunicationStatus
	{
		NoCommunication,
		ToCommunicate,
		Communicating,
		Communicated,
		LoginStart,
		LoginReturn,
		Retry,
		Ignored,
	};
	
	public class QueryPhase
	{
		public bool bRelatedToVillages;
		public string strQueryURL;
		
		public QueryPhase(bool related, string url)
		{
			bRelatedToVillages = related;
			strQueryURL = url;
		}
	};
	
	public class TaskStatus
	{
		public CommunicationStatus status;
		public int nCurPhase;
		public int nVillageCursor;
		public string strQueryResult;
		public Dictionary<int, int> dicIgnoredPhases = new Dictionary<int, int>();
		public Dictionary<int, Dictionary<string, string>> dicPostData = new Dictionary<int, Dictionary<string, string>>();
		
		public TaskStatus()
		{
			ClearTaskStatus();
		}
		
		public bool bIsTaskFinished(int nPhasesCnt)
		{
			return (nCurPhase > nPhasesCnt);
		}
		
		public void ClearTaskStatus()
		{
			status = CommunicationStatus.NoCommunication;
			nCurPhase = 1;
			nVillageCursor = 1;
			strQueryResult = null;
			dicIgnoredPhases.Clear();
			foreach (Dictionary<string, string> pd in dicPostData.Values)
			{
				pd.Clear();
			}
			dicPostData.Clear();
		}
	};
	
	/// <summary>
	/// Description of Task.
	/// </summary>
	public class Task
	{
		public bool bIsForAccounts = true;
		public UIUpdateTypes uiType = UIUpdateTypes.None;
		protected UIUpdateTypes logType = UIUpdateTypes.None;
		public List<QueryPhase> lstPhase = null;
		
		public string strName = "";
		public Task()
		{
		}
		
		public bool TakeActionAsk(TravianAccount curAccount)
		{
			if (curAccount == null)
			{
				DirectExec();
				return true;
			}
			
			if (curAccount.tskStatus.bIsTaskFinished(lstPhase.Count))
			{
				return true;
			}
			
			TaskStatus tskStatus = curAccount.tskStatus;
			QueryPhase phase = lstPhase[tskStatus.nCurPhase - 1];
			if (tskStatus.dicIgnoredPhases.ContainsKey(tskStatus.nVillageCursor)
			    && tskStatus.dicIgnoredPhases[tskStatus.nVillageCursor] == tskStatus.nCurPhase)
			{
				if (phase.bRelatedToVillages && tskStatus.nVillageCursor <= curAccount.lstVillages.Count)
				{
					tskStatus.nVillageCursor++;
					if (tskStatus.nVillageCursor > curAccount.lstVillages.Count)
					{
						tskStatus.nVillageCursor = 1;
						tskStatus.nCurPhase++;
					}
				}
				else
				{
					tskStatus.nCurPhase++;
				}
				
				tskStatus.status = CommunicationStatus.NoCommunication;
				return false;
			}
			switch (tskStatus.status)
			{
				case CommunicationStatus.NoCommunication:
					tskStatus.status = CommunicationStatus.ToCommunicate;
					break;
					
				case CommunicationStatus.ToCommunicate: 
					if (curAccount.trWebClient.strCurCookie == null)
					{
						tskStatus.status = CommunicationStatus.LoginStart;
						Login(curAccount);
						break;
					}
					
					tskStatus.status = CommunicationStatus.Communicating;

					string strURL;
					if (phase.bRelatedToVillages && tskStatus.nVillageCursor <= curAccount.lstVillages.Count)
					{
						TravianVillage trVillage = curAccount.lstVillages[tskStatus.nVillageCursor - 1];
						strURL = AddNewdid(trVillage.nID, phase.strQueryURL);
					}
					else
					{
						strURL = AddNewdid(0, phase.strQueryURL);
					}
					Dictionary<string, string> postData = GetPostData(curAccount);
					DebugLog("准备访问：" + strURL + " @[" + curAccount.strName + "]");
					TravianAccessor.TrAcsr.wk_mgr.StartPageQueryWorker(strURL,
					                                                   postData,
					                                                   this,
					                                                   curAccount);
					break;
					
				case CommunicationStatus.Communicated:
					if (!CheckIfLogined(tskStatus.strQueryResult))
					{
						tskStatus.status = CommunicationStatus.LoginStart;
						Login(curAccount);
						break;
					}
					ParseResult(curAccount);
					
					if (phase.bRelatedToVillages && tskStatus.nVillageCursor <= curAccount.lstVillages.Count)
					{
						tskStatus.nVillageCursor++;
						if (tskStatus.nVillageCursor > curAccount.lstVillages.Count)
						{
							tskStatus.nVillageCursor = 1;
							tskStatus.nCurPhase++;
						}
					}
					else
					{
						tskStatus.nCurPhase++;
					}
					
					tskStatus.status = CommunicationStatus.NoCommunication;
					break;
										
				case CommunicationStatus.LoginReturn:
					if (ParseLogin(tskStatus.strQueryResult))
					{
						DebugLog("成功登录：[" + curAccount.strName + "]");
						if (phase.strQueryURL == "dorf1.php")
						{
							tskStatus.status = CommunicationStatus.Communicated;
						}
						else
						{
							tskStatus.status = CommunicationStatus.ToCommunicate;
						}
					}
					else
					{
						DebugLog("无法抓取网页：" + phase.strQueryURL + " @[" + curAccount.strName + "]");
						curAccount.nLoginFailtimes++;
						if (curAccount.nLoginFailtimes >= TravianAccount.nLoginFailLimit)
						{
							tskStatus.status = CommunicationStatus.Ignored;
						}
						else
						{
							tskStatus.status = CommunicationStatus.LoginStart;
							Login(curAccount);
						}
					}
					
					break;
					
				case CommunicationStatus.Ignored:
					return true;
			}
			
			return false;
		}
		
		public void TakeActionRep(TravianAccount trAccount)
		{
			TaskStatus tskStatus = trAccount.tskStatus;
			switch (tskStatus.status)
			{
				case CommunicationStatus.Communicating:
					tskStatus.status = CommunicationStatus.Communicated;
					break;
					
				case CommunicationStatus.LoginStart:
					tskStatus.status = CommunicationStatus.LoginReturn;
					break;
					
				case CommunicationStatus.Retry:
					tskStatus.status = CommunicationStatus.ToCommunicate;
					break;
			}
		}
		
		protected string AddNewdid(int VillageID, string Uri)
		{
			if (VillageID == 0)
				return Uri;
			if (Uri.Contains("?"))
				return Uri + "&newdid=" + VillageID;
			else
				return Uri + "?newdid=" + VillageID;
		}
		
		protected virtual Dictionary<string, string> GetPostData(TravianAccount trAccount)
		{
			return null;
		}
		
		protected virtual void ParseResult(TravianAccount trAccount)
		{
			
		}

		protected bool CheckIfLogined(string strQueryResult)
		{
			if (strQueryResult.Contains("v35 gecko login"))
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		
		protected void Login(TravianAccount trAccount)
		{
			string strURL = "dorf1.php";
			Dictionary<string, string> postData = new Dictionary<string, string>();
			postData["name"] = trAccount.strName;
			postData["password"] = trAccount.strPassword;
			postData["s1"] = "登录";
			postData["w"] = @"1024:768";
			postData["login"] = (UnixTime(DateTime.Now) - 10).ToString();
			TravianAccessor.TrAcsr.wk_mgr.StartPageQueryWorker(strURL,
			                                                   postData,
			                                                   this,
			                                                   trAccount);
		}
		
		protected bool ParseLogin(string strQueryResult)
		{
			if (strQueryResult == null || strQueryResult.Contains("<span class=\"error\">"))
			{
				DebugLog("Username or Password error!");
				return false;
			}
			
			return true;
		}
		
		public void DebugLog(string log)
		{
			TravianAccessor.TrAcsr.DebugLog(log, logType);
		}
		
		protected virtual void DirectExec()
		{
			
		}
		
		private int UnixTime(DateTime time)
		{
			return Convert.ToInt32((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);
		}
	}
}
