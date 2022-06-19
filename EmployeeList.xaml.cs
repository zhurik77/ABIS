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
    /// Interaction logic for EmployeeList.xaml
    /// </summary>
    public partial class EmployeeList : Page
    {
        
        public EmployeeList()
        {
            InitializeComponent();
            MainDG.ItemsSource = ABIS_ModuleDBEntities.GetContext().Employee.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.BaseFrame.Navigate(new AddEmployee((sender as Button).DataContext as Employee));
        }

        private void CreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            Manager.BaseFrame.Navigate(new AddEmployee(null));
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            var employeeForDeleting = MainDG.SelectedItems.Cast<Employee>().ToList();
            if(MessageBox.Show($"Вы точно хотите удалить следующие {employeeForDeleting.Count()} элементов?","АБИС Вагай",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ABIS_ModuleDBEntities.GetContext().Employee.RemoveRange(employeeForDeleting);
                    ABIS_ModuleDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    MainDG.ItemsSource = ABIS_ModuleDBEntities.GetContext().Employee.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }

        private void RefreshDG_Click(object sender, RoutedEventArgs e)
        {
            MainDG.ItemsSource = ABIS_ModuleDBEntities.GetContext().Employee.ToList();
        }

        private void MainDG_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                ABIS_ModuleDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                MainDG.ItemsSource = ABIS_ModuleDBEntities.GetContext().Employee.ToList();
            }
        }
    }
}
