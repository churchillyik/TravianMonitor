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
        public FormTrMonitor()
        {
            InitializeComponent();
        }

        private void InstructionLoad()
        {
            if (File.Exists("Intruction"))
            {
                FileStream fs = new FileStream("Intruction", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                this.textBoxInstruction.AppendText(sr.ReadToEnd());
                sr.Close();
            }
        }

        private void FormTrMonitor_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“usersInfoDataSet.users_info”中。您可以根据需要移动或移除它。
            this.users_infoTableAdapter.Fill(this.usersInfoDataSet.users_info);

            if (TravianAccessor.TrAcsr == null)
            {
                TravianAccessor.TrAcsr = new TravianAccessor();
            }

            if (TravianAccessor.TrAcsr.glbCfg.strSvrURL != "")
            {
                this.textBoxSvrURL.Text = TravianAccessor.TrAcsr.glbCfg.strSvrURL;
            }

            if (TravianAccessor.TrAcsr.glbCfg.nInterval != 0)
            {
                this.numericUpDownInterval.Value = TravianAccessor.TrAcsr.glbCfg.nInterval;
            }

            InstructionLoad();
        }

        private void btnModifyServerURL_Click(object sender, EventArgs e)
        {
            TravianAccessor.TrAcsr.glbCfg.strSvrURL = this.textBoxSvrURL.Text;
            TravianAccessor.TrAcsr.glbCfg.nInterval = Convert.ToInt32(this.numericUpDownInterval.Value);
            TravianAccessor.TrAcsr.SaveOptions();
        }

        
    }
}