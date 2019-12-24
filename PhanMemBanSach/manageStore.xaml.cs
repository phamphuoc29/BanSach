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
        public manageStore()
        {
            InitializeComponent();
            storeManaVM = new StoreManagementVM();
            DataContext = storeManaVM;
        }

        public class Customers
        {
            public string NumberPhone { get; set; }
            public string NameCus { get; set; }
            public string Birth { get; set; }
            public string Email { get; set; }
            public long Total { get; set; }
            public string DateUpdate { get; set; }
        }



        public class Notification
        {
            public string Date { get; set; }
            public string Act { get; set; }
            public string Detail { get; set; }
        }

        private void AddBooks_Click(object sender, RoutedEventArgs e)
        {
            var screen = new AddBooks();
            screen.ShowDialog();
        }

        private void EditBookButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new EditBooks();
            screen.ShowDialog();
        }

        private void DelBookButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new DeleteBooks();
            screen.ShowDialog();
        }

        private void LvInfoBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var screen = new DetailBooks();
            screen.ShowDialog();
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
