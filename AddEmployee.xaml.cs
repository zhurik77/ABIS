using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Page
    {
        private Employee _currentEmployee = new Employee();
        public AddEmployee(Employee selectedEmployee)
        {
            if(selectedEmployee !=null)
                _currentEmployee = selectedEmployee;

            InitializeComponent();
            DataContext = _currentEmployee;
        }

        private void CreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            Regex PhoneCheck = new Regex("^([9]{1}[0-9]{9})?$");
            
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentEmployee.FIO))
                errors.AppendLine("Введите ФИО");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Login))
                errors.AppendLine("Введите логин");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Password))
                errors.AppendLine("Введите пароль");
            if (_currentEmployee.Phone != null)
            {
                Console.WriteLine(PhoneCheck.IsMatch(_currentEmployee.Phone).ToString());
            }
            else
            {
                errors.AppendLine("Ошибка номера");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentEmployee.Id == 0)
                ABIS_ModuleDBEntities.GetContext().Employee.Add(_currentEmployee);
            try
            {
                ABIS_ModuleDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Сотрудник добавлен");
                Manager.BaseFrame.GoBack();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            Manager.BaseFrame.Navigate(new EmployeeList());
        }
    }
}
