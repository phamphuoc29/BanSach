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
        StoreManagementVM storeManaVM;

        public manageStore()
        {
            InitializeComponent();
            storeManaVM = new StoreManagementVM();
            this.DataContext = storeManaVM;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if(storeManaVM.SearchString != null)
            {
                var books = DataProvider.Ins.DB.SearchBook(storeManaVM.SearchString);
                storeManaVM.ListBook.Clear();
                foreach(var book in books)
                {
                    storeManaVM.ListBook.Add(new Sach { MaSach = book.MaSach, TenSach = book.TenSach, TacGia = book.TacGia, NhaXuatBan = book.NhaXuatBan, SoLuong = book.SoLuong, GiaTienBan = book.GiaTienBan });
                }
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
            if (storeManaVM.SelectedBook != null)
            {
                var screen = new DeleteBooks(storeManaVM.SelectedBook.MaSach);
                screen.ShowDialog();
                storeManaVM.LoadBook();
            }
            else
                MessageBox.Show("Vui lòng chọn sách!");
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

        private void searchBookTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int result = DataProvider.Ins.DB.insertChiTieu(storeManaVM.Thang, storeManaVM.Nam, storeManaVM.TienDien, storeManaVM.TienNuoc, storeManaVM.TienLuongNV, storeManaVM.TienInternet,storeManaVM.TienThueNha, storeManaVM.Khac);
                DataProvider.Ins.DB.SaveChanges();
                if (result == 1)
                    MessageBox.Show("Thêm chi tiết chi tiêu thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL error:" + ex.Message.ToString());
            }
        }
    }
}
