namespace workController
{
    partial class general
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.minimizeOnStartup = new System.Windows.Forms.CheckBox();
            this.minimizeToTray = new System.Windows.Forms.CheckBox();
            this.saveNClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(35, 15);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(43, 20);
            this.port.TabIndex = 3;
            this.port.Text = "8000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // minimizeOnStartup
            // 
            this.minimizeOnStartup.AutoSize = true;
            this.minimizeOnStartup.Location = new System.Drawing.Point(12, 48);
            this.minimizeOnStartup.Name = "minimizeOnStartup";
            this.minimizeOnStartup.Size = new System.Drawing.Size(116, 17);
            this.minimizeOnStartup.TabIndex = 5;
            this.minimizeOnStartup.Text = "Minimize on startup";
            this.minimizeOnStartup.UseVisualStyleBackColor = true;
            // 
            // minimizeToTray
            // 
            this.minimizeToTray.AutoSize = true;
            this.minimizeToTray.Location = new System.Drawing.Point(12, 71);
            this.minimizeToTray.Name = "minimizeToTray";
            this.minimizeToTray.Size = new System.Drawing.Size(133, 17);
            this.minimizeToTray.TabIndex = 6;
            this.minimizeToTray.Text = "Minimize to system tray";
            this.minimizeToTray.UseVisualStyleBackColor = true;
            // 
            // saveNClose
            // 
            this.saveNClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveNClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveNClose.ForeColor = System.Drawing.Color.Green;
            this.saveNClose.Location = new System.Drawing.Point(11, 103);
            this.saveNClose.Name = "saveNClose";
            this.saveNClose.Size = new System.Drawing.Size(234, 28);
            this.saveNClose.TabIndex = 7;
            this.saveNClose.Text = "Save And Restart Application";
            this.saveNClose.UseVisualStyleBackColor = true;
            this.saveNClose.Click += new System.EventHandler(this.saveNClose_Click);
            // 
            // general
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 143);
            this.Controls.Add(this.saveNClose);
            this.Controls.Add(this.minimizeToTray);
            this.Controls.Add(this.minimizeOnStartup);
            this.Controls.Add(this.port);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "general";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General Settings";
            this.Shown += new System.EventHandler(this.general_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox minimizeOnStartup;
        private System.Windows.Forms.CheckBox minimizeToTray;
        private System.Windows.Forms.Button saveNClose;
    }
}