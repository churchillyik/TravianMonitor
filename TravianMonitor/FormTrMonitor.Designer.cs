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
        	this.tabControlMainForm = new System.Windows.Forms.TabControl();
        	this.tabPageUsersInfo = new System.Windows.Forms.TabPage();
        	this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
        	this.textBoxInstruction = new System.Windows.Forms.TextBox();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.numericUpDownReturnDelay = new System.Windows.Forms.NumericUpDown();
        	this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
        	this.btnModifyServerURL = new System.Windows.Forms.Button();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.label1 = new System.Windows.Forms.Label();
        	this.textBoxSvrURL = new System.Windows.Forms.TextBox();
        	this.dataGridViewUserInfo = new System.Windows.Forms.DataGridView();
        	this.entryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.accountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.usersinfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
        	this.usersInfoDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
        	this.usersInfoDataSet = new TravianMonitor.UsersInfoDataSet();
        	this.tabPageMonitor = new System.Windows.Forms.TabPage();
        	this.listViewTroopsInfo = new System.Windows.Forms.ListView();
        	this.colHdAccount = new System.Windows.Forms.ColumnHeader();
        	this.colHdVillage = new System.Windows.Forms.ColumnHeader();
        	this.colHdCoord = new System.Windows.Forms.ColumnHeader();
        	this.colHdTroops = new System.Windows.Forms.ColumnHeader();
        	this.colHdStartTime = new System.Windows.Forms.ColumnHeader();
        	this.colHdSquare = new System.Windows.Forms.ColumnHeader();
        	this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
        	this.textBoxLog4Monitor = new System.Windows.Forms.TextBox();
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
        	this.btnClearLog4Monitor = new System.Windows.Forms.Button();
        	this.btnStatistics = new System.Windows.Forms.Button();
        	this.btnAddToTroopsArray = new System.Windows.Forms.Button();
        	this.btnCalStartTime = new System.Windows.Forms.Button();
        	this.btnRefreshVillages = new System.Windows.Forms.Button();
        	this.tabPageTroopSending = new System.Windows.Forms.TabPage();
        	this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
        	this.btnStartSendTroops = new System.Windows.Forms.Button();
        	this.btnStopSendTroops = new System.Windows.Forms.Button();
        	this.btnClearLog4TroopSending = new System.Windows.Forms.Button();
        	this.textBoxLog4TroopSending = new System.Windows.Forms.TextBox();
        	this.listViewTroopSending = new System.Windows.Forms.ListView();
        	this.colHdCurStatus = new System.Windows.Forms.ColumnHeader();
        	this.colHdTgCoord = new System.Windows.Forms.ColumnHeader();
        	this.colHdTroopStartTime = new System.Windows.Forms.ColumnHeader();
        	this.colHdTroopReachTime = new System.Windows.Forms.ColumnHeader();
        	this.colHdSrcAccount = new System.Windows.Forms.ColumnHeader();
        	this.colHdSrcVillage = new System.Windows.Forms.ColumnHeader();
        	this.colHdSrcVillageCoord = new System.Windows.Forms.ColumnHeader();
        	this.colHdSrcTroops = new System.Windows.Forms.ColumnHeader();
        	this.colHdSrcSquare = new System.Windows.Forms.ColumnHeader();
        	this.users_infoTableAdapter = new TravianMonitor.UsersInfoDataSetTableAdapters.users_infoTableAdapter();
        	this.tabControlMainForm.SuspendLayout();
        	this.tabPageUsersInfo.SuspendLayout();
        	this.flowLayoutPanel1.SuspendLayout();
        	this.groupBox1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.numericUpDownReturnDelay)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserInfo)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.usersinfoBindingSource)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.usersInfoDataSetBindingSource)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.usersInfoDataSet)).BeginInit();
        	this.tabPageMonitor.SuspendLayout();
        	this.flowLayoutPanel2.SuspendLayout();
        	this.flowLayoutPanel3.SuspendLayout();
        	this.groupBox3.SuspendLayout();
        	this.groupBox2.SuspendLayout();
        	this.groupBox4.SuspendLayout();
        	this.tabPageTroopSending.SuspendLayout();
        	this.flowLayoutPanel4.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// tabControlMainForm
        	// 
        	this.tabControlMainForm.Controls.Add(this.tabPageUsersInfo);
        	this.tabControlMainForm.Controls.Add(this.tabPageMonitor);
        	this.tabControlMainForm.Controls.Add(this.tabPageTroopSending);
        	this.tabControlMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tabControlMainForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.tabControlMainForm.Location = new System.Drawing.Point(0, 0);
        	this.tabControlMainForm.Name = "tabControlMainForm";
        	this.tabControlMainForm.SelectedIndex = 0;
        	this.tabControlMainForm.Size = new System.Drawing.Size(874, 603);
        	this.tabControlMainForm.TabIndex = 0;
        	// 
        	// tabPageUsersInfo
        	// 
        	this.tabPageUsersInfo.Controls.Add(this.flowLayoutPanel1);
        	this.tabPageUsersInfo.Controls.Add(this.dataGridViewUserInfo);
        	this.tabPageUsersInfo.Location = new System.Drawing.Point(4, 26);
        	this.tabPageUsersInfo.Name = "tabPageUsersInfo";
        	this.tabPageUsersInfo.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPageUsersInfo.Size = new System.Drawing.Size(866, 573);
        	this.tabPageUsersInfo.TabIndex = 0;
        	this.tabPageUsersInfo.Text = "帐号管理";
        	this.tabPageUsersInfo.UseVisualStyleBackColor = true;
        	// 
        	// flowLayoutPanel1
        	// 
        	this.flowLayoutPanel1.Controls.Add(this.textBoxInstruction);
        	this.flowLayoutPanel1.Controls.Add(this.groupBox1);
        	this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
        	this.flowLayoutPanel1.Location = new System.Drawing.Point(546, 3);
        	this.flowLayoutPanel1.Name = "flowLayoutPanel1";
        	this.flowLayoutPanel1.Size = new System.Drawing.Size(317, 567);
        	this.flowLayoutPanel1.TabIndex = 1;
        	// 
        	// textBoxInstruction
        	// 
        	this.textBoxInstruction.Dock = System.Windows.Forms.DockStyle.Top;
        	this.textBoxInstruction.Location = new System.Drawing.Point(3, 3);
        	this.textBoxInstruction.Multiline = true;
        	this.textBoxInstruction.Name = "textBoxInstruction";
        	this.textBoxInstruction.ReadOnly = true;
        	this.textBoxInstruction.Size = new System.Drawing.Size(309, 251);
        	this.textBoxInstruction.TabIndex = 1;
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.numericUpDownReturnDelay);
        	this.groupBox1.Controls.Add(this.numericUpDownInterval);
        	this.groupBox1.Controls.Add(this.btnModifyServerURL);
        	this.groupBox1.Controls.Add(this.label2);
        	this.groupBox1.Controls.Add(this.label3);
        	this.groupBox1.Controls.Add(this.label1);
        	this.groupBox1.Controls.Add(this.textBoxSvrURL);
        	this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.groupBox1.Location = new System.Drawing.Point(3, 260);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(311, 305);
        	this.groupBox1.TabIndex = 0;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "基本设置";
        	// 
        	// numericUpDownReturnDelay
        	// 
        	this.numericUpDownReturnDelay.Location = new System.Drawing.Point(38, 212);
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
        	this.numericUpDownInterval.Location = new System.Drawing.Point(38, 135);
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
        	this.btnModifyServerURL.Location = new System.Drawing.Point(112, 260);
        	this.btnModifyServerURL.Name = "btnModifyServerURL";
        	this.btnModifyServerURL.Size = new System.Drawing.Size(87, 32);
        	this.btnModifyServerURL.TabIndex = 2;
        	this.btnModifyServerURL.Text = "确认修改";
        	this.btnModifyServerURL.UseVisualStyleBackColor = true;
        	this.btnModifyServerURL.Click += new System.EventHandler(this.btnModifyServerURL_Click);
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(12, 106);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(162, 17);
        	this.label2.TabIndex = 1;
        	this.label2.Text = "扫描时间间隔（分钟）：";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(12, 182);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(190, 17);
        	this.label3.TabIndex = 1;
        	this.label3.Text = "部队撤回的延迟时间（秒）：";
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
        	// textBoxSvrURL
        	// 
        	this.textBoxSvrURL.Location = new System.Drawing.Point(38, 61);
        	this.textBoxSvrURL.Name = "textBoxSvrURL";
        	this.textBoxSvrURL.Size = new System.Drawing.Size(222, 23);
        	this.textBoxSvrURL.TabIndex = 0;
        	this.textBoxSvrURL.Text = "ts1.travian.cc";
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
        	this.dataGridViewUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dataGridViewUserInfo.Location = new System.Drawing.Point(3, 3);
        	this.dataGridViewUserInfo.Name = "dataGridViewUserInfo";
        	this.dataGridViewUserInfo.RowTemplate.Height = 23;
        	this.dataGridViewUserInfo.Size = new System.Drawing.Size(860, 567);
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
        	// tabPageMonitor
        	// 
        	this.tabPageMonitor.Controls.Add(this.listViewTroopsInfo);
        	this.tabPageMonitor.Controls.Add(this.flowLayoutPanel2);
        	this.tabPageMonitor.Location = new System.Drawing.Point(4, 26);
        	this.tabPageMonitor.Name = "tabPageMonitor";
        	this.tabPageMonitor.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPageMonitor.Size = new System.Drawing.Size(866, 573);
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
        	        	        	this.colHdSquare});
        	this.listViewTroopsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.listViewTroopsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.listViewTroopsInfo.FullRowSelect = true;
        	this.listViewTroopsInfo.GridLines = true;
        	this.listViewTroopsInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
        	this.listViewTroopsInfo.Location = new System.Drawing.Point(3, 3);
        	this.listViewTroopsInfo.Name = "listViewTroopsInfo";
        	this.listViewTroopsInfo.Size = new System.Drawing.Size(560, 567);
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
        	// colHdSquare
        	// 
        	this.colHdSquare.Text = "竞技场等级";
        	this.colHdSquare.Width = 80;
        	// 
        	// flowLayoutPanel2
        	// 
        	this.flowLayoutPanel2.Controls.Add(this.textBoxLog4Monitor);
        	this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel3);
        	this.flowLayoutPanel2.Controls.Add(this.groupBox4);
        	this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
        	this.flowLayoutPanel2.Location = new System.Drawing.Point(563, 3);
        	this.flowLayoutPanel2.Name = "flowLayoutPanel2";
        	this.flowLayoutPanel2.Size = new System.Drawing.Size(300, 567);
        	this.flowLayoutPanel2.TabIndex = 2;
        	// 
        	// textBoxLog4Monitor
        	// 
        	this.textBoxLog4Monitor.Location = new System.Drawing.Point(3, 3);
        	this.textBoxLog4Monitor.Multiline = true;
        	this.textBoxLog4Monitor.Name = "textBoxLog4Monitor";
        	this.textBoxLog4Monitor.ReadOnly = true;
        	this.textBoxLog4Monitor.Size = new System.Drawing.Size(297, 231);
        	this.textBoxLog4Monitor.TabIndex = 0;
        	// 
        	// flowLayoutPanel3
        	// 
        	this.flowLayoutPanel3.Controls.Add(this.groupBox3);
        	this.flowLayoutPanel3.Controls.Add(this.groupBox2);
        	this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 240);
        	this.flowLayoutPanel3.Name = "flowLayoutPanel3";
        	this.flowLayoutPanel3.Size = new System.Drawing.Size(292, 192);
        	this.flowLayoutPanel3.TabIndex = 1;
        	// 
        	// groupBox3
        	// 
        	this.groupBox3.Controls.Add(this.dateTimePickerReachTime);
        	this.groupBox3.Location = new System.Drawing.Point(3, 3);
        	this.groupBox3.Name = "groupBox3";
        	this.groupBox3.Size = new System.Drawing.Size(283, 59);
        	this.groupBox3.TabIndex = 5;
        	this.groupBox3.TabStop = false;
        	this.groupBox3.Text = "选择部队到达时刻";
        	// 
        	// dateTimePickerReachTime
        	// 
        	this.dateTimePickerReachTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        	this.dateTimePickerReachTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.dateTimePickerReachTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        	this.dateTimePickerReachTime.Location = new System.Drawing.Point(15, 27);
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
        	this.groupBox2.Size = new System.Drawing.Size(289, 111);
        	this.groupBox2.TabIndex = 0;
        	this.groupBox2.TabStop = false;
        	this.groupBox2.Text = "增援目标";
        	// 
        	// buttonDelTg
        	// 
        	this.buttonDelTg.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.buttonDelTg.Location = new System.Drawing.Point(134, 73);
        	this.buttonDelTg.Name = "buttonDelTg";
        	this.buttonDelTg.Size = new System.Drawing.Size(49, 26);
        	this.buttonDelTg.TabIndex = 3;
        	this.buttonDelTg.Text = "删除";
        	this.buttonDelTg.UseVisualStyleBackColor = true;
        	this.buttonDelTg.Click += new System.EventHandler(this.ButtonDelTgClick);
        	// 
        	// buttonAddTg
        	// 
        	this.buttonAddTg.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.buttonAddTg.Location = new System.Drawing.Point(134, 29);
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
        	this.comboBoxAllTgs.FormattingEnabled = true;
        	this.comboBoxAllTgs.Location = new System.Drawing.Point(14, 74);
        	this.comboBoxAllTgs.Name = "comboBoxAllTgs";
        	this.comboBoxAllTgs.Size = new System.Drawing.Size(105, 25);
        	this.comboBoxAllTgs.TabIndex = 2;
        	// 
        	// textBoxTgY
        	// 
        	this.textBoxTgY.Location = new System.Drawing.Point(75, 29);
        	this.textBoxTgY.Name = "textBoxTgY";
        	this.textBoxTgY.Size = new System.Drawing.Size(44, 23);
        	this.textBoxTgY.TabIndex = 1;
        	// 
        	// textBoxTgX
        	// 
        	this.textBoxTgX.Location = new System.Drawing.Point(15, 29);
        	this.textBoxTgX.Name = "textBoxTgX";
        	this.textBoxTgX.Size = new System.Drawing.Size(44, 23);
        	this.textBoxTgX.TabIndex = 1;
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(60, 31);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(11, 17);
        	this.label4.TabIndex = 0;
        	this.label4.Text = "|";
        	// 
        	// groupBox4
        	// 
        	this.groupBox4.Controls.Add(this.btnClearLog4Monitor);
        	this.groupBox4.Controls.Add(this.btnStatistics);
        	this.groupBox4.Controls.Add(this.btnAddToTroopsArray);
        	this.groupBox4.Controls.Add(this.btnCalStartTime);
        	this.groupBox4.Controls.Add(this.btnRefreshVillages);
        	this.groupBox4.Location = new System.Drawing.Point(3, 438);
        	this.groupBox4.Name = "groupBox4";
        	this.groupBox4.Size = new System.Drawing.Size(292, 123);
        	this.groupBox4.TabIndex = 2;
        	this.groupBox4.TabStop = false;
        	this.groupBox4.Text = "功能";
        	// 
        	// btnClearLog4Monitor
        	// 
        	this.btnClearLog4Monitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.btnClearLog4Monitor.Location = new System.Drawing.Point(108, 76);
        	this.btnClearLog4Monitor.Name = "btnClearLog4Monitor";
        	this.btnClearLog4Monitor.Size = new System.Drawing.Size(79, 42);
        	this.btnClearLog4Monitor.TabIndex = 3;
        	this.btnClearLog4Monitor.Text = "清空日志";
        	this.btnClearLog4Monitor.UseVisualStyleBackColor = true;
        	// 
        	// btnStatistics
        	// 
        	this.btnStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.btnStatistics.Location = new System.Drawing.Point(14, 76);
        	this.btnStatistics.Name = "btnStatistics";
        	this.btnStatistics.Size = new System.Drawing.Size(79, 42);
        	this.btnStatistics.TabIndex = 3;
        	this.btnStatistics.Text = "统计兵力";
        	this.btnStatistics.UseVisualStyleBackColor = true;
        	// 
        	// btnAddToTroopsArray
        	// 
        	this.btnAddToTroopsArray.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.btnAddToTroopsArray.Location = new System.Drawing.Point(202, 28);
        	this.btnAddToTroopsArray.Name = "btnAddToTroopsArray";
        	this.btnAddToTroopsArray.Size = new System.Drawing.Size(79, 42);
        	this.btnAddToTroopsArray.TabIndex = 3;
        	this.btnAddToTroopsArray.Text = "加入出兵队列";
        	this.btnAddToTroopsArray.UseVisualStyleBackColor = true;
        	// 
        	// btnCalStartTime
        	// 
        	this.btnCalStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.btnCalStartTime.Location = new System.Drawing.Point(108, 28);
        	this.btnCalStartTime.Name = "btnCalStartTime";
        	this.btnCalStartTime.Size = new System.Drawing.Size(79, 42);
        	this.btnCalStartTime.TabIndex = 3;
        	this.btnCalStartTime.Text = "计算出兵时刻";
        	this.btnCalStartTime.UseVisualStyleBackColor = true;
        	// 
        	// btnRefreshVillages
        	// 
        	this.btnRefreshVillages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.btnRefreshVillages.Location = new System.Drawing.Point(14, 28);
        	this.btnRefreshVillages.Name = "btnRefreshVillages";
        	this.btnRefreshVillages.Size = new System.Drawing.Size(79, 42);
        	this.btnRefreshVillages.TabIndex = 3;
        	this.btnRefreshVillages.Text = "刷新所有村庄";
        	this.btnRefreshVillages.UseVisualStyleBackColor = true;
        	this.btnRefreshVillages.Click += new System.EventHandler(this.BtnRefreshVillagesClick);
        	// 
        	// tabPageTroopSending
        	// 
        	this.tabPageTroopSending.Controls.Add(this.flowLayoutPanel4);
        	this.tabPageTroopSending.Controls.Add(this.listViewTroopSending);
        	this.tabPageTroopSending.Location = new System.Drawing.Point(4, 26);
        	this.tabPageTroopSending.Name = "tabPageTroopSending";
        	this.tabPageTroopSending.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPageTroopSending.Size = new System.Drawing.Size(866, 573);
        	this.tabPageTroopSending.TabIndex = 2;
        	this.tabPageTroopSending.Text = "发兵插防";
        	this.tabPageTroopSending.UseVisualStyleBackColor = true;
        	// 
        	// flowLayoutPanel4
        	// 
        	this.flowLayoutPanel4.Controls.Add(this.btnStartSendTroops);
        	this.flowLayoutPanel4.Controls.Add(this.btnStopSendTroops);
        	this.flowLayoutPanel4.Controls.Add(this.btnClearLog4TroopSending);
        	this.flowLayoutPanel4.Controls.Add(this.textBoxLog4TroopSending);
        	this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 406);
        	this.flowLayoutPanel4.Name = "flowLayoutPanel4";
        	this.flowLayoutPanel4.Size = new System.Drawing.Size(860, 164);
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
        	// btnClearLog4TroopSending
        	// 
        	this.btnClearLog4TroopSending.Location = new System.Drawing.Point(181, 3);
        	this.btnClearLog4TroopSending.Name = "btnClearLog4TroopSending";
        	this.btnClearLog4TroopSending.Size = new System.Drawing.Size(83, 46);
        	this.btnClearLog4TroopSending.TabIndex = 0;
        	this.btnClearLog4TroopSending.Text = "清空日志";
        	this.btnClearLog4TroopSending.UseVisualStyleBackColor = true;
        	// 
        	// textBoxLog4TroopSending
        	// 
        	this.textBoxLog4TroopSending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.textBoxLog4TroopSending.Location = new System.Drawing.Point(3, 55);
        	this.textBoxLog4TroopSending.Multiline = true;
        	this.textBoxLog4TroopSending.Name = "textBoxLog4TroopSending";
        	this.textBoxLog4TroopSending.ReadOnly = true;
        	this.textBoxLog4TroopSending.Size = new System.Drawing.Size(854, 106);
        	this.textBoxLog4TroopSending.TabIndex = 1;
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
        	        	        	this.colHdSrcTroops,
        	        	        	this.colHdSrcSquare});
        	this.listViewTroopSending.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.listViewTroopSending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.listViewTroopSending.FullRowSelect = true;
        	this.listViewTroopSending.GridLines = true;
        	this.listViewTroopSending.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
        	this.listViewTroopSending.Location = new System.Drawing.Point(3, 3);
        	this.listViewTroopSending.Name = "listViewTroopSending";
        	this.listViewTroopSending.Size = new System.Drawing.Size(860, 567);
        	this.listViewTroopSending.TabIndex = 0;
        	this.listViewTroopSending.UseCompatibleStateImageBehavior = false;
        	this.listViewTroopSending.View = System.Windows.Forms.View.Details;
        	// 
        	// colHdCurStatus
        	// 
        	this.colHdCurStatus.Text = "当前状态";
        	// 
        	// colHdTgCoord
        	// 
        	this.colHdTgCoord.Text = "目标坐标";
        	// 
        	// colHdTroopStartTime
        	// 
        	this.colHdTroopStartTime.Text = "出发时刻";
        	this.colHdTroopStartTime.Width = 100;
        	// 
        	// colHdTroopReachTime
        	// 
        	this.colHdTroopReachTime.Text = "到达时刻";
        	this.colHdTroopReachTime.Width = 100;
        	// 
        	// colHdSrcAccount
        	// 
        	this.colHdSrcAccount.Text = "发兵帐号";
        	this.colHdSrcAccount.Width = 80;
        	// 
        	// colHdSrcVillage
        	// 
        	this.colHdSrcVillage.Text = "发兵村（ID）";
        	this.colHdSrcVillage.Width = 120;
        	// 
        	// colHdSrcVillageCoord
        	// 
        	this.colHdSrcVillageCoord.Text = "兵村坐标";
        	// 
        	// colHdSrcTroops
        	// 
        	this.colHdSrcTroops.Text = "军队信息";
        	this.colHdSrcTroops.Width = 200;
        	// 
        	// colHdSrcSquare
        	// 
        	this.colHdSrcSquare.Text = "竞技场等级";
        	this.colHdSrcSquare.Width = 80;
        	// 
        	// users_infoTableAdapter
        	// 
        	this.users_infoTableAdapter.ClearBeforeFill = true;
        	// 
        	// FormTrMonitor
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(874, 603);
        	this.Controls.Add(this.tabControlMainForm);
        	this.Name = "FormTrMonitor";
        	this.Text = "Travian插秒工具";
        	this.Load += new System.EventHandler(this.FormTrMonitor_Load);
        	this.tabControlMainForm.ResumeLayout(false);
        	this.tabPageUsersInfo.ResumeLayout(false);
        	this.flowLayoutPanel1.ResumeLayout(false);
        	this.flowLayoutPanel1.PerformLayout();
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.numericUpDownReturnDelay)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserInfo)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.usersinfoBindingSource)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.usersInfoDataSetBindingSource)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.usersInfoDataSet)).EndInit();
        	this.tabPageMonitor.ResumeLayout(false);
        	this.flowLayoutPanel2.ResumeLayout(false);
        	this.flowLayoutPanel2.PerformLayout();
        	this.flowLayoutPanel3.ResumeLayout(false);
        	this.groupBox3.ResumeLayout(false);
        	this.groupBox2.ResumeLayout(false);
        	this.groupBox2.PerformLayout();
        	this.groupBox4.ResumeLayout(false);
        	this.tabPageTroopSending.ResumeLayout(false);
        	this.flowLayoutPanel4.ResumeLayout(false);
        	this.flowLayoutPanel4.PerformLayout();
        	this.ResumeLayout(false);
        }

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
        private System.Windows.Forms.TextBox textBoxLog4Monitor;
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
        private System.Windows.Forms.ColumnHeader colHdSquare;
        private System.Windows.Forms.ColumnHeader colHdSrcSquare;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button btnStartSendTroops;
        private System.Windows.Forms.Button btnStopSendTroops;
        private System.Windows.Forms.TextBox textBoxLog4TroopSending;
        private System.Windows.Forms.Button btnClearLog4Monitor;
        private System.Windows.Forms.Button btnClearLog4TroopSending;
    }
}

