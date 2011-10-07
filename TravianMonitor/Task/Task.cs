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
	
	/// <summary>
	/// Description of Task.
	/// </summary>
	public class Task
	{		
		protected TravianAccount UpCall;
		protected LogTypes logType;
		protected CommunicationStatus status;
		protected int nCurPhase;
		protected List<QueryPhase> lstPhase = null;
		protected int nVillageCursor;
		protected List<TravianVillage> lstVillages = null;
		protected string strQueryResult = null;
		
		public bool bToBeDeleted;
		
		public Task(TravianAccount trAccount)
		{
			UpCall = trAccount;
			logType = LogTypes.TroopsMonitor;
			status = CommunicationStatus.NoCommunication;
			nCurPhase = 1;
			nVillageCursor = 1;
			lstVillages = trAccount.lstVillages;
			bToBeDeleted = false;
			
			OtherInit(trAccount);
		}
		
		protected void OtherInit(TravianAccount trAccount)
		{
			
		}
		
		public void TakeActionAsk()
		{
			int nPhaseCnt = 0;
			if (lstPhase != null)
			{
				nPhaseCnt = lstPhase.Count;
			}
			bool bNeedCommunication = (nPhaseCnt != 0);
			if (!bNeedCommunication)
			{
				ParseResult();
				bToBeDeleted = true;
				return;
			}
			
			switch (status)
			{
				case CommunicationStatus.NoCommunication:
					if (nCurPhase > nPhaseCnt)
					{
						bToBeDeleted = true;
						return;
					}
					
					status = CommunicationStatus.ToCommunicate;
					break;
					
				case CommunicationStatus.ToCommunicate: 
					if (trWebClient.strCurCookie == null)
					{
						status = CommunicationStatus.LoginStart1;
						Login1();
						break;
					}
					
					status = CommunicationStatus.Communicating;

					QueryPhase phase = lstPhase[nCurPhase - 1];
					string strURL;
					if (phase.bRelatedToVillages && lstVillageID != null && nVillageCursor <= lstVillageID.Count)
					{
						strURL = AddNewdid((lstVillageID[nVillageCursor - 1]), phase.strQueryURL);
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
					
					QueryPhase phase = lstPhase[nCurPhase - 1];
					if (phase.bRelatedToVillages && lstVillageID != null && nVillageCursor <= lstVillageID.Count)
					{
						nVillageCursor++;
						if (nVillageCursor > lstVillageID.Count)
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
					if (ParseLogin1(userkey, passkey))
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
			if(VillageID == 0)
				return Uri;
			if(Uri.Contains("?"))
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
			if(strQueryResult.Contains("login"))
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
			postData[userkey] = Username;
			postData[passkey] = Password;
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
	}
}
