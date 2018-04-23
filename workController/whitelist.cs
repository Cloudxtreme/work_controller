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
    public partial class whitelist : Form
    {
        public whitelist()
        {
            InitializeComponent();
        }

        private void whitelist_Load(object sender, EventArgs e)
        {
            
        }

        private void whitelist_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void whitelist_Shown(object sender, EventArgs e)
        {
            string whitelistItems = Properties.Settings.Default.whitelist;
            if (whitelistItems.Length > 0)
            {
                if (whitelistItems.Contains(","))
                {
                    string[] txt = whitelistItems.Split(',');
                    foreach (string wl in txt)
                    {
                        whitelistDomains.Rows.Add(wl);
                    }
                }
                else
                    whitelistDomains.Rows.Add(whitelistItems);
            }
        }

        private void saveNClose_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            foreach (DataGridViewRow row in whitelistDomains.Rows)
            {
                if (row.Cells[0].Value != null)
                    items.Add(row.Cells[0].Value.ToString());
            }
            Properties.Settings.Default.whitelist = String.Join(",", items);
            Properties.Settings.Default.Save();
            Application.Restart();
        }
    }
}
