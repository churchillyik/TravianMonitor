/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-10-11
 * Time: 0:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TravianMonitor
{
	/// <summary>
	/// Description of TaskCalStartTime.
	/// </summary>
	public class TaskCalStartTime : Task
	{
		private DateTime dtArrTime;
		private int nTgX;
		private int nTgY;
		public TaskCalStartTime(DateTime arrTime, int x, int y) : base()
		{
			strName = "[计算出兵时刻]";
			dtArrTime = arrTime;
			nTgX = x;
			nTgY = y;
			
			lstPhase = new List<QueryPhase>();
			lstPhase.Add(new QueryPhase(true, "build.php?id=39&tt=2"));
			lstPhase.Add(new QueryPhase(true, "build.php?id=39&tt=2"));
			
			uiType = UIUpdateTypes.VillageList;
			logType = UIUpdateTypes.DebugLog;
		}

		protected override void ParseResult(TravianAccount trAccount)
		{
			switch (trAccount.tskStatus.nCurPhase)
			{
				case 1:
					ParsePhase1Result(trAccount);
					break;
					
				case 2:
					ParsePhase2Result(trAccount);
					break;
			}
		}
		
		private void ParsePhase1Result(TravianAccount trAccount)
		{
			TravianVillage trVillage = trAccount.lstVillages[trAccount.tskStatus.nVillageCursor - 1];
			Dictionary<string, string> post_data = null;
			if (trAccount.tskStatus.dicPostData.ContainsKey(trVillage.nID))
			{
				post_data = trAccount.tskStatus.dicPostData[trVillage.nID];
				post_data.Clear();
			}
			else
			{
				post_data = new Dictionary<string, string>();
				trAccount.tskStatus.dicPostData.Add(trVillage.nID, post_data);
			}
			
			Regex hiddenInputPattern = new Regex(@"<input\s+type=""hidden""\s+name=""(\w+)""\s+value=""(.+?)""\s+/>");
			MatchCollection matches = hiddenInputPattern.Matches(trAccount.tskStatus.strQueryResult);
            foreach (Match match in matches)
            {
                post_data.Add(match.Groups[1].Value, match.Groups[2].Value);
            }
            
            post_data.Add("c", "2");
            post_data.Add("x", nTgX.ToString());
            post_data.Add("y", nTgY.ToString());

            List<TroopData> lstTd = TravianData.dicDefenseTroop[trAccount.nTribe];
            for (int i = 0; i < 11; i++)
            {
                string troopKey = String.Format("t{0}", i + 1);
                bool bIsDefendTroop = false;
                for (int j = 0; j < lstTd.Count; j++)
                {
                	if (lstTd[j].nSeq == i)
                	{
                		bIsDefendTroop = true;
                		break;
                	}
                }
                string troopNumber = bIsDefendTroop ? trVillage.Troops[i].ToString() : "";
                post_data.Add(troopKey, troopNumber);
            }
		}
        
		private void ParsePhase2Result(TravianAccount trAccount)
		{
			//<div class="in">需时 0:03:45 小时</div>
			Match m = Regex.Match(trAccount.tskStatus.strQueryResult
			                      , "<div class=\"in\">[^\\d]*?(\\d+):(\\d+):(\\d+)[^<]*?</div>"
			                      , RegexOptions.Singleline);
			if (m.Success)
			{
				int hour = Convert.ToInt32(m.Groups[1].Value);
				int min = Convert.ToInt32(m.Groups[2].Value);
				int sec = Convert.ToInt32(m.Groups[3].Value);
				TravianVillage trVillage = trAccount.lstVillages[trAccount.tskStatus.nVillageCursor - 1];
				
				trVillage.dtReachTime = dtArrTime;
				trVillage.nTimeCost = hour * 3600 + min * 60 + sec;
				trVillage.reinTg = new Target(nTgX, nTgY);
			}
		}
		
		protected override Dictionary<string, string> GetPostData(TravianAccount trAccount)
		{
			if (trAccount.tskStatus.nCurPhase == 2)
			{
				TravianVillage trVillage = trAccount.lstVillages[trAccount.tskStatus.nVillageCursor - 1];
				return trAccount.tskStatus.dicPostData[trVillage.nID];
			}
			else
			{
				return null;
			}
		}
	}
}
