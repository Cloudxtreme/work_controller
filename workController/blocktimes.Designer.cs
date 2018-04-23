namespace workController
{
    partial class blocktimes
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
            this.blockedTimes = new System.Windows.Forms.DataGridView();
            this.starttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.saveNClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.blockedTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // blockedTimes
            // 
            this.blockedTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blockedTimes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.blockedTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.blockedTimes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.starttime,
            this.endtime});
            this.blockedTimes.Location = new System.Drawing.Point(12, 25);
            this.blockedTimes.Name = "blockedTimes";
            this.blockedTimes.Size = new System.Drawing.Size(432, 425);
            this.blockedTimes.TabIndex = 0;
            // 
            // starttime
            // 
            this.starttime.HeaderText = "Start Time";
            this.starttime.Name = "starttime";
            // 
            // endtime
            // 
            this.endtime.HeaderText = "End Time";
            this.endtime.Name = "endtime";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Use 24 hour time format HH:MM:SS";
            // 
            // saveNClose
            // 
            this.saveNClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveNClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveNClose.ForeColor = System.Drawing.Color.Green;
            this.saveNClose.Location = new System.Drawing.Point(210, 456);
            this.saveNClose.Name = "saveNClose";
            this.saveNClose.Size = new System.Drawing.Size(234, 28);
            this.saveNClose.TabIndex = 2;
            this.saveNClose.Text = "Save And Restart Application";
            this.saveNClose.UseVisualStyleBackColor = true;
            this.saveNClose.Click += new System.EventHandler(this.saveNClose_Click);
            // 
            // blocktimes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 496);
            this.Controls.Add(this.saveNClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.blockedTimes);
            this.Name = "blocktimes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Block Times :: Hit Enter After Adding Each New Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.blocktimes_FormClosing);
            this.Load += new System.EventHandler(this.blocktimes_Load);
            this.Shown += new System.EventHandler(this.blocktimes_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.blockedTimes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView blockedTimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn starttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn endtime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveNClose;
    }
}