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
    /// Interaction logic for DirectorMenu.xaml
    /// </summary>
    public partial class DirectorMenu : Page
    {
        public DirectorMenu()
        {
            InitializeComponent();
            string[] FIO_Split = Manager.LoginEmployee.FIO.Split();
            FIO_Employee.Text = FIO_Split[0]+' ' + FIO_Split[1][0]+". " + FIO_Split[2][0]+'.';
        }

        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Employee_View_Click(object sender, RoutedEventArgs e)
        {
            Manager.BaseFrame.Navigate(new EmployeeList());
        }

        private void Entertament_View_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Chat_View_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
