namespace workController
{
    partial class whitelist
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
            this.whitelistDomains = new System.Windows.Forms.DataGridView();
            this.domain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveNClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.whitelistDomains)).BeginInit();
            this.SuspendLayout();
            // 
            // whitelistDomains
            // 
            this.whitelistDomains.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.whitelistDomains.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.whitelistDomains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.whitelistDomains.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.domain});
            this.whitelistDomains.Location = new System.Drawing.Point(12, 12);
            this.whitelistDomains.Name = "whitelistDomains";
            this.whitelistDomains.Size = new System.Drawing.Size(426, 392);
            this.whitelistDomains.TabIndex = 0;
            // 
            // domain
            // 
            this.domain.HeaderText = "White Listed Domains :: Press Enter After Adding Each New Domain";
            this.domain.Name = "domain";
            // 
            // saveNClose
            // 
            this.saveNClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveNClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveNClose.ForeColor = System.Drawing.Color.Green;
            this.saveNClose.Location = new System.Drawing.Point(204, 410);
            this.saveNClose.Name = "saveNClose";
            this.saveNClose.Size = new System.Drawing.Size(234, 28);
            this.saveNClose.TabIndex = 1;
            this.saveNClose.Text = "Save And Restart Application";
            this.saveNClose.UseVisualStyleBackColor = true;
            this.saveNClose.Click += new System.EventHandler(this.saveNClose_Click);
            // 
            // whitelist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 450);
            this.Controls.Add(this.saveNClose);
            this.Controls.Add(this.whitelistDomains);
            this.Name = "whitelist";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "White Listed Domains";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.whitelist_FormClosing);
            this.Load += new System.EventHandler(this.whitelist_Load);
            this.Shown += new System.EventHandler(this.whitelist_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.whitelistDomains)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView whitelistDomains;
        private System.Windows.Forms.DataGridViewTextBoxColumn domain;
        private System.Windows.Forms.Button saveNClose;
    }
}