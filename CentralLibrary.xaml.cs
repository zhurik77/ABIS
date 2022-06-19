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
    /// Interaction logic for CentralLibrary.xaml
    /// </summary>
    public partial class CentralLibrary : Page
    {
        public CentralLibrary()
        {
            InitializeComponent();
            FiltertextBox.ItemsSource = new string[] { "ФИО", "Название", "Жанр", "Год", "Серийный номер", "Наличие" }; 
            ABIS_ModuleDBEntities DB = new ABIS_ModuleDBEntities();
            CentralList.ItemsSource = DB.MainLibrary.ToList();
            FiltertextBox.ItemsSource = typeof(MainLibrary).GetProperties().Select((o) => o.Name);
        }
        public Predicate<object> GetFilter()
        {
            switch(FiltertextBox.SelectedItem as string)
            {
                case "ФИО":
                    return NameFilter;
                case "Название":
                    return TitleFilter;
                case "Жанр":
                    return TitleTypeFilter;
                case "Год":
                    return YearFilter;
                case "Серийный номер":
                    return SNFilter;
                case "Наличие":
                    return AvalibleFilter;
            }
            return NameFilter;
        }

        private bool NameFilter(object obj)
        {
            var FilterObj = obj as MainLibrary;
            string FilterObj1 = FilterObj.FIO_Author.ToLower().ToString();
            return FilterObj1.Contains(SearchThread.Text.ToLower());
        }
        private bool TitleFilter(object obj)
        {
            var FilterObj = obj as MainLibrary;
            string FilterObj1 = FilterObj.Title.ToLower().ToString();
            return FilterObj1.Contains(SearchThread.Text.ToLower());
        }
        private bool TitleTypeFilter(object obj)
        {
            var FilterObj = obj as MainLibrary;
            string FilterObj1 = FilterObj.TitleType.ToLower().ToString();
            return FilterObj1.Contains(SearchThread.Text.ToLower());
        }
        private bool YearFilter(object obj)
        {
            var FilterObj = obj as MainLibrary;
            string FilterObj1 = FilterObj.Year.ToLower().ToString();
            return FilterObj1.Contains(SearchThread.Text.ToLower());
        }
        private bool SNFilter(object obj)
        {
            var FilterObj = obj as MainLibrary;
            string FilterObj1 = FilterObj.SerialNumber.ToLower().ToString();
            return FilterObj1.Contains(SearchThread.Text.ToLower());
        }
        private bool AvalibleFilter(object obj)
        {
            var FilterObj = obj as MainLibrary;
            string FilterObj1 = FilterObj.IsAvalible.ToString();
            return FilterObj1.Contains(SearchThread.Text.ToLower());
        }
        private void SearchBook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void returnBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.BaseFrame.Navigate(new MainDTInfoPage());
        }

        private void SearchThread_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(SearchThread.Text == null)
            {
                CentralList.Items.Filter = null;
            }
            else
            {
                CentralList.Items.Filter = GetFilter();
            }
        }

        private void FiltertextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CentralList.Items.Filter = GetFilter();

        }
    }
}
