using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workController
{
    public partial class blocktimes : Form
    {
        public blocktimes()
        {
            InitializeComponent();
        }

        private void blocktimes_Load(object sender, EventArgs e)
        {
            
        }

        private void blocktimes_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void blocktimes_Shown(object sender, EventArgs e)
        {
            string blocktimesItems = Properties.Settings.Default.blocktimes;
            if (blocktimesItems.Length > 0)
            {
                if (blocktimesItems.Contains(","))
                {
                    string[] txt = blocktimesItems.Split(',');
                    foreach (string bt in txt)
                    {
                        string[] itms = bt.Split('-');
                        blockedTimes.Rows.Add(itms[0], itms[1]);
                    }
                }
                else
                {
                    string[] itms = blocktimesItems.Split('-');
                    blockedTimes.Rows.Add(itms[0], itms[1]);
                }
            }
        }

        private void saveNClose_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            foreach (DataGridViewRow row in blockedTimes.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    items.Add(row.Cells[0].Value.ToString() + "-" + row.Cells[1].Value.ToString());
            }
            Properties.Settings.Default.blocktimes = String.Join(",", items);
            Properties.Settings.Default.Save();
            Application.Restart();
        }
    }
}
