/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-10-7
 * Time: 14:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TravianMonitor
{
	public enum LogTypes
	{
		TroopsMonitor,
		TroopsSending
	};
	
    public class LogArgs : EventArgs
    {
        public string strLog;
        public LogTypes type;
    }
    
	partial class TravianAccessor
	{
		public event EventHandler<LogArgs> OnLog;
        public void DebugLog(string log, LogTypes type)
        {
            LogArgs arg = new LogArgs();
            arg.strLog = log;
            arg.type = type;
            OnLog(this, arg);
        }
	}
}
