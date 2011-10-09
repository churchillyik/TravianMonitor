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
	/// <summary>
	/// Description of TaskRefreshVillages.
	/// </summary>
	public class TaskRefreshVillages : Task
	{
		public TaskRefreshVillages() : base()
		{
			lstPhase = new List<QueryPhase>();
			lstPhase.Add(new QueryPhase(false, "dorf1.php"));
			lstPhase.Add(new QueryPhase(false, "a2b.php"));
			lstPhase.Add(new QueryPhase(true, "build.php?gid=14"));
			lstPhase.Add(new QueryPhase(true, "build.php?gid=16"));
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
					
				case 3:
					ParsePhase3Result(trAccount);
					break;
					
				case 4:
					ParsePhase4Result(trAccount);
					break;
			}
		}
		
		private void ParsePhase1Result(TravianAccount trAccount)
		{
			MatchCollection mc;
            mc = Regex.Matches(
            	trAccount.tskStatus.strQueryResult, "newdid=(\\d+).*?\\((\\-?\\d+).*?\\|[^0-9\\-]*?(\\-?\\d+)\\)[^>]*?>([^<]*?)</a>"
            	, RegexOptions.Singleline);
			trAccount.lstVillages.Clear();
			for (int i = 0; i < mc.Count; i++)
            {
                Match m = mc[i];
                int vid = Convert.ToInt32(m.Groups[1].Value);
                string pos_x = m.Groups[2].Value;
                string pos_y = m.Groups[3].Value;
                string v_name = m.Groups[4].Value;
                
                TravianVillage trVillage = new TravianVillage();
                trVillage.nID = vid;
                trVillage.nPosX = Convert.ToInt32(pos_x);
                trVillage.nPosY = Convert.ToInt32(pos_y);
                trVillage.strName = v_name;
                
                trVillage.nSquareLvl = 0;
                
                trAccount.lstVillages.Add(trVillage);
            }
		}
		
		private void ParsePhase2Result(TravianAccount trAccount)
		{
			Match m = Regex.Match(trAccount.tskStatus.strQueryResult, "<img class=\"unit u(\\d*)\"");
			if (m.Success)
			{
            	trAccount.nTribe = Convert.ToInt32(m.Groups[1].Value) / 10 + 1;
			}
			else
			{
				trAccount.nTribe = 0;
			}
		}
		
		private void ParsePhase3Result(TravianAccount trAccount)
		{
			Match levelMatch = Regex.Match(trAccount.tskStatus.strQueryResult, "<span\\sclass=\"level\">[^\\d]*?(\\d+)</span>");
            if (!levelMatch.Success)
            {
            	return;
            }
            
            TravianVillage trVillage = trAccount.lstVillages[trAccount.tskStatus.nVillageCursor - 1];
            trVillage.nSquareLvl = Convert.ToInt32(levelMatch.Groups[1].Value);
		}
		
		private void ParsePhase4Result(TravianAccount trAccount)
		{
			//	分离出部队的数据
            string[] troopGroups = trAccount.tskStatus.strQueryResult.Split(
				new string[] { "</h4>" }, StringSplitOptions.None);
            if (troopGroups.Length < 2)
            {
                return;
            }

	        TravianVillage trVillage = trAccount.lstVillages[trAccount.tskStatus.nVillageCursor - 1];
	        
	        string[] troopDetails = HtmlUtility.GetElementsWithClass(
                    troopGroups[1],
                    "table",
                    "troop_details\\s*[^\"]*?");
	        if (troopDetails.Length < 1)
            {
                return;
            }
	        
	        string troopDetail = troopDetails[0];
	        //	获得部队单位数
            string unitsdataBody = HtmlUtility.GetElementWithClass(troopDetail, "tbody", "units last");
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
                    trVillage.Troops[i] = Convert.ToInt32(match.Groups[1].Value);
                }
                else if (unitColumns[i].Contains("?"))
                {
                    trVillage.Troops[i] = -1;
                }
                else
                {
                    return;
                }
            }
		}
	}
}
