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
        
        static string[] strTribeName = {"罗马", "条顿", "高卢"};
        private void DisplayVillagesDetail()
        {
        	if (UpCall.lstAccounts == null)
        		return;
        	
        	foreach (TravianAccount trAccount in UpCall.lstAccounts)
        	{
        		if (trAccount.lstVillages == null)
        			continue;
        		
        		foreach (TravianVillage trVillage in trAccount.lstVillages)
        		{
        			ListViewItem lvi = listViewTroopsInfo.Items.Add("[" + strTribeName[trAccount.nTribe] + "]" + trAccount.strName);
        			lvi.SubItems.Add(trVillage.strName + "(" + trVillage.nID.ToString() + ")");
        			lvi.SubItems.Add(trVillage.nPosX + "|" + trVillage.nPosY);
        			lvi.SubItems.Add(trVillage.TroopString);
        			lvi.SubItems.Add("0000-00-00 00:00:00");
        			lvi.SubItems.Add(trVillage.nSquareLvl.ToString());
        		}
        	}
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
    }
}