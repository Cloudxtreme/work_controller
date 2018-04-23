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
    public partial class blockedmsg : Form
    {
        public blockedmsg()
        {
            InitializeComponent();
        }

        private void saveNClose_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.blockedmsg = msgHTML.Text;
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void blockedmsg_Shown(object sender, EventArgs e)
        {
            msgHTML.Text = Properties.Settings.Default.blockedmsg;
        }
    }
}
