﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TravianMonitor
{
    public partial class FormTrMonitor : Form
    {
    	TravianAccessor UpCall = null;
    	
        public FormTrMonitor()
        {
            InitializeComponent();
        }

        private void InstructionLoad()
        {
            if (!File.Exists("Intruction"))
            {
                return;
            }
            
            FileStream fs = new FileStream("Intruction", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            this.textBoxInstruction.AppendText(sr.ReadToEnd());
            sr.Close();
        }
        
        private void ReinforcementLoad()
        {
        	List<Target> lsTgs = UpCall.rTgs.LoadReinTgs();
        	DisplayTgs(lsTgs);
        }
        
        private delegate void dlgWriteLog(string log, UIUpdateTypes type);
        private delegate void dlgUIUpdate(UIUpdateTypes type);
        private void InitCallBack()
        {
        	UpCall.OnUIUpdate += new EventHandler<UIUpdateArgs>(CallBack_UIUpdate);
        }

        private void FormTrMonitor_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“usersInfoDataSet.users_info”中。您可以根据需要移动或移除它。
            this.users_infoTableAdapter.Fill(this.usersInfoDataSet.users_info);

            if (TravianAccessor.TrAcsr == null)
            {
                TravianAccessor.TrAcsr = new TravianAccessor();
                UpCall = TravianAccessor.TrAcsr;
            }

            if (UpCall.glbCfg.strSvrURL != "")
            {
                this.textBoxSvrURL.Text = UpCall.glbCfg.strSvrURL;
            }

            if (UpCall.glbCfg.nInterval != 0)
            {
                this.numericUpDownInterval.Value = UpCall.glbCfg.nInterval;
            }

            InstructionLoad();
            ReinforcementLoad();
            InitCallBack();
        }

        void btnModifyServerURL_Click(object sender, EventArgs e)
        {
            string strURL = this.textBoxSvrURL.Text;
            string strInterval = this.numericUpDownInterval.Value.ToString();
            string strReturnDelay = this.numericUpDownReturnDelay.Value.ToString();
            UpCall.glbCfg.SaveOptions(strURL, strInterval, strReturnDelay);
        }
        
        private void DisplayTgs(List<Target> lstTgs)
        {
        	this.comboBoxAllTgs.Items.Clear();
    		foreach (Target tg in lstTgs)
    		{
    			string cood = String.Format(
    				"({0}, {1})", tg.nCoordX.ToString(), tg.nCoordY.ToString());
    			this.comboBoxAllTgs.Items.Add(cood);
    		}
    		
    		this.comboBoxAllTgs.SelectedIndex = lstTgs.Count - 1;
        }
        
        void ButtonAddTgClick(object sender, EventArgs e)
        {
        	try
        	{
        		int nX = Convert.ToInt32(this.textBoxTgX.Text);
        		int nY = Convert.ToInt32(this.textBoxTgY.Text);
        		List<Target> lstTgs = UpCall.rTgs.AddReinTg(nX, nY);
        		
        		DisplayTgs(lstTgs);
        	}
        	catch
        	{}
        }
        
        void ButtonDelTgClick(object sender, EventArgs e)
        {
        	int nSel = this.comboBoxAllTgs.SelectedIndex;
        	if (nSel == -1)
        	{
        		return;
        	}
        	List<Target> lstTgs = UpCall.rTgs.DelReinTg(nSel);
        	
        	DisplayTgs(lstTgs);
        }
        
        void CallBack_UIUpdate(object sender, UIUpdateArgs e)
        {
            try
            {
            	if (e is LogArgs)
            	{
            		LogArgs e_log = e as LogArgs;
                	Invoke(new dlgWriteLog(WriteLog), new object[] { e_log.strLog, e_log.uiType });
            	}
            	else
            	{
            		Invoke(new dlgUIUpdate(UIUpdate), new object[] { e.uiType });
            	}
            }
            catch (Exception)
            { }
        }
        
        private void WriteLog(string log, UIUpdateTypes type)
        {
        	switch (type)
        	{
        		case UIUpdateTypes.TroopsMonitorLog:
        			this.textBoxLog4Monitor.AppendText(log + "\r\n");
        			break;
        			
        		case UIUpdateTypes.TroopsSendingLog:
        			this.textBoxLog4TroopSending.AppendText(log + "\r\n");
        			break;
        	}
        }
        
        private void UIUpdate(UIUpdateTypes type)
        {
        	switch (type)
        	{
        		case UIUpdateTypes.VillageList:
        			DisplayVillagesDetail();
        			break;
        	}
        }
        
        private void DisplayVillagesDetail()
        {
        	if (UpCall.lstAccounts == null)
        		return;
        	
        	listViewTroopsInfo.Items.Clear();
        	foreach (TravianAccount trAccount in UpCall.lstAccounts)
        	{
        		if (trAccount.lstVillages == null)
        			continue;
        		
        		if (trAccount.bIsDead)
        		{
        			this.WriteLog("------------------------------------\r\n"
        			              + "帐号名/密码：" + trAccount.strName
        			              + "/" + trAccount.strPassword + "可能有误，请检查。"
        			              , UIUpdateTypes.TroopsMonitorLog);
        			
        			continue;
        		}
        		
        		foreach (TravianVillage trVillage in trAccount.lstVillages)
        		{
        			ListViewItem lvi = listViewTroopsInfo.Items.Add("[" + TravianData.strTribeName[trAccount.nTribe - 1] + "]" + trAccount.strName);
        			lvi.SubItems.Add(trVillage.strName + "(" + trVillage.nID.ToString() + ")");
        			lvi.SubItems.Add(trVillage.nPosX + "|" + trVillage.nPosY);
        			lvi.SubItems.Add(trVillage.TroopString);
        			string strArrTime = string.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", 
        			                                  trVillage.dtStartTime.Year,
        			                                  trVillage.dtStartTime.Month,
        			                                  trVillage.dtStartTime.Day,
        			                                  trVillage.dtStartTime.Hour,
        			                                  trVillage.dtStartTime.Minute,
        			                                  trVillage.dtStartTime.Second,
        			                                  trVillage.dtStartTime.Millisecond);
        			lvi.SubItems.Add(strArrTime);
        			lvi.SubItems.Add(trVillage.nSquareLvl.ToString());
        		}
        	}
        	
        	UpCall.RemoveDeadAccount();
        }
        
        void BtnRefreshVillagesClick(object sender, EventArgs e)
        {
        	if (UpCall.bIsTaskSet)
        		return;
        	
        	UpCall.lstAccounts.Clear();
        	foreach (UsersInfoDataSet.users_infoRow row in usersInfoDataSet.users_info.Rows)
        	{
        		TravianAccount account = new TravianAccount(row.account, row.password);
        		UpCall.lstAccounts.Add(account);
        	}
        	
        	UpCall.wk_mgr.WkrTaskExec.curTask = new TaskRefreshVillages();
        	UpCall.bIsTaskSet = true;
        }
        
        void BtnCalStartTimeClick(object sender, EventArgs e)
        {
        	if (UpCall.bIsTaskSet)
        		return;
        	
        	List<Target> lstTg = UpCall.rTgs.lstTgs;
        	int nSel = this.comboBoxAllTgs.SelectedIndex;
        	UpCall.wk_mgr.WkrTaskExec.curTask = new TaskCalStartTime(
        		dateTimePickerReachTime.Value,
        		lstTg[nSel].nCoordX,
        		lstTg[nSel].nCoordY);
        	
        	UpCall.bIsTaskSet = true;
        }
        
        void BtnStatisticsClick(object sender, EventArgs e)
        {
        	if (UpCall.bIsTaskSet)
        		return;
        	
        	UpCall.wk_mgr.WkrTaskExec.curTask = new TaskStatistics();
        	
        	UpCall.bIsTaskSet = true;
        }
        
        void BtnClearLog4MonitorClick(object sender, EventArgs e)
        {
        	this.textBoxLog4Monitor.Text = "";
        }
        
        void BtnAddToTroopsArrayClick(object sender, EventArgs e)
        {
        	
        }
    }
}