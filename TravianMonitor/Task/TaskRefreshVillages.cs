/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-11-4
 * Time: 5:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TravianMonitor
{
	public class PhaseLogin : Phase
	{
		public PhaseLogin(TravianAccount acc) : base(acc)
		{
			curStatus = PhaseStatus.NotLogined;
		}
		
		protected override void InitVillages(string strPageContent)
		{
			MatchCollection mc;
            mc = Regex.Matches(
            	strPageContent
            	, "newdid=(\\d+).*?\\((\\-?\\d+).*?\\|[^0-9\\-]*?(\\-?\\d+)\\)[^>]*?>([^<]*?)</a>"
            	, RegexOptions.Singleline);
			trAcc.lstVillages.Clear();
			for (int i = 0; i < mc.Count; i++)
            {
                Match m = mc[i];
                int vid = Convert.ToInt32(m.Groups[1].Value);
                string pos_x = m.Groups[2].Value;
                string pos_y = m.Groups[3].Value;
                string v_name = m.Groups[4].Value;
                
                TravianVillage trVillage = new TravianVillage();
                trVillage.UpCall = trAcc;
                trVillage.nID = vid;
                trVillage.nPosX = Convert.ToInt32(pos_x);
                trVillage.nPosY = Convert.ToInt32(pos_y);
                trVillage.strName = v_name;
                
                trAcc.lstVillages.Add(trVillage);
            }
		}
	}
	
	public class PhaseGetTribe : Phase
	{
		public PhaseGetTribe(TravianAccount acc) : base(acc)
		{
			strQueryURL = "build.php?id=40";
		}
		
		protected override void SpecialParseResult(string strPageContent)
		{
			Match m = Regex.Match(strPageContent, "iPopup\\((\\d+),4");
			if (m.Success)
			{
            	trAcc.nTribe = Convert.ToInt32(m.Groups[1].Value) % 10;
			}
			else
			{
				trAcc.nTribe = 0;
			}
		}
	}
	
	public class PhaseGetTroops : Phase
	{
		public PhaseGetTroops(TravianAccount acc, TravianVillage vlg) : base(acc)
		{
			trVlg = vlg;
			strQueryURL = "build.php?gid=16&tt=1";
		}
		
		protected override void SpecialParseResult(string strPageContent)
		{
			//	分离出部队的数据
            string[] troopGroups = strPageContent.Split(
				new string[] { "</h4>" }, StringSplitOptions.None);
            if (troopGroups.Length < 2)
            {
                return;
            }
       
            string[] troopDetails = null;
            for (int i = 1; i < troopGroups.Length; i++)
            {
		        troopDetails = HtmlUtility.GetElementsWithClass(
	                    troopGroups[i],
	                    "table.*?",
	                    "troop_details");
            	if (troopDetails.Length < 1)
	            {
	                continue;
	            }
            	else
            	{
            		break;
            	}
            }
	        if (troopDetails == null || troopDetails.Length < 1)
            {
                return;
            }
	        
	        string troopDetail = troopDetails[0];
	        //	获得部队单位数
            string unitsdataBody = HtmlUtility.GetElementWithClass(
	        	troopDetail, "tbody", "units last");
            if (unitsdataBody == null)
            {
                return;
            }
            
            string unitdataRow = HtmlUtility.GetElement(unitsdataBody, "tr");
            if (unitdataRow == null)
            {
                return;
            }
            
            string[] unitColumns = HtmlUtility.GetElements(unitdataRow, "td");
            if (unitColumns.Length < 10)
            {
                return;
            }

            for (int i = 0; i < unitColumns.Length; i++)
            {
                Match match = Regex.Match(unitColumns[i], @"(\d+)");
                if (match.Success)
                {
                    trVlg.Troops[i] = Convert.ToInt32(match.Groups[1].Value);
                }
                else if (unitColumns[i].Contains("?"))
                {
                    trVlg.Troops[i] = -1;
                }
                else
                {
                    return;
                }
            }
		}
	}
	
	public enum RefreshSteps
	{
		LoginStep,
		GetTribeStep,
		GetTroopsStep,
	}
	/// <summary>
	/// Description of TaskRefreshVillages.
	/// </summary>
	public class TaskRefreshVillages : Task
	{
		private List<TravianAccount> lstAccs;
		private List<Phase> lstPhases = new List<Phase>();
		private RefreshSteps curStep;
		public TaskRefreshVillages(List<TravianAccount> all_accs) : base()
		{			
			lstAccs = all_accs;
			foreach (TravianAccount acc in all_accs)
			{
				PhaseLogin ph_lg = new PhaseLogin(acc);
				lstPhases.Add(ph_lg);
			}
			
			curStep = RefreshSteps.LoginStep;
			bIsTaskDirect = false;
		}
				
		public override bool AllPhasesExec()
		{
			bool bIsAllDone = true;
			foreach (Phase ph in lstPhases)
			{
				if (ph.curStatus != PhaseStatus.Finished
				    && ph.curStatus != PhaseStatus.Ignored)
				{
					bIsAllDone = false;
					break;
				}
			}
			
			if (bIsAllDone)
			{
				if (curStep == RefreshSteps.LoginStep)
				{
					this.lstPhases.Clear();
					foreach (TravianAccount acc in lstAccs)
					{
						PhaseGetTribe ph_get_trb = new PhaseGetTribe(acc);
						lstPhases.Add(ph_get_trb);
					}
					
					curStep = RefreshSteps.GetTribeStep;
				}
				else if (curStep == RefreshSteps.GetTribeStep)
				{
					this.lstPhases.Clear();
					foreach (TravianAccount acc in lstAccs)
					{
						foreach (TravianVillage vlg in acc.lstVillages)
						{
							PhaseGetTroops ph_get_trp = new PhaseGetTroops(acc, vlg);
							lstPhases.Add(ph_get_trp);
						}
					}
					
					curStep = RefreshSteps.GetTroopsStep;
				}
				else if (curStep == RefreshSteps.GetTroopsStep)
				{
					this.lstPhases.Clear();
					TravianAccessor.TrAcsr.UIUpdate(UIUpdateTypes.VillageList);
					return true;
				}
			}
			
			foreach (Phase ph in lstPhases)
			{
				ph.PageQuery();
			}
			
			return false;
		}
	}
}
