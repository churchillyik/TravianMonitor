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
	public enum PhaseStatus
	{
		NotStart,
		Continue,
		Communicating,
		NotLogined,
		LoginStart,
		Logined,
		Ignored,
		Finished,
	};
	
	public class Phase
	{
		public TravianAccount trAcc;
		public TravianVillage trVlg;
		public string strQueryURL;
		public Dictionary<string, string> postData;
		public DateTime dtQueryTime;
		public int nRepeatRounds;
		public int nTotalRounds;
		public int nRoundDelay;
		public Phase nextPhase;
		public PhaseStatus curStatus;
		
		public Phase(TravianAccount acc)
		{
			trAcc = acc;
			trVlg = null;
			strQueryURL = null;
			postData = null;
			dtQueryTime = DateTime.MinValue;
			nRepeatRounds = 0;
			nTotalRounds = 1;
			nextPhase = null;
			curStatus = PhaseStatus.NotStart;
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
		
		public void PageQuery()
		{
			switch (curStatus)
			{
				case PhaseStatus.NotStart:
				case PhaseStatus.Continue:
				case PhaseStatus.Logined:
					if (strQueryURL == null)
					{
						curStatus = PhaseStatus.Finished;
						return;
					}
					if (dtQueryTime != DateTime.MinValue && dtQueryTime > DateTime.Now)
						return;
					
					string url;
					if (trVlg == null)
					{
						url = AddNewdid(0, strQueryURL);
					}
					else
					{
						url = AddNewdid(trVlg.nID, strQueryURL);
					}
					
					DebugLog(url + " @[" + trAcc.strName + "]");
					curStatus = PhaseStatus.Communicating;
					TravianWebClient trWebClient = trAcc.trWebClient;
					trWebClient.HttpQuery(
						url, postData
						, new PageQueryCallBack(ParseResult));
					break;
					
				case PhaseStatus.NotLogined:
					Login();
					break;
			}
		}
		
		protected void ParseResult(PageQueryResult result)
		{
			string strPageContent = result.strPageContent;
			if (strPageContent == null)
			{
				curStatus = PhaseStatus.Continue;
				DebugLog(result.strException);
				return;
			}
			
			if (!CheckIfLogined(strPageContent))
			{
				return;
			}

			SpecialParseResult(strPageContent);
			
			SetRepeatRnds();
		}
		
		protected virtual void SpecialParseResult(string strPageContent)
		{
			
		}
		
		protected virtual void SetPostData()
		{

		}
		
		protected bool CheckIfLogined(string strPageContent)
		{
			if (strPageContent.Contains("v35 gecko login"))
			{
				curStatus = PhaseStatus.NotLogined;
				return false;
			}
			else
			{
				return true;
			}
		}
		
		protected void SetRepeatRnds()
		{
			nRepeatRounds++;
			if (nRepeatRounds == nTotalRounds)
			{
				curStatus = PhaseStatus.Finished;
			}
			else
			{
				curStatus = PhaseStatus.Continue;
				dtQueryTime = DateTime.Now.AddMilliseconds(nRoundDelay);
			}
		}
		
		private int UnixTime(DateTime time)
		{
			return Convert.ToInt32(
				(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);
		}
		
		protected void Login()
		{
			string strURL = "dorf1.php";
			Dictionary<string, string> postData = new Dictionary<string, string>();
			postData["name"] = trAcc.strName;
			postData["password"] = trAcc.strPassword;
			postData["s1"] = "登录";
			postData["w"] = @"1024:768";
			postData["login"] = (UnixTime(DateTime.Now) - 10).ToString();
			
			curStatus = PhaseStatus.LoginStart;
			TravianWebClient trWebClient = trAcc.trWebClient;
			trWebClient.HttpQuery(
				strURL, postData
				, new PageQueryCallBack(ParseLogin));
		}
		
		protected void ParseLogin(PageQueryResult result)
		{
			string strPageContent = result.strPageContent;
			if (strPageContent == null)
			{
				curStatus = PhaseStatus.NotLogined;
				DebugLog(result.strException);
				return;
			}
			if (strPageContent.Contains("<span class=\"error\">"))
			{
				DebugLog(string.Format("用户名或密码有错：{0} | {1}", trAcc.strName, trAcc.strPassword));
				trAcc.bIsDead = true;
				curStatus = PhaseStatus.Ignored;
				return;
			}
			else
			{
				DebugLog("成功登录：[" + trAcc.strName + "]");
				curStatus = PhaseStatus.Logined;
			}
			
			InitVillages(strPageContent);
		}
		
		protected virtual void InitVillages(string strPageContent)
		{
			
		}
		
		public void DebugLog(string log)
		{
			TravianAccessor.TrAcsr.DebugLog(log, UIUpdateTypes.DebugLog);
		}
	}
	
	public class Task
	{
		public bool bIsTaskDirect;
		public Task()
		{
			
		}
		
		public virtual bool AllPhasesExec()
		{
			return true;
		}
		
		public virtual void DirectExec()
		{
			
		}
	}

}
