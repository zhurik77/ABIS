using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace ABIS_Module
{
    /// <summary>
    /// Interaction logic for BaseWindow.xaml
    /// </summary>
    public partial class BaseWindow : Window
    {
        public BaseWindow()
        {
            InitializeComponent();
            Manager.MenuFrame = MenuBar;
            Manager.BaseFrame = WorkSpace;
            Console.WriteLine("Check start");
            if (Manager.LoginEmployee.Position.Trim() == "Директор")
            {
                Console.WriteLine("Director");
                Manager.MenuFrame.Navigate(new DirectorMenu());
            }
            if(Manager.LoginEmployee.Position.Trim() == "Библиотекарь")
            {
                Manager.MenuFrame.Navigate(new FondMenu());
                Manager.BaseFrame.Navigate(new MainDTInfoPage());
                Console.WriteLine("Library");
            }
            if(Manager.LoginEmployee.Position.Trim() == "Эксперт по комплектованию библиотечного фонда")
            {

            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
