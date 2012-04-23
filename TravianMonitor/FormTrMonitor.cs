using System;
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
        
        private delegate void dlgWriteLog(string log);
        private delegate void dlgTaskStatus(string sta, UIUpdateTypes type);
        private delegate void dlgTrpSta(int[,] trp_num);
        private delegate void dlgUIUpdate(UIUpdateTypes type);
        
        private void InitCallBack()
        {
        	UpCall.OnUIUpdate += new EventHandler<UIUpdateArgs>(CallBack_UIUpdate);
        }

        private void FormTrMonitor_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“usersInfoDataSet.users_info”中。您可以根据需要移动或移除它。
            this.users_infoTableAdapter.Fill(this.usersInfoDataSet.users_info);
			this.AccNumStripStatusLabel.Text = "帐号数：" + this.usersInfoDataSet.users_info.Rows.Count;
			
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
        	this.Validate();
            this.usersinfoBindingSource.EndEdit();
            SaveAccountsData(DataRowState.Deleted);
            SaveAccountsData(DataRowState.Added);
            SaveAccountsData(DataRowState.Modified);
            usersInfoDataSet.AcceptChanges();
			this.users_infoTableAdapter.Fill(this.usersInfoDataSet.users_info);
            this.AccNumStripStatusLabel.Text = "帐号数：" + this.usersInfoDataSet.users_info.Rows.Count;
            
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
                	Invoke(new dlgWriteLog(WriteLog), new object[] { e_log.strLog });
            	}
            	else if (e is TaskStaArgs)
            	{
            		TaskStaArgs e_sta = e as TaskStaArgs;
            		Invoke(new dlgTaskStatus(TaskStatus), new object[] { e_sta.strSta, e_sta.uiType });
            	}
            	else if (e is TrpStaArgs)
            	{
            		TrpStaArgs s_trp_sta = e as TrpStaArgs;
            		Invoke(new dlgTrpSta(DisplayTroopStatistics), new object[] { s_trp_sta.nTroopNums });
            	}
            	else
            	{
            		Invoke(new dlgUIUpdate(UIUpdate), new object[] { e.uiType });
            	}
            }
            catch (Exception)
            { }
        }
        
        private void WriteLog(string log)
        {
        	this.tbLog.AppendText("[" + DateTime.Now.ToString() + "]" + log + "\r\n");
        }
        
        private void TaskStatus(string sta, UIUpdateTypes type)
        {
        	switch (type)
        	{
        		case UIUpdateTypes.TaskDetail:
        			this.TaskStatusLabel.Text = "状态：" + sta;
        			break;
        			
        		case UIUpdateTypes.TaskProcess:
        			this.GuageStatusLabel.Text = "进度：" + sta;
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
        			
        		case UIUpdateTypes.TroopSendingList:
        			DisplayTroopSendingDetail();
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
        			              );
        			
        			continue;
        		}
        		
        		foreach (TravianVillage trVillage in trAccount.lstVillages)
        		{
        			ListViewItem lvi = listViewTroopsInfo.Items.Add("[" + TravianData.strTribeName[trAccount.nTribe - 1] + "]" + trAccount.strName);
        			lvi.SubItems.Add(trVillage.strName + "(" + trVillage.nID.ToString() + ")");
        			lvi.SubItems.Add(trVillage.nPosX + "|" + trVillage.nPosY);
        			lvi.SubItems.Add(trVillage.TroopString);
        			lvi.SubItems.Add(trVillage.strStartTime);
        			lvi.SubItems.Add(trVillage.strTimeCost);
        		}
        	}
        	
        	listViewTroopsInfo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewTroopsInfo.ResumeLayout();
        	UpCall.RemoveDeadAccounts();
        }
        
        void DisplayTroopSendingDetail()
        {
        	if (UpCall.lstAllVillagesForSndTrps == null)
        		return;
        	
        	listViewTroopSending.Items.Clear();
        	foreach (TravianVillage trVillage in UpCall.lstAllVillagesForSndTrps)
        	{
        		ListViewItem lvi = listViewTroopSending.Items.Add(trVillage.trpSndStatus.ToString());
        		lvi.SubItems.Add(trVillage.reinTg.nCoordX + "|" + trVillage.reinTg.nCoordY);
        		lvi.SubItems.Add(trVillage.strStartTime);
        		lvi.SubItems.Add(trVillage.strReachTime);
        		lvi.SubItems.Add("[" + TravianData.strTribeName[trVillage.UpCall.nTribe - 1] + "]" + trVillage.UpCall.strName);
        		lvi.SubItems.Add(trVillage.strName + "(" + trVillage.nID.ToString() + ")");
        		lvi.SubItems.Add(trVillage.nPosX + "|" + trVillage.nPosY);
        		lvi.SubItems.Add(trVillage.TroopString);
        	}
        	
        	listViewTroopSending.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewTroopSending.ResumeLayout();
        }
        
        void DisplayTroopStatistics(int[,] nTroopNums)
        {
        	this.tbS1.Text = nTroopNums[0, 0].ToString();
        	this.tbS2.Text = nTroopNums[0, 1].ToString();
        	this.tbS3.Text = nTroopNums[0, 2].ToString();
        	this.tbS4.Text = nTroopNums[1, 0].ToString();
        	this.tbS5.Text = nTroopNums[1, 1].ToString();
        	this.tbS6.Text = nTroopNums[1, 2].ToString();
        	this.tbS7.Text = nTroopNums[2, 0].ToString();
        	this.tbS8.Text = nTroopNums[2, 1].ToString();
        	this.tbS9.Text = nTroopNums[2, 2].ToString();
        }
        
        void BtnRefreshVillagesClick(object sender, EventArgs e)
        {
        	if (UpCall.bIsTaskSet)
        		return;
        	
        	UpCall.lstAccounts.Clear();
        	foreach (UsersInfoDataSet.users_infoRow row in usersInfoDataSet.users_info.Rows)
        	{
        		if (row.RowState == DataRowState.Deleted)
        			continue;
        		
        		TravianAccount account = new TravianAccount(row.account, row.password);
        		UpCall.lstAccounts.Add(account);
        	}
        	
        	UpCall.wk_mgr.WkrTaskExec.curTask = new TaskRefreshVillages();
        	TaskStatus("任务" + UpCall.wk_mgr.WkrTaskExec.curTask.strName
        	           + "开始", UIUpdateTypes.TaskDetail);
        	
        	UpCall.bIsAllAcountReset = false;
        	UpCall.bIsTaskSet = true;
        }
        
        void BtnCalStartTimeClick(object sender, EventArgs e)
        {
        	if (UpCall.bIsTaskSet)
        		return;
        	
        	UpCall.RemoveVillagesWithNoDefTroops();
        	
        	List<Target> lstTg = UpCall.rTgs.lstTgs;
        	int nSel = this.comboBoxAllTgs.SelectedIndex;
        	UpCall.wk_mgr.WkrTaskExec.curTask = new TaskCalStartTime(
        		dateTimePickerReachTime.Value,
        		lstTg[nSel].nCoordX,
        		lstTg[nSel].nCoordY);
        	TaskStatus("任务" + UpCall.wk_mgr.WkrTaskExec.curTask.strName
        	           + "开始", UIUpdateTypes.TaskDetail);
        	
        	UpCall.bIsAllAcountReset = false;
        	UpCall.bIsTaskSet = true;
        }
        
        void BtnStatisticsClick(object sender, EventArgs e)
        {
        	if (UpCall.bIsTaskSet)
        		return;
        	
        	UpCall.wk_mgr.WkrTaskExec.curTask = new TaskStatistics();
        	TaskStatus("任务" + UpCall.wk_mgr.WkrTaskExec.curTask.strName
        	           + "开始", UIUpdateTypes.TaskDetail);
        	UpCall.bIsTaskSet = true;
        }
        
        void BtnAddToTroopsArrayClick(object sender, EventArgs e)
        {
        	if (UpCall.bIsTaskSet)
        		return;
        	
        	List<int> lstTravianVillageSelected = new List<int>();
        	for(int i = 0; i < listViewTroopsInfo.SelectedIndices.Count; i++)
        	{
        		lstTravianVillageSelected.Add(listViewTroopsInfo.SelectedIndices[i]);
        	}
        	
        	UpCall.wk_mgr.WkrTaskExec.curTask 
        		= new TaskAddToTroopSending(lstTravianVillageSelected);
        	TaskStatus("任务" + UpCall.wk_mgr.WkrTaskExec.curTask.strName
        	           + "开始", UIUpdateTypes.TaskDetail);
        	UpCall.bIsTaskSet = true;
        }
        
        //  保存操作
        private void SaveAccountsData(DataRowState state)
        {
            UsersInfoDataSet.users_infoDataTable op_set;
            op_set = (UsersInfoDataSet.users_infoDataTable)
                usersInfoDataSet.users_info.GetChanges(state);
            if (op_set == null) return;
            try
            {
                users_infoTableAdapter.Update(op_set);
            }
            catch (System.Exception)
            {
                if (state == DataRowState.Added)
                {
                    MessageBox.Show("添加操作失败！");
                }
                else if (state == DataRowState.Modified)
                {
                    MessageBox.Show("修改操作失败！");
                }
                else if (state == DataRowState.Deleted)
                {
                    MessageBox.Show("删除操作失败！");
                }
            }
        } 
        
        void FormTrMonitorFormClosed(object sender, FormClosedEventArgs e)
        {
        	TravianAccessor.TrAcsr.wk_mgr.WkrTaskExec.AbortThread();
        }
    }
}