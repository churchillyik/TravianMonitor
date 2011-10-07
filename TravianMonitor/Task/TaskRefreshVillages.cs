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

namespace TravianMonitor
{
	/// <summary>
	/// Description of TaskRefreshVillages.
	/// </summary>
	public class TaskRefreshVillages : Task
	{
		public TaskRefreshVillages()
		{
		}
		
		protected void OtherInit(TravianAccount trAccount)
		{
			lstPhase = new List<QueryPhase>()
			{
				new QueryPhase(false, "dorf1.php"),
				new QueryPhase(true, "build.php?gid=14"),
				new QueryPhase(true, "build.php?gid=16"),
			};
		}
				
		protected void ParseResult()
		{
			switch (nCurPhase)
			{
				case 1:
					status = CommunicationStatus.Communicated;
					break;
					
				case 2:
					status = CommunicationStatus.LoginReturn1;
					break;
					
				case 3:
					status = CommunicationStatus.LoginReturn2;
					break;
			}
		}
	}
}
