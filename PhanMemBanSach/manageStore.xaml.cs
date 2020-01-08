using PhanMemBanSach.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        BindingList<Sach> booksInDB;
        QuanLyCuaHangBanSachEntities db = new QuanLyCuaHangBanSachEntities();
        // StoreManagementVM storeManaVM;
        public manageStore()
        {
            InitializeComponent();
            booksInDB = new BindingList<Sach>(db.Saches.ToList());
            lvInfoBooks.ItemsSource = booksInDB;
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
        }
        private void DelBookButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new DeleteBooks();
            screen.ShowDialog();
        }

        private void LvInfoBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var book = (Sach)lvInfoBooks.SelectedItem;
            var screen = new DetailBooks(book.MaSach,book.TenSach,book.SoLuong,book.GiaTienBan,book.TacGia,book.NhaXuatBan);
            if (screen.ShowDialog() == true)
            {
                MessageBox.Show("Thay đổi thành công");
               // booksInDB.Clear();
                booksInDB = new BindingList<Sach>(db.Saches.ToList());
             //   lvCustomer.Items.Clear();
                lvInfoBooks.ItemsSource = booksInDB;
            }
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
