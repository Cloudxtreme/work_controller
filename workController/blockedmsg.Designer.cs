namespace workController
{
    partial class blockedmsg
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
            this.msgHTML = new System.Windows.Forms.TextBox();
            this.saveNClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // msgHTML
            // 
            this.msgHTML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgHTML.Location = new System.Drawing.Point(13, 13);
            this.msgHTML.Multiline = true;
            this.msgHTML.Name = "msgHTML";
            this.msgHTML.Size = new System.Drawing.Size(599, 453);
            this.msgHTML.TabIndex = 0;
            // 
            // saveNClose
            // 
            this.saveNClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveNClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveNClose.ForeColor = System.Drawing.Color.Green;
            this.saveNClose.Location = new System.Drawing.Point(378, 472);
            this.saveNClose.Name = "saveNClose";
            this.saveNClose.Size = new System.Drawing.Size(234, 28);
            this.saveNClose.TabIndex = 3;
            this.saveNClose.Text = "Save And Restart Application";
            this.saveNClose.UseVisualStyleBackColor = true;
            this.saveNClose.Click += new System.EventHandler(this.saveNClose_Click);
            // 
            // blockedmsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 509);
            this.Controls.Add(this.saveNClose);
            this.Controls.Add(this.msgHTML);
            this.Name = "blockedmsg";
            this.ShowIcon = false;
            this.Text = "Blocked Message :: Use HTML";
            this.Shown += new System.EventHandler(this.blockedmsg_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox msgHTML;
        private System.Windows.Forms.Button saveNClose;
    }
}