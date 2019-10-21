using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanicButton.Client
{
    internal class TrayClass : IDisposable
    {
        private readonly MainWindow _mainWindow;
        private readonly ContextMenu _mMenu;
        private readonly NotifyIcon _ni;

        public TrayClass(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            /* */
            _ni = new NotifyIcon { Icon = Properties.Resources.Icon1, Text = "Tray test", Visible = true };
            _ni.DoubleClick += TrayOpen_Click;
            /* menu */
            _mMenu = new ContextMenu();
            var a = new MenuItem
            {
                Name = "Zamknij",
                Text = "Zamknij"
            };
            a.Click += TrayExit_Click;
            _mMenu.MenuItems.Add(0, a);
            _ni.ContextMenu = _mMenu;

        }

        public void ShowTrayInformation(string title, string content)
        {
            _ni.BalloonTipTitle = title;
            _ni.BalloonTipText = content;
            _ni.BalloonTipIcon = ToolTipIcon.Info;
            _ni.Visible = true;
            _ni.ShowBalloonTip(30000);
            _ni.BalloonTipClicked += delegate (object sender, EventArgs args)
            {
                _mainWindow.Show();
                _mainWindow.Activate();
            };
        }

        private void TrayExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void TrayOpen_Click(object sender, EventArgs e)
        {
            _mainWindow.Show();
            _mainWindow.Activate();
        }

        public void Dispose()
        {
            _mMenu?.Dispose();
            _ni?.Dispose();
        }
    }
}
