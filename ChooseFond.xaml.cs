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
    /// Interaction logic for ChooseFond.xaml
    /// </summary>
    public partial class ChooseFond : Page
    {
        public ChooseFond()
        {
            InitializeComponent();
        }

        private void CreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            if(ChooseFoundtion.SelectionBoxItem.ToString() == "Детская библиотека")
            {
                Console.WriteLine("Kids");
                Manager.SelectedLib = "Kids";
                Manager.BaseFrame.Navigate(new KidsLibraryF1());
            }
            if (ChooseFoundtion.SelectionBoxItem.ToString() == "Центральная библиотека")
            {
                Console.WriteLine("Central");
                Manager.SelectedLib = "Central";
                Manager.BaseFrame.Navigate(new CentralLibrary());
            }
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            Manager.BaseFrame.GoBack();
        }
    }
}
