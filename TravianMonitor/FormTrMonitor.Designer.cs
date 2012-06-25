namespace TravianMonitor
{
    partial class FormTrMonitor
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        	this.usersinfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
        	this.usersInfoDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
        	this.usersInfoDataSet = new TravianMonitor.UsersInfoDataSet();
        	this.users_infoTableAdapter = new TravianMonitor.UsersInfoDataSetTableAdapters.users_infoTableAdapter();
        	this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        	this.TaskStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        	this.GuageStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        	this.AccNumStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        	this.tabPage2 = new System.Windows.Forms.TabPage();
        	this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
        	this.btnStartStaring = new System.Windows.Forms.Button();
        	this.btnStopStaring = new System.Windows.Forms.Button();
        	this.listViewRaidCheck = new System.Windows.Forms.ListView();
        	this.colHdAcc = new System.Windows.Forms.ColumnHeader();
        	this.colHdVlg = new System.Windows.Forms.ColumnHeader();
        	this.colHdVlgCoord = new System.Windows.Forms.ColumnHeader();
        	this.colHdEnemy = new System.Windows.Forms.ColumnHeader();
        	this.colHdEnemyRace = new System.Windows.Forms.ColumnHeader();
        	this.colHdArrTime = new System.Windows.Forms.ColumnHeader();
        	this.tabPage1 = new System.Windows.Forms.TabPage();
        	this.tbLog = new System.Windows.Forms.TextBox();
        	this.tabPageTroopSending = new System.Windows.Forms.TabPage();
        	this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
        	this.btnStartSendTroops = new System.Windows.Forms.Button();
        	this.btnStopSendTroops = new System.Windows.Forms.Button();
        	this.listViewTroopSending = new System.Windows.Forms.ListView();
        	this.colHdCurStatus = new System.Windows.Forms.ColumnHeader();
        	this.colHdTgCoord = new System.Windows.Forms.ColumnHeader();
        	this.colHdTroopStartTime = new System.Windows.Forms.ColumnHeader();
        	this.colHdTroopReachTime = new System.Windows.Forms.ColumnHeader();
        	this.colHdSrcAccount = new System.Windows.Forms.ColumnHeader();
        	this.colHdSrcVillage = new System.Windows.Forms.ColumnHeader();
        	this.colHdSrcVillageCoord = new System.Windows.Forms.ColumnHeader();
        	this.colHdSrcTroops = new System.Windows.Forms.ColumnHeader();
        	this.tabPageMonitor = new System.Windows.Forms.TabPage();
        	this.listViewTroopsInfo = new System.Windows.Forms.ListView();
        	this.colHdAccount = new System.Windows.Forms.ColumnHeader();
        	this.colHdVillage = new System.Windows.Forms.ColumnHeader();
        	this.colHdCoord = new System.Windows.Forms.ColumnHeader();
        	this.colHdTroops = new System.Windows.Forms.ColumnHeader();
        	this.colHdStartTime = new System.Windows.Forms.ColumnHeader();
        	this.colHdTimeNeeded = new System.Windows.Forms.ColumnHeader();
        	this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
        	this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
        	this.groupBox3 = new System.Windows.Forms.GroupBox();
        	this.dateTimePickerReachTime = new System.Windows.Forms.DateTimePicker();
        	this.groupBox2 = new System.Windows.Forms.GroupBox();
        	this.buttonDelTg = new System.Windows.Forms.Button();
        	this.buttonAddTg = new System.Windows.Forms.Button();
        	this.comboBoxAllTgs = new System.Windows.Forms.ComboBox();
        	this.textBoxTgY = new System.Windows.Forms.TextBox();
        	this.textBoxTgX = new System.Windows.Forms.TextBox();
        	this.label4 = new System.Windows.Forms.Label();
        	this.groupBox4 = new System.Windows.Forms.GroupBox();
        	this.label14 = new System.Windows.Forms.Label();
        	this.btnAddToTroopsArray = new System.Windows.Forms.Button();
        	this.btnCalStartTime = new System.Windows.Forms.Button();
        	this.btnRefreshVillages = new System.Windows.Forms.Button();
        	this.groupBox5 = new System.Windows.Forms.GroupBox();
        	this.tbS8 = new System.Windows.Forms.TextBox();
        	this.tbS5 = new System.Windows.Forms.TextBox();
        	this.tbS2 = new System.Windows.Forms.TextBox();
        	this.tbS9 = new System.Windows.Forms.TextBox();
        	this.tbS6 = new System.Windows.Forms.TextBox();
        	this.tbS3 = new System.Windows.Forms.TextBox();
        	this.tbS7 = new System.Windows.Forms.TextBox();
        	this.tbS4 = new System.Windows.Forms.TextBox();
        	this.tbS1 = new System.Windows.Forms.TextBox();
        	this.label13 = new System.Windows.Forms.Label();
        	this.label10 = new System.Windows.Forms.Label();
        	this.label6 = new System.Windows.Forms.Label();
        	this.label12 = new System.Windows.Forms.Label();
        	this.label11 = new System.Windows.Forms.Label();
        	this.label9 = new System.Windows.Forms.Label();
        	this.label8 = new System.Windows.Forms.Label();
        	this.label7 = new System.Windows.Forms.Label();
        	this.label5 = new System.Windows.Forms.Label();
        	this.btnStatistics = new System.Windows.Forms.Button();
        	this.tabPageUsersInfo = new System.Windows.Forms.TabPage();
        	this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
        	this.dataGridViewUserInfo = new System.Windows.Forms.DataGridView();
        	this.entryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.accountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
        	this.textBoxInstruction = new System.Windows.Forms.TextBox();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.numericUpDownReturnDelay = new System.Windows.Forms.NumericUpDown();
        	this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
        	this.btnModifyServerURL = new System.Windows.Forms.Button();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.label15 = new System.Windows.Forms.Label();
        	this.label1 = new System.Windows.Forms.Label();
        	this.textBoxProxy = new System.Windows.Forms.TextBox();
        	this.textBoxSvrURL = new System.Windows.Forms.TextBox();
        	this.tabControlMainForm = new System.Windows.Forms.TabControl();
        	this.timer1 = new System.Windows.Forms.Timer(this.components);
        	this.label16 = new System.Windows.Forms.Label();
        	((System.ComponentModel.ISupportInitialize)(this.usersinfoBindingSource)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.usersInfoDataSetBindingSource)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.usersInfoDataSet)).BeginInit();
        	this.statusStrip1.SuspendLayout();
        	this.tabPage2.SuspendLayout();
        	this.flowLayoutPanel5.SuspendLayout();
        	this.tabPage1.SuspendLayout();
        	this.tabPageTroopSending.SuspendLayout();
        	this.flowLayoutPanel4.SuspendLayout();
        	this.tabPageMonitor.SuspendLayout();
        	this.flowLayoutPanel2.SuspendLayout();
        	this.flowLayoutPanel3.SuspendLayout();
        	this.groupBox3.SuspendLayout();
        	this.groupBox2.SuspendLayout();
        	this.groupBox4.SuspendLayout();
        	this.groupBox5.SuspendLayout();
        	this.tabPageUsersInfo.SuspendLayout();
        	this.flowLayoutPanel6.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserInfo)).BeginInit();
        	this.flowLayoutPanel1.SuspendLayout();
        	this.groupBox1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.numericUpDownReturnDelay)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
        	this.tabControlMainForm.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// usersinfoBindingSource
        	// 
        	this.usersinfoBindingSource.DataMember = "users_info";
        	this.usersinfoBindingSource.DataSource = this.usersInfoDataSetBindingSource;
        	// 
        	// usersInfoDataSetBindingSource
        	// 
        	this.usersInfoDataSetBindingSource.DataSource = this.usersInfoDataSet;
        	this.usersInfoDataSetBindingSource.Position = 0;
        	// 
        	// usersInfoDataSet
        	// 
        	this.usersInfoDataSet.DataSetName = "UsersInfoDataSet";
        	this.usersInfoDataSet.Namespace = "http://tempuri.org/UsersInfoDataSet.xsd";
        	this.usersInfoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        	// 
        	// users_infoTableAdapter
        	// 
        	this.users_infoTableAdapter.ClearBeforeFill = true;
        	// 
        	// statusStrip1
        	// 
        	this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.TaskStatusLabel,
        	        	        	this.GuageStatusLabel,
        	        	        	this.AccNumStripStatusLabel});
        	this.statusStrip1.Location = new System.Drawing.Point(0, 620);
        	this.statusStrip1.Name = "statusStrip1";
        	this.statusStrip1.Size = new System.Drawing.Size(915, 35);
        	this.statusStrip1.SizingGrip = false;
        	this.statusStrip1.TabIndex = 1;
        	this.statusStrip1.Text = "statusStrip1";
        	// 
        	// TaskStatusLabel
        	// 
        	this.TaskStatusLabel.AutoSize = false;
        	this.TaskStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
        	        	        	| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
        	        	        	| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
        	this.TaskStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.TaskStatusLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.TaskStatusLabel.Name = "TaskStatusLabel";
        	this.TaskStatusLabel.Size = new System.Drawing.Size(500, 30);
        	this.TaskStatusLabel.Text = "状态：";
        	this.TaskStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// GuageStatusLabel
        	// 
        	this.GuageStatusLabel.AutoSize = false;
        	this.GuageStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
        	        	        	| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
        	        	        	| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
        	this.GuageStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.GuageStatusLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.GuageStatusLabel.Name = "GuageStatusLabel";
        	this.GuageStatusLabel.Size = new System.Drawing.Size(200, 30);
        	this.GuageStatusLabel.Spring = true;
        	this.GuageStatusLabel.Text = "进度：";
        	this.GuageStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// AccNumStripStatusLabel
        	// 
        	this.AccNumStripStatusLabel.AutoSize = false;
        	this.AccNumStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
        	        	        	| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
        	        	        	| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
        	this.AccNumStripStatusLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.AccNumStripStatusLabel.Name = "AccNumStripStatusLabel";
        	this.AccNumStripStatusLabel.Size = new System.Drawing.Size(200, 30);
        	this.AccNumStripStatusLabel.Spring = true;
        	this.AccNumStripStatusLabel.Text = "帐号数：";
        	this.AccNumStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// tabPage2
        	// 
        	this.tabPage2.Controls.Add(this.flowLayoutPanel5);
        	this.tabPage2.Controls.Add(this.listViewRaidCheck);
        	this.tabPage2.Location = new System.Drawing.Point(4, 26);
        	this.tabPage2.Name = "tabPage2";
        	this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage2.Size = new System.Drawing.Size(907, 625);
        	this.tabPage2.TabIndex = 6;
        	this.tabPage2.Text = "攻击监控";
        	this.tabPage2.UseVisualStyleBackColor = true;
        	// 
        	// flowLayoutPanel5
        	// 
        	this.flowLayoutPanel5.Controls.Add(this.btnStartStaring);
        	this.flowLayoutPanel5.Controls.Add(this.btnStopStaring);
        	this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Right;
        	this.flowLayoutPanel5.Location = new System.Drawing.Point(799, 3);
        	this.flowLayoutPanel5.Name = "flowLayoutPanel5";
        	this.flowLayoutPanel5.Size = new System.Drawing.Size(105, 619);
        	this.flowLayoutPanel5.TabIndex = 1;
        	// 
        	// btnStartStaring
        	// 
        	this.btnStartStaring.Location = new System.Drawing.Point(3, 3);
        	this.btnStartStaring.Name = "btnStartStaring";
        	this.btnStartStaring.Size = new System.Drawing.Size(101, 37);
        	this.btnStartStaring.TabIndex = 0;
        	this.btnStartStaring.Text = "开始监控";
        	this.btnStartStaring.UseVisualStyleBackColor = true;
        	this.btnStartStaring.Click += new System.EventHandler(this.BtnStartStaringClick);
        	// 
        	// btnStopStaring
        	// 
        	this.btnStopStaring.Location = new System.Drawing.Point(3, 46);
        	this.btnStopStaring.Name = "btnStopStaring";
        	this.btnStopStaring.Size = new System.Drawing.Size(101, 37);
        	this.btnStopStaring.TabIndex = 0;
        	this.btnStopStaring.Text = "停止监控";
        	this.btnStopStaring.UseVisualStyleBackColor = true;
        	this.btnStopStaring.Click += new System.EventHandler(this.BtnStopStaringClick);
        	// 
        	// listViewRaidCheck
        	// 
        	this.listViewRaidCheck.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        	        	        	this.colHdAcc,
        	        	        	this.colHdVlg,
        	        	        	this.colHdVlgCoord,
        	        	        	this.colHdEnemy,
        	        	        	this.colHdEnemyRace,
        	        	        	this.colHdArrTime});
        	this.listViewRaidCheck.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.listViewRaidCheck.FullRowSelect = true;
        	this.listViewRaidCheck.GridLines = true;
        	this.listViewRaidCheck.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
        	this.listViewRaidCheck.Location = new System.Drawing.Point(3, 3);
        	this.listViewRaidCheck.Name = "listViewRaidCheck";
        	this.listViewRaidCheck.Size = new System.Drawing.Size(901, 619);
        	this.listViewRaidCheck.TabIndex = 0;
        	this.listViewRaidCheck.UseCompatibleStateImageBehavior = false;
        	this.listViewRaidCheck.View = System.Windows.Forms.View.Details;
        	// 
        	// colHdAcc
        	// 
        	this.colHdAcc.Text = "帐号";
        	this.colHdAcc.Width = 150;
        	// 
        	// colHdVlg
        	// 
        	this.colHdVlg.Text = "村庄";
        	this.colHdVlg.Width = 158;
        	// 
        	// colHdVlgCoord
        	// 
        	this.colHdVlgCoord.Text = "村庄坐标";
        	this.colHdVlgCoord.Width = 114;
        	// 
        	// colHdEnemy
        	// 
        	this.colHdEnemy.Text = "敌人村庄";
        	this.colHdEnemy.Width = 160;
        	// 
        	// colHdEnemyRace
        	// 
        	this.colHdEnemyRace.Text = "敌人种族";
        	this.colHdEnemyRace.Width = 92;
        	// 
        	// colHdArrTime
        	// 
        	this.colHdArrTime.Text = "剩余时间";
        	this.colHdArrTime.Width = 103;
        	// 
        	// tabPage1
        	// 
        	this.tabPage1.Controls.Add(this.tbLog);
        	this.tabPage1.Location = new System.Drawing.Point(4, 26);
        	this.tabPage1.Name = "tabPage1";
        	this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage1.Size = new System.Drawing.Size(907, 625);
        	this.tabPage1.TabIndex = 3;
        	this.tabPage1.Text = "日志";
        	this.tabPage1.UseVisualStyleBackColor = true;
        	// 
        	// tbLog
        	// 
        	this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tbLog.Location = new System.Drawing.Point(3, 3);
        	this.tbLog.Multiline = true;
        	this.tbLog.Name = "tbLog";
        	this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.tbLog.Size = new System.Drawing.Size(901, 619);
        	this.tbLog.TabIndex = 0;
        	// 
        	// tabPageTroopSending
        	// 
        	this.tabPageTroopSending.Controls.Add(this.flowLayoutPanel4);
        	this.tabPageTroopSending.Controls.Add(this.listViewTroopSending);
        	this.tabPageTroopSending.Location = new System.Drawing.Point(4, 26);
        	this.tabPageTroopSending.Name = "tabPageTroopSending";
        	this.tabPageTroopSending.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPageTroopSending.Size = new System.Drawing.Size(907, 625);
        	this.tabPageTroopSending.TabIndex = 2;
        	this.tabPageTroopSending.Text = "发兵插防";
        	this.tabPageTroopSending.UseVisualStyleBackColor = true;
        	// 
        	// flowLayoutPanel4
        	// 
        	this.flowLayoutPanel4.Controls.Add(this.btnStartSendTroops);
        	this.flowLayoutPanel4.Controls.Add(this.btnStopSendTroops);
        	this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 542);
        	this.flowLayoutPanel4.Name = "flowLayoutPanel4";
        	this.flowLayoutPanel4.Size = new System.Drawing.Size(901, 80);
        	this.flowLayoutPanel4.TabIndex = 1;
        	// 
        	// btnStartSendTroops
        	// 
        	this.btnStartSendTroops.Location = new System.Drawing.Point(3, 3);
        	this.btnStartSendTroops.Name = "btnStartSendTroops";
        	this.btnStartSendTroops.Size = new System.Drawing.Size(83, 46);
        	this.btnStartSendTroops.TabIndex = 0;
        	this.btnStartSendTroops.Text = "开始发兵";
        	this.btnStartSendTroops.UseVisualStyleBackColor = true;
        	// 
        	// btnStopSendTroops
        	// 
        	this.btnStopSendTroops.Location = new System.Drawing.Point(92, 3);
        	this.btnStopSendTroops.Name = "btnStopSendTroops";
        	this.btnStopSendTroops.Size = new System.Drawing.Size(83, 46);
        	this.btnStopSendTroops.TabIndex = 0;
        	this.btnStopSendTroops.Text = "停止发兵";
        	this.btnStopSendTroops.UseVisualStyleBackColor = true;
        	// 
        	// listViewTroopSending
        	// 
        	this.listViewTroopSending.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        	        	        	this.colHdCurStatus,
        	        	        	this.colHdTgCoord,
        	        	        	this.colHdTroopStartTime,
        	        	        	this.colHdTroopReachTime,
        	        	        	this.colHdSrcAccount,
        	        	        	this.colHdSrcVillage,
        	        	        	this.colHdSrcVillageCoord,
        	        	        	this.colHdSrcTroops});
        	this.listViewTroopSending.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.listViewTroopSending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.listViewTroopSending.FullRowSelect = true;
        	this.listViewTroopSending.GridLines = true;
        	this.listViewTroopSending.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
        	this.listViewTroopSending.Location = new System.Drawing.Point(3, 3);
        	this.listViewTroopSending.Name = "listViewTroopSending";
        	this.listViewTroopSending.Size = new System.Drawing.Size(901, 619);
        	this.listViewTroopSending.TabIndex = 0;
        	this.listViewTroopSending.UseCompatibleStateImageBehavior = false;
        	this.listViewTroopSending.View = System.Windows.Forms.View.Details;
        	// 
        	// colHdCurStatus
        	// 
        	this.colHdCurStatus.Text = "当前状态";
        	this.colHdCurStatus.Width = 99;
        	// 
        	// colHdTgCoord
        	// 
        	this.colHdTgCoord.Text = "目标坐标";
        	this.colHdTgCoord.Width = 75;
        	// 
        	// colHdTroopStartTime
        	// 
        	this.colHdTroopStartTime.Text = "出发时刻";
        	this.colHdTroopStartTime.Width = 110;
        	// 
        	// colHdTroopReachTime
        	// 
        	this.colHdTroopReachTime.Text = "到达时刻";
        	this.colHdTroopReachTime.Width = 112;
        	// 
        	// colHdSrcAccount
        	// 
        	this.colHdSrcAccount.Text = "发兵帐号";
        	this.colHdSrcAccount.Width = 80;
        	// 
        	// colHdSrcVillage
        	// 
        	this.colHdSrcVillage.Text = "发兵村（ID）";
        	this.colHdSrcVillage.Width = 132;
        	// 
        	// colHdSrcVillageCoord
        	// 
        	this.colHdSrcVillageCoord.Text = "兵村坐标";
        	this.colHdSrcVillageCoord.Width = 86;
        	// 
        	// colHdSrcTroops
        	// 
        	this.colHdSrcTroops.Text = "军队信息";
        	this.colHdSrcTroops.Width = 226;
        	// 
        	// tabPageMonitor
        	// 
        	this.tabPageMonitor.Controls.Add(this.listViewTroopsInfo);
        	this.tabPageMonitor.Controls.Add(this.flowLayoutPanel2);
        	this.tabPageMonitor.Location = new System.Drawing.Point(4, 26);
        	this.tabPageMonitor.Name = "tabPageMonitor";
        	this.tabPageMonitor.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPageMonitor.Size = new System.Drawing.Size(907, 625);
        	this.tabPageMonitor.TabIndex = 1;
        	this.tabPageMonitor.Text = "兵力情况";
        	this.tabPageMonitor.UseVisualStyleBackColor = true;
        	// 
        	// listViewTroopsInfo
        	// 
        	this.listViewTroopsInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        	        	        	this.colHdAccount,
        	        	        	this.colHdVillage,
        	        	        	this.colHdCoord,
        	        	        	this.colHdTroops,
        	        	        	this.colHdStartTime,
        	        	        	this.colHdTimeNeeded});
        	this.listViewTroopsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.listViewTroopsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.listViewTroopsInfo.FullRowSelect = true;
        	this.listViewTroopsInfo.GridLines = true;
        	this.listViewTroopsInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
        	this.listViewTroopsInfo.Location = new System.Drawing.Point(3, 3);
        	this.listViewTroopsInfo.Name = "listViewTroopsInfo";
        	this.listViewTroopsInfo.Size = new System.Drawing.Size(563, 619);
        	this.listViewTroopsInfo.TabIndex = 1;
        	this.listViewTroopsInfo.UseCompatibleStateImageBehavior = false;
        	this.listViewTroopsInfo.View = System.Windows.Forms.View.Details;
        	// 
        	// colHdAccount
        	// 
        	this.colHdAccount.Text = "帐号名";
        	this.colHdAccount.Width = 80;
        	// 
        	// colHdVillage
        	// 
        	this.colHdVillage.Text = "村庄（ID）";
        	this.colHdVillage.Width = 80;
        	// 
        	// colHdCoord
        	// 
        	this.colHdCoord.Text = "村庄坐标";
        	// 
        	// colHdTroops
        	// 
        	this.colHdTroops.Text = "军队信息";
        	this.colHdTroops.Width = 170;
        	// 
        	// colHdStartTime
        	// 
        	this.colHdStartTime.Text = "发兵时刻";
        	this.colHdStartTime.Width = 100;
        	// 
        	// colHdTimeNeeded
        	// 
        	this.colHdTimeNeeded.Text = "行程时间";
        	this.colHdTimeNeeded.Width = 80;
        	// 
        	// flowLayoutPanel2
        	// 
        	this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
        	this.flowLayoutPanel2.Controls.Add(this.groupBox4);
        	this.flowLayoutPanel2.Controls.Add(this.groupBox5);
        	this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
        	this.flowLayoutPanel2.Location = new System.Drawing.Point(566, 3);
        	this.flowLayoutPanel2.Name = "flowLayoutPanel2";
        	this.flowLayoutPanel2.Size = new System.Drawing.Size(338, 619);
        	this.flowLayoutPanel2.TabIndex = 2;
        	// 
        	// flowLayoutPanel3
        	// 
        	this.flowLayoutPanel3.Controls.Add(this.groupBox3);
        	this.flowLayoutPanel3.Controls.Add(this.groupBox2);
        	this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
        	this.flowLayoutPanel3.Name = "flowLayoutPanel3";
        	this.flowLayoutPanel3.Size = new System.Drawing.Size(330, 145);
        	this.flowLayoutPanel3.TabIndex = 1;
        	// 
        	// groupBox3
        	// 
        	this.groupBox3.Controls.Add(this.dateTimePickerReachTime);
        	this.groupBox3.Location = new System.Drawing.Point(3, 3);
        	this.groupBox3.Name = "groupBox3";
        	this.groupBox3.Size = new System.Drawing.Size(327, 59);
        	this.groupBox3.TabIndex = 5;
        	this.groupBox3.TabStop = false;
        	this.groupBox3.Text = "选择部队到达时刻";
        	// 
        	// dateTimePickerReachTime
        	// 
        	this.dateTimePickerReachTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        	this.dateTimePickerReachTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.dateTimePickerReachTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        	this.dateTimePickerReachTime.Location = new System.Drawing.Point(13, 27);
        	this.dateTimePickerReachTime.Name = "dateTimePickerReachTime";
        	this.dateTimePickerReachTime.Size = new System.Drawing.Size(168, 21);
        	this.dateTimePickerReachTime.TabIndex = 4;
        	// 
        	// groupBox2
        	// 
        	this.groupBox2.Controls.Add(this.buttonDelTg);
        	this.groupBox2.Controls.Add(this.buttonAddTg);
        	this.groupBox2.Controls.Add(this.comboBoxAllTgs);
        	this.groupBox2.Controls.Add(this.textBoxTgY);
        	this.groupBox2.Controls.Add(this.textBoxTgX);
        	this.groupBox2.Controls.Add(this.label4);
        	this.groupBox2.Location = new System.Drawing.Point(3, 68);
        	this.groupBox2.Name = "groupBox2";
        	this.groupBox2.Size = new System.Drawing.Size(327, 77);
        	this.groupBox2.TabIndex = 0;
        	this.groupBox2.TabStop = false;
        	this.groupBox2.Text = "增援目标";
        	// 
        	// buttonDelTg
        	// 
        	this.buttonDelTg.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.buttonDelTg.Location = new System.Drawing.Point(269, 27);
        	this.buttonDelTg.Name = "buttonDelTg";
        	this.buttonDelTg.Size = new System.Drawing.Size(51, 26);
        	this.buttonDelTg.TabIndex = 3;
        	this.buttonDelTg.Text = "删除";
        	this.buttonDelTg.UseVisualStyleBackColor = true;
        	this.buttonDelTg.Click += new System.EventHandler(this.ButtonDelTgClick);
        	// 
        	// buttonAddTg
        	// 
        	this.buttonAddTg.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.buttonAddTg.Location = new System.Drawing.Point(119, 28);
        	this.buttonAddTg.Name = "buttonAddTg";
        	this.buttonAddTg.Size = new System.Drawing.Size(49, 26);
        	this.buttonAddTg.TabIndex = 3;
        	this.buttonAddTg.Text = "增加坐标";
        	this.buttonAddTg.UseVisualStyleBackColor = true;
        	this.buttonAddTg.Click += new System.EventHandler(this.ButtonAddTgClick);
        	// 
        	// comboBoxAllTgs
        	// 
        	this.comboBoxAllTgs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.comboBoxAllTgs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.comboBoxAllTgs.FormattingEnabled = true;
        	this.comboBoxAllTgs.Location = new System.Drawing.Point(174, 28);
        	this.comboBoxAllTgs.Name = "comboBoxAllTgs";
        	this.comboBoxAllTgs.Size = new System.Drawing.Size(89, 25);
        	this.comboBoxAllTgs.TabIndex = 2;
        	// 
        	// textBoxTgY
        	// 
        	this.textBoxTgY.Location = new System.Drawing.Point(71, 29);
        	this.textBoxTgY.Name = "textBoxTgY";
        	this.textBoxTgY.Size = new System.Drawing.Size(44, 23);
        	this.textBoxTgY.TabIndex = 1;
        	// 
        	// textBoxTgX
        	// 
        	this.textBoxTgX.Location = new System.Drawing.Point(13, 29);
        	this.textBoxTgX.Name = "textBoxTgX";
        	this.textBoxTgX.Size = new System.Drawing.Size(44, 23);
        	this.textBoxTgX.TabIndex = 1;
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(59, 32);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(11, 17);
        	this.label4.TabIndex = 0;
        	this.label4.Text = "|";
        	// 
        	// groupBox4
        	// 
        	this.groupBox4.Controls.Add(this.label14);
        	this.groupBox4.Controls.Add(this.btnAddToTroopsArray);
        	this.groupBox4.Controls.Add(this.btnCalStartTime);
        	this.groupBox4.Controls.Add(this.btnRefreshVillages);
        	this.groupBox4.Location = new System.Drawing.Point(3, 154);
        	this.groupBox4.Name = "groupBox4";
        	this.groupBox4.Size = new System.Drawing.Size(330, 135);
        	this.groupBox4.TabIndex = 2;
        	this.groupBox4.TabStop = false;
        	this.groupBox4.Text = "功能";
        	// 
        	// label14
        	// 
        	this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label14.Location = new System.Drawing.Point(16, 87);
        	this.label14.Name = "label14";
        	this.label14.Size = new System.Drawing.Size(299, 42);
        	this.label14.TabIndex = 4;
        	this.label14.Text = "添加到发兵队列时，需要先选中发兵村（按ctrl键可多选），再添加到出兵队列";
        	// 
        	// btnAddToTroopsArray
        	// 
        	this.btnAddToTroopsArray.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.btnAddToTroopsArray.Location = new System.Drawing.Point(224, 32);
        	this.btnAddToTroopsArray.Name = "btnAddToTroopsArray";
        	this.btnAddToTroopsArray.Size = new System.Drawing.Size(91, 40);
        	this.btnAddToTroopsArray.TabIndex = 3;
        	this.btnAddToTroopsArray.Text = "加入出兵队列";
        	this.btnAddToTroopsArray.UseVisualStyleBackColor = true;
        	this.btnAddToTroopsArray.Click += new System.EventHandler(this.BtnAddToTroopsArrayClick);
        	// 
        	// btnCalStartTime
        	// 
        	this.btnCalStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.btnCalStartTime.Location = new System.Drawing.Point(119, 32);
        	this.btnCalStartTime.Name = "btnCalStartTime";
        	this.btnCalStartTime.Size = new System.Drawing.Size(91, 40);
        	this.btnCalStartTime.TabIndex = 3;
        	this.btnCalStartTime.Text = "获取行程时间";
        	this.btnCalStartTime.UseVisualStyleBackColor = true;
        	this.btnCalStartTime.Click += new System.EventHandler(this.BtnCalStartTimeClick);
        	// 
        	// btnRefreshVillages
        	// 
        	this.btnRefreshVillages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.btnRefreshVillages.Location = new System.Drawing.Point(14, 32);
        	this.btnRefreshVillages.Name = "btnRefreshVillages";
        	this.btnRefreshVillages.Size = new System.Drawing.Size(91, 40);
        	this.btnRefreshVillages.TabIndex = 3;
        	this.btnRefreshVillages.Text = "刷新所有村庄";
        	this.btnRefreshVillages.UseVisualStyleBackColor = true;
        	this.btnRefreshVillages.Click += new System.EventHandler(this.BtnRefreshVillagesClick);
        	// 
        	// groupBox5
        	// 
        	this.groupBox5.Controls.Add(this.tbS8);
        	this.groupBox5.Controls.Add(this.tbS5);
        	this.groupBox5.Controls.Add(this.tbS2);
        	this.groupBox5.Controls.Add(this.tbS9);
        	this.groupBox5.Controls.Add(this.tbS6);
        	this.groupBox5.Controls.Add(this.tbS3);
        	this.groupBox5.Controls.Add(this.tbS7);
        	this.groupBox5.Controls.Add(this.tbS4);
        	this.groupBox5.Controls.Add(this.tbS1);
        	this.groupBox5.Controls.Add(this.label13);
        	this.groupBox5.Controls.Add(this.label10);
        	this.groupBox5.Controls.Add(this.label6);
        	this.groupBox5.Controls.Add(this.label12);
        	this.groupBox5.Controls.Add(this.label11);
        	this.groupBox5.Controls.Add(this.label9);
        	this.groupBox5.Controls.Add(this.label8);
        	this.groupBox5.Controls.Add(this.label7);
        	this.groupBox5.Controls.Add(this.label5);
        	this.groupBox5.Controls.Add(this.btnStatistics);
        	this.groupBox5.Location = new System.Drawing.Point(3, 295);
        	this.groupBox5.Name = "groupBox5";
        	this.groupBox5.Size = new System.Drawing.Size(330, 277);
        	this.groupBox5.TabIndex = 3;
        	this.groupBox5.TabStop = false;
        	this.groupBox5.Text = "统计";
        	// 
        	// tbS8
        	// 
        	this.tbS8.BackColor = System.Drawing.Color.White;
        	this.tbS8.Location = new System.Drawing.Point(119, 190);
        	this.tbS8.Name = "tbS8";
        	this.tbS8.ReadOnly = true;
        	this.tbS8.Size = new System.Drawing.Size(81, 23);
        	this.tbS8.TabIndex = 5;
        	// 
        	// tbS5
        	// 
        	this.tbS5.BackColor = System.Drawing.Color.White;
        	this.tbS5.Location = new System.Drawing.Point(119, 122);
        	this.tbS5.Name = "tbS5";
        	this.tbS5.ReadOnly = true;
        	this.tbS5.Size = new System.Drawing.Size(81, 23);
        	this.tbS5.TabIndex = 5;
        	// 
        	// tbS2
        	// 
        	this.tbS2.BackColor = System.Drawing.Color.White;
        	this.tbS2.Location = new System.Drawing.Point(119, 54);
        	this.tbS2.Name = "tbS2";
        	this.tbS2.ReadOnly = true;
        	this.tbS2.Size = new System.Drawing.Size(81, 23);
        	this.tbS2.TabIndex = 5;
        	// 
        	// tbS9
        	// 
        	this.tbS9.BackColor = System.Drawing.Color.White;
        	this.tbS9.Location = new System.Drawing.Point(224, 190);
        	this.tbS9.Name = "tbS9";
        	this.tbS9.ReadOnly = true;
        	this.tbS9.Size = new System.Drawing.Size(81, 23);
        	this.tbS9.TabIndex = 5;
        	// 
        	// tbS6
        	// 
        	this.tbS6.BackColor = System.Drawing.Color.White;
        	this.tbS6.Location = new System.Drawing.Point(224, 122);
        	this.tbS6.Name = "tbS6";
        	this.tbS6.ReadOnly = true;
        	this.tbS6.Size = new System.Drawing.Size(81, 23);
        	this.tbS6.TabIndex = 5;
        	// 
        	// tbS3
        	// 
        	this.tbS3.BackColor = System.Drawing.Color.White;
        	this.tbS3.Location = new System.Drawing.Point(224, 54);
        	this.tbS3.Name = "tbS3";
        	this.tbS3.ReadOnly = true;
        	this.tbS3.Size = new System.Drawing.Size(81, 23);
        	this.tbS3.TabIndex = 5;
        	// 
        	// tbS7
        	// 
        	this.tbS7.BackColor = System.Drawing.Color.White;
        	this.tbS7.Location = new System.Drawing.Point(16, 190);
        	this.tbS7.Name = "tbS7";
        	this.tbS7.ReadOnly = true;
        	this.tbS7.Size = new System.Drawing.Size(81, 23);
        	this.tbS7.TabIndex = 5;
        	// 
        	// tbS4
        	// 
        	this.tbS4.BackColor = System.Drawing.Color.White;
        	this.tbS4.Location = new System.Drawing.Point(16, 122);
        	this.tbS4.Name = "tbS4";
        	this.tbS4.ReadOnly = true;
        	this.tbS4.Size = new System.Drawing.Size(81, 23);
        	this.tbS4.TabIndex = 5;
        	// 
        	// tbS1
        	// 
        	this.tbS1.BackColor = System.Drawing.Color.White;
        	this.tbS1.Location = new System.Drawing.Point(16, 54);
        	this.tbS1.Name = "tbS1";
        	this.tbS1.ReadOnly = true;
        	this.tbS1.Size = new System.Drawing.Size(81, 23);
        	this.tbS1.TabIndex = 5;
        	// 
        	// label13
        	// 
        	this.label13.Location = new System.Drawing.Point(119, 165);
        	this.label13.Name = "label13";
        	this.label13.Size = new System.Drawing.Size(57, 23);
        	this.label13.TabIndex = 4;
        	this.label13.Text = "德骑";
        	// 
        	// label10
        	// 
        	this.label10.Location = new System.Drawing.Point(119, 97);
        	this.label10.Name = "label10";
        	this.label10.Size = new System.Drawing.Size(57, 23);
        	this.label10.TabIndex = 4;
        	this.label10.Text = "圣骑";
        	// 
        	// label6
        	// 
        	this.label6.Location = new System.Drawing.Point(119, 29);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(57, 23);
        	this.label6.TabIndex = 4;
        	this.label6.Text = "禁卫";
        	// 
        	// label12
        	// 
        	this.label12.Location = new System.Drawing.Point(16, 165);
        	this.label12.Name = "label12";
        	this.label12.Size = new System.Drawing.Size(57, 23);
        	this.label12.TabIndex = 4;
        	this.label12.Text = "方阵";
        	// 
        	// label11
        	// 
        	this.label11.Location = new System.Drawing.Point(224, 165);
        	this.label11.Name = "label11";
        	this.label11.Size = new System.Drawing.Size(57, 23);
        	this.label11.TabIndex = 4;
        	this.label11.Text = "海骑";
        	// 
        	// label9
        	// 
        	this.label9.Location = new System.Drawing.Point(16, 97);
        	this.label9.Name = "label9";
        	this.label9.Size = new System.Drawing.Size(57, 23);
        	this.label9.TabIndex = 4;
        	this.label9.Text = "矛兵";
        	// 
        	// label8
        	// 
        	this.label8.Location = new System.Drawing.Point(224, 97);
        	this.label8.Name = "label8";
        	this.label8.Size = new System.Drawing.Size(57, 23);
        	this.label8.TabIndex = 4;
        	this.label8.Text = "日骑";
        	// 
        	// label7
        	// 
        	this.label7.Location = new System.Drawing.Point(16, 29);
        	this.label7.Name = "label7";
        	this.label7.Size = new System.Drawing.Size(57, 23);
        	this.label7.TabIndex = 4;
        	this.label7.Text = "古罗";
        	// 
        	// label5
        	// 
        	this.label5.Location = new System.Drawing.Point(224, 29);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(57, 23);
        	this.label5.TabIndex = 4;
        	this.label5.Text = "将骑";
        	// 
        	// btnStatistics
        	// 
        	this.btnStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.btnStatistics.Location = new System.Drawing.Point(119, 224);
        	this.btnStatistics.Name = "btnStatistics";
        	this.btnStatistics.Size = new System.Drawing.Size(91, 40);
        	this.btnStatistics.TabIndex = 3;
        	this.btnStatistics.Text = "统计兵力";
        	this.btnStatistics.UseVisualStyleBackColor = true;
        	this.btnStatistics.Click += new System.EventHandler(this.BtnStatisticsClick);
        	// 
        	// tabPageUsersInfo
        	// 
        	this.tabPageUsersInfo.Controls.Add(this.flowLayoutPanel6);
        	this.tabPageUsersInfo.Location = new System.Drawing.Point(4, 26);
        	this.tabPageUsersInfo.Name = "tabPageUsersInfo";
        	this.tabPageUsersInfo.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPageUsersInfo.Size = new System.Drawing.Size(907, 625);
        	this.tabPageUsersInfo.TabIndex = 0;
        	this.tabPageUsersInfo.Text = "帐号管理";
        	this.tabPageUsersInfo.UseVisualStyleBackColor = true;
        	// 
        	// flowLayoutPanel6
        	// 
        	this.flowLayoutPanel6.Controls.Add(this.dataGridViewUserInfo);
        	this.flowLayoutPanel6.Controls.Add(this.flowLayoutPanel1);
        	this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 3);
        	this.flowLayoutPanel6.Name = "flowLayoutPanel6";
        	this.flowLayoutPanel6.Size = new System.Drawing.Size(901, 619);
        	this.flowLayoutPanel6.TabIndex = 2;
        	// 
        	// dataGridViewUserInfo
        	// 
        	this.dataGridViewUserInfo.AutoGenerateColumns = false;
        	this.dataGridViewUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dataGridViewUserInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.entryDataGridViewTextBoxColumn,
        	        	        	this.accountDataGridViewTextBoxColumn,
        	        	        	this.passwordDataGridViewTextBoxColumn});
        	this.dataGridViewUserInfo.DataSource = this.usersinfoBindingSource;
        	this.dataGridViewUserInfo.Dock = System.Windows.Forms.DockStyle.Left;
        	this.dataGridViewUserInfo.Location = new System.Drawing.Point(3, 3);
        	this.dataGridViewUserInfo.Name = "dataGridViewUserInfo";
        	this.dataGridViewUserInfo.RowTemplate.Height = 23;
        	this.dataGridViewUserInfo.Size = new System.Drawing.Size(571, 585);
        	this.dataGridViewUserInfo.TabIndex = 0;
        	// 
        	// entryDataGridViewTextBoxColumn
        	// 
        	this.entryDataGridViewTextBoxColumn.DataPropertyName = "entry";
        	dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
        	this.entryDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
        	this.entryDataGridViewTextBoxColumn.HeaderText = "顺序号";
        	this.entryDataGridViewTextBoxColumn.Name = "entryDataGridViewTextBoxColumn";
        	this.entryDataGridViewTextBoxColumn.ReadOnly = true;
        	this.entryDataGridViewTextBoxColumn.Visible = false;
        	this.entryDataGridViewTextBoxColumn.Width = 117;
        	// 
        	// accountDataGridViewTextBoxColumn
        	// 
        	this.accountDataGridViewTextBoxColumn.DataPropertyName = "account";
        	this.accountDataGridViewTextBoxColumn.HeaderText = "帐号名";
        	this.accountDataGridViewTextBoxColumn.Name = "accountDataGridViewTextBoxColumn";
        	this.accountDataGridViewTextBoxColumn.Width = 200;
        	// 
        	// passwordDataGridViewTextBoxColumn
        	// 
        	this.passwordDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.passwordDataGridViewTextBoxColumn.DataPropertyName = "password";
        	this.passwordDataGridViewTextBoxColumn.HeaderText = "密码";
        	this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
        	// 
        	// flowLayoutPanel1
        	// 
        	this.flowLayoutPanel1.Controls.Add(this.textBoxInstruction);
        	this.flowLayoutPanel1.Controls.Add(this.groupBox1);
        	this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
        	this.flowLayoutPanel1.Location = new System.Drawing.Point(580, 3);
        	this.flowLayoutPanel1.Name = "flowLayoutPanel1";
        	this.flowLayoutPanel1.Size = new System.Drawing.Size(317, 585);
        	this.flowLayoutPanel1.TabIndex = 1;
        	// 
        	// textBoxInstruction
        	// 
        	this.textBoxInstruction.Dock = System.Windows.Forms.DockStyle.Top;
        	this.textBoxInstruction.Location = new System.Drawing.Point(3, 3);
        	this.textBoxInstruction.Multiline = true;
        	this.textBoxInstruction.Name = "textBoxInstruction";
        	this.textBoxInstruction.ReadOnly = true;
        	this.textBoxInstruction.Size = new System.Drawing.Size(309, 223);
        	this.textBoxInstruction.TabIndex = 1;
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.numericUpDownReturnDelay);
        	this.groupBox1.Controls.Add(this.numericUpDownInterval);
        	this.groupBox1.Controls.Add(this.btnModifyServerURL);
        	this.groupBox1.Controls.Add(this.label2);
        	this.groupBox1.Controls.Add(this.label3);
        	this.groupBox1.Controls.Add(this.label16);
        	this.groupBox1.Controls.Add(this.label15);
        	this.groupBox1.Controls.Add(this.label1);
        	this.groupBox1.Controls.Add(this.textBoxProxy);
        	this.groupBox1.Controls.Add(this.textBoxSvrURL);
        	this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.groupBox1.Location = new System.Drawing.Point(3, 232);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(311, 345);
        	this.groupBox1.TabIndex = 0;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "基本设置";
        	// 
        	// numericUpDownReturnDelay
        	// 
        	this.numericUpDownReturnDelay.Location = new System.Drawing.Point(38, 196);
        	this.numericUpDownReturnDelay.Maximum = new decimal(new int[] {
        	        	        	120,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.numericUpDownReturnDelay.Minimum = new decimal(new int[] {
        	        	        	5,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.numericUpDownReturnDelay.Name = "numericUpDownReturnDelay";
        	this.numericUpDownReturnDelay.Size = new System.Drawing.Size(222, 23);
        	this.numericUpDownReturnDelay.TabIndex = 3;
        	this.numericUpDownReturnDelay.Value = new decimal(new int[] {
        	        	        	30,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	// 
        	// numericUpDownInterval
        	// 
        	this.numericUpDownInterval.Location = new System.Drawing.Point(38, 128);
        	this.numericUpDownInterval.Maximum = new decimal(new int[] {
        	        	        	120,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.numericUpDownInterval.Minimum = new decimal(new int[] {
        	        	        	5,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.numericUpDownInterval.Name = "numericUpDownInterval";
        	this.numericUpDownInterval.Size = new System.Drawing.Size(222, 23);
        	this.numericUpDownInterval.TabIndex = 3;
        	this.numericUpDownInterval.Value = new decimal(new int[] {
        	        	        	20,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	// 
        	// btnModifyServerURL
        	// 
        	this.btnModifyServerURL.Location = new System.Drawing.Point(84, 307);
        	this.btnModifyServerURL.Name = "btnModifyServerURL";
        	this.btnModifyServerURL.Size = new System.Drawing.Size(148, 32);
        	this.btnModifyServerURL.TabIndex = 2;
        	this.btnModifyServerURL.Text = "确认帐号和设置修改";
        	this.btnModifyServerURL.UseVisualStyleBackColor = true;
        	this.btnModifyServerURL.Click += new System.EventHandler(this.btnModifyServerURL_Click);
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(12, 99);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(162, 17);
        	this.label2.TabIndex = 1;
        	this.label2.Text = "扫描时间间隔（分钟）：";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(12, 166);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(190, 17);
        	this.label3.TabIndex = 1;
        	this.label3.Text = "部队撤回的延迟时间（秒）：";
        	// 
        	// label15
        	// 
        	this.label15.AutoSize = true;
        	this.label15.Location = new System.Drawing.Point(12, 234);
        	this.label15.Name = "label15";
        	this.label15.Size = new System.Drawing.Size(120, 17);
        	this.label15.TabIndex = 1;
        	this.label15.Text = "代理服务器地址：";
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(12, 32);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(260, 17);
        	this.label1.TabIndex = 1;
        	this.label1.Text = "游戏服务器的地址（如ts1.travian.cc）：";
        	// 
        	// textBoxProxy
        	// 
        	this.textBoxProxy.Location = new System.Drawing.Point(38, 278);
        	this.textBoxProxy.Name = "textBoxProxy";
        	this.textBoxProxy.Size = new System.Drawing.Size(222, 23);
        	this.textBoxProxy.TabIndex = 0;
        	// 
        	// textBoxSvrURL
        	// 
        	this.textBoxSvrURL.Location = new System.Drawing.Point(38, 61);
        	this.textBoxSvrURL.Name = "textBoxSvrURL";
        	this.textBoxSvrURL.Size = new System.Drawing.Size(222, 23);
        	this.textBoxSvrURL.TabIndex = 0;
        	this.textBoxSvrURL.Text = "ts1.travian.cc";
        	// 
        	// tabControlMainForm
        	// 
        	this.tabControlMainForm.Controls.Add(this.tabPageUsersInfo);
        	this.tabControlMainForm.Controls.Add(this.tabPageMonitor);
        	this.tabControlMainForm.Controls.Add(this.tabPageTroopSending);
        	this.tabControlMainForm.Controls.Add(this.tabPage2);
        	this.tabControlMainForm.Controls.Add(this.tabPage1);
        	this.tabControlMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tabControlMainForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.tabControlMainForm.Location = new System.Drawing.Point(0, 0);
        	this.tabControlMainForm.Name = "tabControlMainForm";
        	this.tabControlMainForm.SelectedIndex = 0;
        	this.tabControlMainForm.Size = new System.Drawing.Size(915, 655);
        	this.tabControlMainForm.TabIndex = 3;
        	// 
        	// timer1
        	// 
        	this.timer1.Enabled = true;
        	this.timer1.Interval = 5000;
        	this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
        	// 
        	// label16
        	// 
        	this.label16.AutoSize = true;
        	this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label16.Location = new System.Drawing.Point(12, 255);
        	this.label16.Name = "label16";
        	this.label16.Size = new System.Drawing.Size(260, 15);
        	this.label16.TabIndex = 1;
        	this.label16.Text = "与IE相同的话就填IE，否则如 192.168.0.1:8080";
        	// 
        	// FormTrMonitor
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(915, 655);
        	this.Controls.Add(this.statusStrip1);
        	this.Controls.Add(this.tabControlMainForm);
        	this.Name = "FormTrMonitor";
        	this.Text = "Travian插秒工具";
        	this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        	this.Load += new System.EventHandler(this.FormTrMonitor_Load);
        	this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTrMonitorFormClosed);
        	((System.ComponentModel.ISupportInitialize)(this.usersinfoBindingSource)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.usersInfoDataSetBindingSource)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.usersInfoDataSet)).EndInit();
        	this.statusStrip1.ResumeLayout(false);
        	this.statusStrip1.PerformLayout();
        	this.tabPage2.ResumeLayout(false);
        	this.flowLayoutPanel5.ResumeLayout(false);
        	this.tabPage1.ResumeLayout(false);
        	this.tabPage1.PerformLayout();
        	this.tabPageTroopSending.ResumeLayout(false);
        	this.flowLayoutPanel4.ResumeLayout(false);
        	this.tabPageMonitor.ResumeLayout(false);
        	this.flowLayoutPanel2.ResumeLayout(false);
        	this.flowLayoutPanel3.ResumeLayout(false);
        	this.groupBox3.ResumeLayout(false);
        	this.groupBox2.ResumeLayout(false);
        	this.groupBox2.PerformLayout();
        	this.groupBox4.ResumeLayout(false);
        	this.groupBox5.ResumeLayout(false);
        	this.groupBox5.PerformLayout();
        	this.tabPageUsersInfo.ResumeLayout(false);
        	this.flowLayoutPanel6.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserInfo)).EndInit();
        	this.flowLayoutPanel1.ResumeLayout(false);
        	this.flowLayoutPanel1.PerformLayout();
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.numericUpDownReturnDelay)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
        	this.tabControlMainForm.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxProxy;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ColumnHeader colHdArrTime;
        private System.Windows.Forms.ColumnHeader colHdVlgCoord;
        private System.Windows.Forms.ListView listViewRaidCheck;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader colHdEnemyRace;
        private System.Windows.Forms.ColumnHeader colHdEnemy;
        private System.Windows.Forms.ColumnHeader colHdVlg;
        private System.Windows.Forms.ColumnHeader colHdAcc;
        private System.Windows.Forms.Button btnStopStaring;
        private System.Windows.Forms.Button btnStartStaring;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbS8;
        private System.Windows.Forms.TextBox tbS9;
        private System.Windows.Forms.ColumnHeader colHdTimeNeeded;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbS1;
        private System.Windows.Forms.TextBox tbS4;
        private System.Windows.Forms.TextBox tbS7;
        private System.Windows.Forms.TextBox tbS3;
        private System.Windows.Forms.TextBox tbS6;
        private System.Windows.Forms.TextBox tbS2;
        private System.Windows.Forms.TextBox tbS5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripStatusLabel GuageStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel AccNumStripStatusLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.ToolStripStatusLabel TaskStatusLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;

        #endregion

        private System.Windows.Forms.TabControl tabControlMainForm;
        private System.Windows.Forms.TabPage tabPageUsersInfo;
        private System.Windows.Forms.TabPage tabPageMonitor;
        private System.Windows.Forms.TabPage tabPageTroopSending;
        private System.Windows.Forms.DataGridView dataGridViewUserInfo;
        private UsersInfoDataSet usersInfoDataSet;
        private System.Windows.Forms.BindingSource usersinfoBindingSource;
        private TravianMonitor.UsersInfoDataSetTableAdapters.users_infoTableAdapter users_infoTableAdapter;
        private System.Windows.Forms.BindingSource usersInfoDataSetBindingSource;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn entryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSvrURL;
        private System.Windows.Forms.Button btnModifyServerURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.TextBox textBoxInstruction;
        private System.Windows.Forms.ListView listViewTroopsInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.ColumnHeader colHdAccount;
        private System.Windows.Forms.ColumnHeader colHdVillage;
        private System.Windows.Forms.ColumnHeader colHdTroops;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxTgY;
        private System.Windows.Forms.TextBox textBoxTgX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxAllTgs;
        private System.Windows.Forms.Button buttonAddTg;
        private System.Windows.Forms.Button buttonDelTg;
        private System.Windows.Forms.Button btnRefreshVillages;
        private System.Windows.Forms.DateTimePicker dateTimePickerReachTime;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAddToTroopsArray;
        private System.Windows.Forms.Button btnCalStartTime;
        private System.Windows.Forms.ColumnHeader colHdStartTime;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.NumericUpDown numericUpDownReturnDelay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader colHdCoord;
        private System.Windows.Forms.ListView listViewTroopSending;
        private System.Windows.Forms.ColumnHeader colHdCurStatus;
        private System.Windows.Forms.ColumnHeader colHdTgCoord;
        private System.Windows.Forms.ColumnHeader colHdTroopStartTime;
        private System.Windows.Forms.ColumnHeader colHdTroopReachTime;
        private System.Windows.Forms.ColumnHeader colHdSrcAccount;
        private System.Windows.Forms.ColumnHeader colHdSrcVillage;
        private System.Windows.Forms.ColumnHeader colHdSrcVillageCoord;
        private System.Windows.Forms.ColumnHeader colHdSrcTroops;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button btnStartSendTroops;
        private System.Windows.Forms.Button btnStopSendTroops;
    }
}

