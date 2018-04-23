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
    public partial class general : Form
    {
        public general()
        {
            InitializeComponent();
        }

        private void saveNClose_Click(object sender, EventArgs e)
        {
            int realPort = 8000;
            if (port.Text != "" || port.Text != " ")
                realPort = Convert.ToInt32(port.Text);

            Properties.Settings.Default.startMinimized = minimizeOnStartup.Checked;
            Properties.Settings.Default.toSystemTray = minimizeToTray.Checked;

            Properties.Settings.Default.port = realPort;
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void general_Shown(object sender, EventArgs e)
        {
            port.Text = Properties.Settings.Default.port.ToString();
            minimizeOnStartup.Checked = Properties.Settings.Default.startMinimized;
            minimizeToTray.Checked = Properties.Settings.Default.toSystemTray;
        }
    }
}
