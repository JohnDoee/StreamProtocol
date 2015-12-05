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
    public partial class AllowedSitesManager : Form
    {
        public AllowedSitesManager()
        {
            InitializeComponent();

            reloadData();
        }

        private void reloadData()
        {
            this.disallowedListBox.Items.Clear();
            this.allowedListBox.Items.Clear();

            foreach (var site in AllowedSites.GetAllSites())
            {
                if (site.Value == AllowedSites.SiteStatus.AlwaysAllow)
                    this.allowedListBox.Items.Add(site.Key);
                else
                    this.disallowedListBox.Items.Add(site.Key);
            }
        }

        private void removeDisallowedButton_Click(object sender, EventArgs e)
        {
            foreach (string site in this.disallowedListBox.SelectedItems)
                AllowedSites.DeleteSite(site);

            reloadData();
        }

        private void removeAllowedSites_Click(object sender, EventArgs e)
        {
            foreach (string site in this.allowedListBox.SelectedItems)
                AllowedSites.DeleteSite(site);

            reloadData();
        }
    }
}
