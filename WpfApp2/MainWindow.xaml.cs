using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TrayClass _trayClass;

        public MainWindow()
        {
            InitializeComponent(); 
            _trayClass = new TrayClass(this);
            _trayClass.ShowTrayInformation("cosik", "dziala");
            this.Closed += (sender, args) => _trayClass?.Dispose();
        }



        
        
    }
}
