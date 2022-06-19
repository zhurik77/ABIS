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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        ABIS_ModuleDBEntities DB = new ABIS_ModuleDBEntities();
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (DB.Employee.Where(r => r.Login == LoginBox.Text).Count() > 0
                    && (DB.Employee.Where(r => r.Password == PWDBox.Password.ToString()).Count() > 0))
                    
                {
                    Manager.LoginEmployee = DB.Employee.Where(r => r.Login == LoginBox.Text).FirstOrDefault();
                    BaseWindow mainWindow = new BaseWindow();
                    mainWindow.Show();
                    this.Close();
                    Console.WriteLine(Manager.LoginEmployee.FIO);
                }
                else
                {
                    MessageBox.Show("Введен неверный логин или пароль");
                }
            } 
            catch(Exception ert)
            {
                MessageBox.Show("Ошибка подключения к базе данных, перезапустите приложение");

            }
        }
    }
}
