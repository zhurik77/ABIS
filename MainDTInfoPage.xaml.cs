using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ABIS_Module
{
    /// <summary>
    /// Interaction logic for MainDTInfoPage.xaml
    /// </summary>
    public partial class MainDTInfoPage : Page
    {
        
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        public MainDTInfoPage()
        {
            ABIS_ModuleDBEntities DB = new ABIS_ModuleDBEntities();
            InitializeComponent();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
            int a = DB.KidsLibrary.Count();
            label2.Content = a;
            int b = DB.MainLibrary.Count();
            label3.Content = b;
        }



        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            label1.Content = d.Hour + " : " + d.Minute + " : " + d.Second;
        }
    }
}
