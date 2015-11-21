using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Configuration;
using Microsoft.Win32;

namespace StreamProtocol
{
    class TrayIcon : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;

        public TrayIcon()
        {
            trayIcon = new NotifyIcon();
            trayIcon.Text = "StreamProtocol";
            trayIcon.Icon = new Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream("StreamProtocol.Resources.trayicon.ico"), 40, 40);
            trayIcon.Visible = true;

            UpdateTrayMenu();
        }

        private void UpdateTrayMenu()
        {
            trayMenu = new ContextMenu();

            foreach (var handler in ProtocolHandlerManager.GetProtocolHandlers())
            {
                var subMenu = new MenuItem($"Protocol {handler.Name}");
                //subMenu.Checked = true;
                trayMenu.MenuItems.Add(subMenu);
                var browseMenuItem = subMenu.MenuItems.Add("Browse for file");
                browseMenuItem.Click += new EventHandler((s, e) => OnHandlerSelect(s, e, handler));

                var apps = handler.GetApplications();
                foreach (var app in apps)
                {
                    if (app.Enabled)
                    {
                        var menuItem = subMenu.MenuItems.Add($"Open with {app.Name}");
                        menuItem.Click += new EventHandler((s, e) => OnSelectApplication(s, e, handler, app));
                        if (app.CurrentlySelected)
                            menuItem.Checked = true;
                    }

                }
                if (apps.Any((app) => app.CurrentlySelected))
                {
                    subMenu.MenuItems.Add("-");
                    var removeMenuItem = subMenu.MenuItems.Add("Remove protocol");
                    removeMenuItem.Click += new EventHandler((s, e) => OnDisableHandler(s, e, handler));
                }
            }

            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add("About", OnAbout);
            trayMenu.MenuItems.Add("Exit", OnExit);

            trayIcon.ContextMenu = trayMenu;
        }

        private string OpenHandlerFileDialog()
        {
            OpenFileDialog handlerFileDialog = new OpenFileDialog();
            handlerFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            handlerFileDialog.Filter = "Executables (*.exe)|*.exe|All files (*.*)|*.*";
            handlerFileDialog.FilterIndex = 0;
            handlerFileDialog.RestoreDirectory = true;

            if (handlerFileDialog.ShowDialog() == DialogResult.OK)
            {
                return handlerFileDialog.FileName;
            }
            return null;
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void OnDisableHandler(object sender, EventArgs e, ProtocolHandler handler)
        {
            Debug.WriteLine($"Removing handler from {handler.Name}");
            handler.UnsetApplication();
            UpdateTrayMenu();
        }

        private void OnSelectApplication(object sender, EventArgs e, ProtocolHandler handler, ProtocolApplication app)
        {
            Debug.WriteLine($"Setting handler for {handler.Name} to app {app.Name}");
            handler.SetApplication(app);
            UpdateTrayMenu();
        }

        private void OnHandlerSelect(object sender, EventArgs e, ProtocolHandler handler)
        {
            var executable = OpenHandlerFileDialog();
            if (executable != null && executable.Length > 0)
            {
                var app = new ProtocolApplication(executable.Split('\\').Last(), executable);
                OnSelectApplication(sender, e, handler, app);
            }
        }

        private void OnAbout(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Release the icon resource.
                trayIcon.Dispose();
            }

            base.Dispose(isDisposing);
        }
    }
}
