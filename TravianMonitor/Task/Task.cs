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
		LoginStart1,
		LoginReturn1,
		LoginStart2,
		LoginReturn2,
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
		
		public TaskStatus()
		{
			status = CommunicationStatus.NoCommunication;
			nCurPhase = 1;
			nVillageCursor = 1;
			strQueryResult = null;
		}
		
		public bool bIsTaskFinished(int nPhasesCnt)
		{
			return (nCurPhase > nPhasesCnt);
		}
	};
	
	/// <summary>
	/// Description of Task.
	/// </summary>
	public class Task
	{
		protected LogTypes logType = LogTypes.TroopsMonitor;
		protected List<QueryPhase> lstPhase = null;
		
		public Task()
		{
		}
		
		public bool TakeActionAsk(TravianAccount curAccount)
		{
			if (curAccount = null)
			{
				ParseResult();
				return true;
			}
			
			if (curAccount.tskStatus.bIsTaskFinished(lstPhase.Count))
			{
				return true;
			}
			
			TaskStatus tskStatus = curAccount.tskStatus;
			QueryPhase phase = lstPhase[tskStatus.nCurPhase - 1];
			switch (tskStatus.status)
			{
				case CommunicationStatus.NoCommunication:
					tskStatus.status = CommunicationStatus.ToCommunicate;
					break;
					
				case CommunicationStatus.ToCommunicate: 
					if (curAccount.trWebClient.strCurCookie == null)
					{
						tskStatus.status = CommunicationStatus.LoginStart1;
						Login1();
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
					Dictionary<string, string> postData = GetPostData();
					TravianAccessor.TrAcsr.wk_mgr.StartPageQueryWorker(strURL, postData, this);
					break;
					
				case CommunicationStatus.Communicated:
					if (!CheckIfLogined())
					{
						status = CommunicationStatus.LoginStart1;
						Login1();
						break;
					}
					ParseResult();
					
					if (phase.bRelatedToVillages && nVillageCursor <= curAccount.lstVillages.Count)
					{
						nVillageCursor++;
						if (nVillageCursor > UpCall.lstVillages.Count)
						{
							nVillageCursor = 1;
							nCurPhase++;
						}
					}
					else
					{
						nCurPhase++;
					}
					
					status = CommunicationStatus.NoCommunication;
					break;
					
				case CommunicationStatus.LoginReturn1:
					string userkey, passkey;
					if (ParseLogin1(out userkey, out passkey))
					{
						status = CommunicationStatus.LoginStart2;
						Login2(userkey, passkey);
					}
					else
					{
						DebugLog("无法抓取网页：" + strQueryResult);
						bToBeDeleted = true;
					}
					
					break;
					
				case CommunicationStatus.LoginReturn2:
					if (ParseLogin2())
					{
						status = CommunicationStatus.ToCommunicate;
					}
					else
					{
						DebugLog("无法抓取网页：" + strQueryResult);
						bToBeDeleted = true;
					}
					
					break;
			}
		}
		
		public void TakeActionRep()
		{
			switch (status)
			{
				case CommunicationStatus.Communicating:
					status = CommunicationStatus.Communicated;
					break;
					
				case CommunicationStatus.LoginStart1:
					status = CommunicationStatus.LoginReturn1;
					break;
					
				case CommunicationStatus.LoginStart2:
					status = CommunicationStatus.LoginReturn2;
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
		
		protected Dictionary<string, string> GetPostData()
		{
			return null;
		}
		
		protected void ParseResult()
		{
			
		}

		protected bool CheckIfLogined()
		{
			if (strQueryResult.Contains("login"))
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		
		protected void Login1()
		{
			string strURL = "dorf1.php";
			Dictionary<string, string> postData = null;
			TravianAccessor.TrAcsr.wk_mgr.StartPageQueryWorker(strURL, postData, this);
		}
		
		protected void Login2(string userkey, string passkey)
		{
			string strURL = "dorf1.php";
			Dictionary<string, string> postData = new Dictionary<string, string>();
			postData[userkey] = UpCall.strName;
			postData[passkey] = UpCall.strPassword;
			postData["s1"] = "登录";
			postData["w"] = @"1024:768";
			postData["login"] = (UnixTime(DateTime.Now) - 10).ToString();
			TravianAccessor.TrAcsr.wk_mgr.StartPageQueryWorker(strURL, postData, this);
		}
		
		protected bool ParseLogin1(out string userkey, out string passkey)
		{
			userkey = "";
			passkey = "";
			
			if (strQueryResult == null || !strQueryResult.Contains("Travian"))
			{
				DebugLog("Cannot visit travian website!");
				return false;
			}
			
			Match m;
			m = Regex.Match(strQueryResult, "type=\"text\" name=\"(\\S+?)\"");
			if (m.Success)
				userkey = m.Groups[1].Value;
			else
			{
				DebugLog("Parse userkey error!");
				return false;
			}
			m = Regex.Match(strQueryResult, "type=\"password\" name=\"(\\S+?)\"");
			if (m.Success)
				passkey = m.Groups[1].Value;
			else
			{
				DebugLog("Parse passkey error!");
				return false;
			}
			
			return true;
		}
		
		protected bool ParseLogin2()
		{
			if (strQueryResult == null || strQueryResult.Contains("<span class=\"error\">"))
			{
				DebugLog("Username or Password error!");
				return false;
			}
			
			return true;
		}
		
		protected void DebugLog(string log)
		{
			TravianAccessor.TrAcsr.DebugLog(log, logType);
		}
		
		private int UnixTime(DateTime time)
		{
			return Convert.ToInt32((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);
		}
	}
}
