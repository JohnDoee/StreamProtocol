namespace StreamProtocol
{
    partial class AllowedSitePrompt
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
            this.acceptButton = new System.Windows.Forms.Button();
            this.urlLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rejectButton = new System.Windows.Forms.Button();
            this.alwaysRejectButton = new System.Windows.Forms.Button();
            this.alwaysAcceptButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(12, 407);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(180, 32);
            this.acceptButton.TabIndex = 1;
            this.acceptButton.Text = "Yes";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // urlLabel
            // 
            this.urlLabel.Location = new System.Drawing.Point(12, 29);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(365, 211);
            this.urlLabel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "You are trying to stream this link:";
            // 
            // rejectButton
            // 
            this.rejectButton.Location = new System.Drawing.Point(198, 407);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(180, 32);
            this.rejectButton.TabIndex = 6;
            this.rejectButton.Text = "No";
            this.rejectButton.UseVisualStyleBackColor = true;
            this.rejectButton.Click += new System.EventHandler(this.rejectButton_Click);
            // 
            // alwaysRejectButton
            // 
            this.alwaysRejectButton.Location = new System.Drawing.Point(198, 369);
            this.alwaysRejectButton.Name = "alwaysRejectButton";
            this.alwaysRejectButton.Size = new System.Drawing.Size(180, 32);
            this.alwaysRejectButton.TabIndex = 7;
            this.alwaysRejectButton.Text = "Always No";
            this.alwaysRejectButton.UseVisualStyleBackColor = true;
            this.alwaysRejectButton.Click += new System.EventHandler(this.alwaysRejectButton_Click);
            // 
            // alwaysAcceptButton
            // 
            this.alwaysAcceptButton.Location = new System.Drawing.Point(12, 369);
            this.alwaysAcceptButton.Name = "alwaysAcceptButton";
            this.alwaysAcceptButton.Size = new System.Drawing.Size(180, 32);
            this.alwaysAcceptButton.TabIndex = 8;
            this.alwaysAcceptButton.Text = "Always Yes";
            this.alwaysAcceptButton.UseVisualStyleBackColor = true;
            this.alwaysAcceptButton.Click += new System.EventHandler(this.alwaysAcceptButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "This link is from host:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Do you want to accept it?";
            // 
            // hostLabel
            // 
            this.hostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostLabel.Location = new System.Drawing.Point(12, 264);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(365, 82);
            this.hostLabel.TabIndex = 11;
            // 
            // AllowedSitePrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 451);
            this.Controls.Add(this.hostLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.alwaysAcceptButton);
            this.Controls.Add(this.alwaysRejectButton);
            this.Controls.Add(this.rejectButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.acceptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AllowedSitePrompt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StreamProtocol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.Button alwaysRejectButton;
        private System.Windows.Forms.Button alwaysAcceptButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label hostLabel;
    }
}