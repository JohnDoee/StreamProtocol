using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamProtocol
{
    public partial class AllowedSitePrompt : Form
    {
        private bool isAllowed = false;
        private Uri url;

        public AllowedSitePrompt(Uri url)
        {
            this.url = url;
            InitializeComponent();
        }

        public bool IsAllowed()
        {
            this.urlLabel.Text = url.OriginalString;
            this.hostLabel.Text = url.Host;

            this.ShowDialog();

            return isAllowed;
        }

        private void alwaysAcceptButton_Click(object sender, EventArgs e)
        {
            isAllowed = true;

            AllowedSites.AddSite(url.Host, AllowedSites.SiteStatus.AlwaysAllow);

            this.Close();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            isAllowed = true;
            this.Close();
        }

        private void rejectButton_Click(object sender, EventArgs e)
        {
            isAllowed = false;
            this.Close();
        }

        private void alwaysRejectButton_Click(object sender, EventArgs e)
        {
            isAllowed = false;

            AllowedSites.AddSite(url.Host, AllowedSites.SiteStatus.AlwaysDeny);

            this.Close();
        }
    }
}
