namespace StreamProtocol
{
    partial class AllowedSitesManager
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
            this.sitesTabs = new System.Windows.Forms.TabControl();
            this.allowedSitesTab = new System.Windows.Forms.TabPage();
            this.removeAllowedSites = new System.Windows.Forms.Button();
            this.allowedListBox = new System.Windows.Forms.ListBox();
            this.disallowedSitesTab = new System.Windows.Forms.TabPage();
            this.removeDisallowedButton = new System.Windows.Forms.Button();
            this.disallowedListBox = new System.Windows.Forms.ListBox();
            this.sitesTabs.SuspendLayout();
            this.allowedSitesTab.SuspendLayout();
            this.disallowedSitesTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // sitesTabs
            // 
            this.sitesTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sitesTabs.Controls.Add(this.allowedSitesTab);
            this.sitesTabs.Controls.Add(this.disallowedSitesTab);
            this.sitesTabs.Location = new System.Drawing.Point(2, 0);
            this.sitesTabs.Name = "sitesTabs";
            this.sitesTabs.SelectedIndex = 0;
            this.sitesTabs.Size = new System.Drawing.Size(324, 519);
            this.sitesTabs.TabIndex = 0;
            // 
            // allowedSitesTab
            // 
            this.allowedSitesTab.Controls.Add(this.removeAllowedSites);
            this.allowedSitesTab.Controls.Add(this.allowedListBox);
            this.allowedSitesTab.Location = new System.Drawing.Point(4, 29);
            this.allowedSitesTab.Name = "allowedSitesTab";
            this.allowedSitesTab.Padding = new System.Windows.Forms.Padding(3);
            this.allowedSitesTab.Size = new System.Drawing.Size(316, 486);
            this.allowedSitesTab.TabIndex = 0;
            this.allowedSitesTab.Text = "Allowed";
            this.allowedSitesTab.UseVisualStyleBackColor = true;
            // 
            // removeAllowedSites
            // 
            this.removeAllowedSites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeAllowedSites.Location = new System.Drawing.Point(6, 450);
            this.removeAllowedSites.Name = "removeAllowedSites";
            this.removeAllowedSites.Size = new System.Drawing.Size(304, 33);
            this.removeAllowedSites.TabIndex = 1;
            this.removeAllowedSites.Text = "Remove selected sites";
            this.removeAllowedSites.UseVisualStyleBackColor = true;
            this.removeAllowedSites.Click += new System.EventHandler(this.removeAllowedSites_Click);
            // 
            // allowedListBox
            // 
            this.allowedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.allowedListBox.FormattingEnabled = true;
            this.allowedListBox.ItemHeight = 20;
            this.allowedListBox.Location = new System.Drawing.Point(0, 0);
            this.allowedListBox.Name = "allowedListBox";
            this.allowedListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.allowedListBox.Size = new System.Drawing.Size(316, 444);
            this.allowedListBox.TabIndex = 0;
            // 
            // disallowedSitesTab
            // 
            this.disallowedSitesTab.Controls.Add(this.removeDisallowedButton);
            this.disallowedSitesTab.Controls.Add(this.disallowedListBox);
            this.disallowedSitesTab.Location = new System.Drawing.Point(4, 29);
            this.disallowedSitesTab.Name = "disallowedSitesTab";
            this.disallowedSitesTab.Padding = new System.Windows.Forms.Padding(3);
            this.disallowedSitesTab.Size = new System.Drawing.Size(316, 486);
            this.disallowedSitesTab.TabIndex = 1;
            this.disallowedSitesTab.Text = "Disallowed";
            this.disallowedSitesTab.UseVisualStyleBackColor = true;
            // 
            // removeDisallowedButton
            // 
            this.removeDisallowedButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeDisallowedButton.Location = new System.Drawing.Point(6, 450);
            this.removeDisallowedButton.Name = "removeDisallowedButton";
            this.removeDisallowedButton.Size = new System.Drawing.Size(304, 33);
            this.removeDisallowedButton.TabIndex = 3;
            this.removeDisallowedButton.Text = "Remove selected sites";
            this.removeDisallowedButton.UseVisualStyleBackColor = true;
            this.removeDisallowedButton.Click += new System.EventHandler(this.removeDisallowedButton_Click);
            // 
            // disallowedListBox
            // 
            this.disallowedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.disallowedListBox.FormattingEnabled = true;
            this.disallowedListBox.ItemHeight = 20;
            this.disallowedListBox.Location = new System.Drawing.Point(0, 0);
            this.disallowedListBox.Name = "disallowedListBox";
            this.disallowedListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.disallowedListBox.Size = new System.Drawing.Size(316, 444);
            this.disallowedListBox.TabIndex = 2;
            // 
            // AllowedSitesManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 517);
            this.Controls.Add(this.sitesTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AllowedSitesManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sites Manager";
            this.sitesTabs.ResumeLayout(false);
            this.allowedSitesTab.ResumeLayout(false);
            this.disallowedSitesTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl sitesTabs;
        private System.Windows.Forms.TabPage allowedSitesTab;
        private System.Windows.Forms.TabPage disallowedSitesTab;
        private System.Windows.Forms.ListBox allowedListBox;
        private System.Windows.Forms.Button removeAllowedSites;
        private System.Windows.Forms.Button removeDisallowedButton;
        private System.Windows.Forms.ListBox disallowedListBox;
    }
}