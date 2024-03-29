﻿/*
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
	public enum UIUpdateTypes
	{
		None,
		DebugLog,
		VillageList,
		TroopStatistics,
		TroopSendingList,
		TaskDetail,
		TaskProcess,
	};
    
    public class UIUpdateArgs : EventArgs
    {
    	public UIUpdateTypes uiType;
    };
    
    public class LogArgs : UIUpdateArgs
    {
        public string strLog;
    };
    
    public class TaskStaArgs : UIUpdateArgs
    {
    	public string strSta;
    };
    
    public class TrpStaArgs : UIUpdateArgs
    {
    	public int[,] nTroopNums;
    };
    
	partial class TravianAccessor
	{
		public event EventHandler<UIUpdateArgs> OnUIUpdate;
        public void DebugLog(string log, UIUpdateTypes type)
        {
            LogArgs arg = new LogArgs();
            arg.strLog = log;
            arg.uiType = type;
            OnUIUpdate(this, arg);
        }
        
        public void TaskStatusUpdate(string strSta, UIUpdateTypes type)
        {
        	TaskStaArgs arg = new TaskStaArgs();
            arg.strSta = strSta;
            arg.uiType = type;
            OnUIUpdate(this, arg);
        }
        
        public void TrpStaUpdate(int[,] trp_num, UIUpdateTypes type)
        {
        	TrpStaArgs arg = new TrpStaArgs();
            arg.nTroopNums = trp_num;
            arg.uiType = type;
            OnUIUpdate(this, arg);
        }
        
        public void UIUpdate(UIUpdateTypes type)
        {
        	UIUpdateArgs arg = new UIUpdateArgs();
        	arg.uiType = type;
        	OnUIUpdate(this, arg);
        }
	}
}
