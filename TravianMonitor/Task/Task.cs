/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-11-4
 * Time: 5:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TravianMonitor
{
	public enum TaskStatus
	{
		ReadyForPageQuery,
		ReadyForPageParse,
	};
	/// <summary>
	/// Description of Task.
	/// </summary>
	public class Task
	{
		public TaskStatus status;
		private string strQueryResult = null;
		public Task()
		{
		}
	}
}
