using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfApp2
{
    internal class TrayClass : IDisposable
    {
        private MainWindow mainWindow;
        private System.Windows.Forms.ContextMenu m_menu;
        private NotifyIcon ni;

        public TrayClass(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            /* */
            ni = new NotifyIcon { Icon = Properties.Resources.Icon1, Text = "Tray test", Visible = true };
            ni.DoubleClick += TrayOpen_Click;
            /* menu */
            m_menu = new System.Windows.Forms.ContextMenu();
            var a = new System.Windows.Forms.MenuItem
            {
                Name = "Zamknij",
                Text = "Zamknij"
            };
            a.Click += TrayExit_Click;
            m_menu.MenuItems.Add(0, a);
            ni.ContextMenu = m_menu;

        }

        public void ShowTrayInformation(string Title, string Content)
        {
            ni.BalloonTipTitle = Title;
            ni.BalloonTipText = Content;
            ni.BalloonTipIcon = ToolTipIcon.Info;
            ni.Visible = true;
            ni.ShowBalloonTip(30000);
            ni.BalloonTipClicked += delegate (object sender, EventArgs args)
            {
                mainWindow.Show();
                mainWindow.Activate();
            };
        }

        private void TrayExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void TrayOpen_Click(object sender, EventArgs e)
        {
            mainWindow.Show();
            mainWindow.Activate();
        }

        public void Dispose()
        {
            m_menu?.Dispose();
            ni?.Dispose();
        }
    }
}
