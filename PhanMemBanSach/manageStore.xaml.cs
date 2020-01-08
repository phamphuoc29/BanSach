using PhanMemBanSach.ViewModels;
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
using System.Windows.Shapes;

namespace PhanMemBanSach
{
    /// <summary>
    /// Interaction logic for manageStore.xaml
    /// </summary>
    public partial class manageStore : Window
    {
        StoreManagementVM storeManaVM;

        private string _searchString;
        public string SearchString { get => _searchString; set { _searchString = value; } }

        public manageStore()
        {
            InitializeComponent();
            storeManaVM = new StoreManagementVM();
            DataContext = storeManaVM;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if(SearchString != null)
            {

            }
        }

        private void AddBooks_Click(object sender, RoutedEventArgs e)
        {
            var screen = new AddBooks();
            screen.ShowDialog();
        }

        private void EditBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (storeManaVM.SelectedBook != null)
            {
                var screen = new EditBooks(storeManaVM.SelectedBook);
                screen.ShowDialog();
                storeManaVM.LoadBook();
            }
            else
                MessageBox.Show("Vui lòng chọn sách!");
        }

        private void DelBookButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new DeleteBooks();
            screen.ShowDialog();
        }

        private void LvInfoBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (storeManaVM.SelectedBook != null)
            {
                var screen = new DetailBooks(storeManaVM.SelectedBook);
                screen.ShowDialog();
                storeManaVM.LoadBook();
            }
            else
                MessageBox.Show("Vui lòng chọn sách!");
        }

        private void AddCusButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new AddCustomer();
            screen.ShowDialog();
        }

        private void EditCusButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new EditCustomer();
            screen.ShowDialog();
        }

        private void DelCusButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new DeleteCustomer();
            screen.ShowDialog();
        }

        private void LvCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var screen = new DetailCustomer();
            screen.ShowDialog();
        }


    }
}
