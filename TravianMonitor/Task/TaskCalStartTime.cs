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
	public class PhaseCal_I : Phase
	{
		private DateTime dtArrTime;
		private int nTgX;
		private int nTgY;
		public PhaseCal_I(TravianAccount acc, TravianVillage vlg
		                  , DateTime arrTime, int x, int y) : base(acc)
		{
			trVlg = vlg;
			strQueryURL = "build.php?id=39&tt=2";
			
			dtArrTime = arrTime;
			nTgX = x;
			nTgY = y;
		}
		
		protected override void SpecialParseResult(string strPageContent)
		{
			Dictionary<string, string> post_data = new Dictionary<string, string>();
			
			Regex hiddenInputPattern 
				= new Regex(@"<input\s+type=""hidden""\s+name=""(\w+)""\s+value=""(.+?)""\s+/>");
			MatchCollection matches = hiddenInputPattern.Matches(strPageContent);
            foreach (Match match in matches)
            {
                post_data.Add(match.Groups[1].Value, match.Groups[2].Value);
            }
            
            post_data.Add("c", "2");
            post_data.Add("x", nTgX.ToString());
            post_data.Add("y", nTgY.ToString());

            List<TroopData> lstTd = TravianData.dicDefenseTroop[trAcc.nTribe];
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
                string troopNumber = bIsDefendTroop ? trVlg.Troops[i].ToString() : "";
                post_data.Add(troopKey, troopNumber);
            }
            
            this.nextPhase = new PhaseCal_II(trAcc, trVlg, dtArrTime, nTgX, nTgY, post_data);
		}
	}
	
	public class PhaseCal_II : Phase
	{
		private DateTime dtArrTime;
		private int nTgX;
		private int nTgY;
		public PhaseCal_II(TravianAccount acc, TravianVillage vlg
		                  , DateTime arrTime, int x, int y
		                  , Dictionary<string, string> post_data) : base(acc)
		{
			trVlg = vlg;
			strQueryURL = "build.php?id=39&tt=2";
			
			dtArrTime = arrTime;
			nTgX = x;
			nTgY = y;
			
			postData = post_data;
		}
		
		protected override void SpecialParseResult(string strPageContent)
		{
			//<div class="in">需时 0:03:45 小时</div>
			Match m = Regex.Match(strPageContent
			                      , "<div class=\"in\">[^\\d]*?(\\d+):(\\d+):(\\d+)[^<]*?</div>"
			                      , RegexOptions.Singleline);
			if (m.Success)
			{
				int hour = Convert.ToInt32(m.Groups[1].Value);
				int min = Convert.ToInt32(m.Groups[2].Value);
				int sec = Convert.ToInt32(m.Groups[3].Value);
								
				trVlg.dtReachTime = dtArrTime;
				trVlg.nTimeCost = hour * 3600 + min * 60 + sec;
				trVlg.reinTg = new Target(nTgX, nTgY);
			}
		}
	}
	
	/// <summary>
	/// Description of TaskCalStartTime.
	/// </summary>
	public class TaskCalStartTime : Task
	{
		private List<TravianAccount> lstAccs;
		private List<Phase> lstPhases = new List<Phase>();
		public TaskCalStartTime(List<TravianAccount> all_accs
		                        , DateTime arrTime, int x, int y) : base()
		{
			lstAccs = all_accs;
			foreach (TravianAccount acc in all_accs)
			{
				foreach (TravianVillage vlg in acc.lstVillages)
				{
					PhaseCal_I ph_cal = new PhaseCal_I(acc, vlg, arrTime, x, y);
					lstPhases.Add(ph_cal);
				}
			}
			
			bIsTaskDirect = false;
		}

		public override bool AllPhasesExec()
		{
			bool bIsAllDone = true;
			foreach (Phase ph in lstPhases)
			{
				Phase curPhase = ph;
				while (curPhase != null)
				{
					if (curPhase.curStatus != PhaseStatus.Finished
				    && curPhase.curStatus != PhaseStatus.Ignored)
					{
						bIsAllDone = false;
						curPhase.PageQuery();
					}
					
					if (curPhase.curStatus != PhaseStatus.Finished)
					{
						break;
					}
					
					curPhase = curPhase.nextPhase;
				}
			}
			
			if (bIsAllDone)
			{
				TravianAccessor.TrAcsr.UIUpdate(UIUpdateTypes.VillageList);
			}
			return bIsAllDone;
		}
	}
}
