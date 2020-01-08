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
    /// Interaction logic for DetailBooks.xaml
    /// </summary>
    public partial class DetailBooks : Window
    {
        QuanLyCuaHangBanSachEntities db = new QuanLyCuaHangBanSachEntities();
        Sach book = new Sach();
        public DetailBooks(string MaSach, string TenSach, int SoLuong,  double GiaTienBan, string TacGia, string NhaXuatBan)
        {
            InitializeComponent();
            var _book = from sach in db.Saches
                        where sach.MaSach == MaSach
                        select sach;
      
            book = _book.ToList()[0];
            BookDetailListBox.DataContext = book;
        }
        private void DelBookButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new DeleteBooks();
            screen.ShowDialog();
        }

        private void EditBookButton_Click(object sender, RoutedEventArgs e)
        {
            if(BookID.Text == "" || BookName.Text =="" || Amount.Text == "" || Price.Text =="" || Author.Text =="" || NXB.Text =="")
            {
                MessageBox.Show("Dữ liệu không hợp lệ");
            }
            else
            {
                book.MaSach = BookID.Text;
                book.TenSach = BookName.Text;
                book.SoLuong = Int32.Parse(Amount.Text);
                book.GiaTienBan = Double.Parse(Price.Text);
                book.TacGia = Author.Text;
                book.NhaXuatBan = NXB.Text;
                db.SaveChanges();
                MessageBox.Show("Thay đổi thông tin thành công");
                this.DialogResult = true;
            }
        }
    }
}
