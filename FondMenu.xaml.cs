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
    /// Interaction logic for FondMenu.xaml
    /// </summary>
    public partial class FondMenu : Page
    {
        public FondMenu()
        {
            InitializeComponent();
            string[] FIO_Split = Manager.LoginEmployee.FIO.Split();
            FIO_Employee.Text = FIO_Split[0] + ' ' + FIO_Split[1][0] + ". " + FIO_Split[2][0] + '.';
        }

        private void OpenFond_Click(object sender, RoutedEventArgs e)
        {
            Manager.BaseFrame.Navigate(new ChooseFond());
        }

        private void GivenBook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CalendarView_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");
        }

        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Chat_View_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В разработке");
        }
    }
}
