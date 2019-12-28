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
    /// Interaction logic for paymentStaff.xaml
    /// </summary>
    public partial class paymentStaff : Window
    {

        /// <summary>
        /// chứa các sách có trong cơ sở dử liệu
        /// </summary>
        List<Sach> booksInDatabase = new List<Sach>();
        class DonHang
        {
            public string MaSach { get; set; }
            public string TenSach { get; set; }
            public int SoLuong { get; set; }
            public decimal GiaTien { get; set; } 
        }


        BindingList<DonHang> booksInCart = new BindingList<DonHang>();

        /// <summary>
        /// Class dùng để xử lý các nghiệp vụ thu ngân
        /// </summary>
        class ThuNganBUS
        {

            /// <summary>
            /// hàm kiểm tra mã sách vừa nhập có trong cơ sở dử liệu hay không
            /// </summary>
            /// <param name="bookID"></param>
            /// <returns></returns>
            public static bool isVaLidBook(List<Sach> books, string bookID)
            {
                var numberOfBooks = books.Count;
                foreach(var book in books)
                {
                    if(book.MaSach == bookID)
                    {
                        return true;
                    }
                }
                return false;
            }


            public static void addBookToCart(ref BindingList<DonHang> cart,List<Sach> books, string bookID)
            {
                foreach (var book in books)
                {
                    if (book.MaSach == bookID)
                    {
                        DonHang item = new DonHang();
                        item.MaSach = book.MaSach;
                        item.TenSach = book.TenSach;
                        item.SoLuong = 1;
                        item.GiaTien = book.GiaTienBan;
                        cart.Add(item);
                    }
                }
            }

            public static void updateCart(ref BindingList<DonHang> cart, int qty, string bookID)
            {
                for(int i=0; i< cart.Count; i++)
                {
                    if(cart[i].MaSach == bookID)
                    {
                        cart[i].SoLuong = qty;
                    }
                }
            }

            public static void deleteBook(ref BindingList<DonHang> cart, string bookID)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    if (cart[i].MaSach == bookID)
                    {
                        cart.RemoveAt(i);
                    }
                }
            }

            public static decimal getTotal(BindingList<DonHang> cart)
            {
                decimal total = 0;
                for(int i = 0;i < cart.Count; i++)
                {
                    total += cart[i].GiaTien * cart[i].SoLuong;
                }
                return total;
            }

            public static decimal getTax(decimal total)
            {
                decimal tax = 0;
                tax = (decimal)0.1 * total;
                return tax;
            }

        }

        public paymentStaff()
        {
            InitializeComponent();
            var db = new QuanLyCuaHangBanSachEntities();          
            booksInDatabase = db.Saches.ToList();   
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            var bookID = maSachTextBox.Text;
            bool isValid = ThuNganBUS.isVaLidBook(booksInDatabase, bookID);
            if( isValid == false )
            {
                MessageBox.Show("Sách vừa nhập không có trong dữ liệu");
            }
            else
            {
                ThuNganBUS.addBookToCart(ref booksInCart,booksInDatabase,bookID);
                lvBooks.ItemsSource = booksInCart;
            }

            var total = ThuNganBUS.getTotal(booksInCart);
            var tax = ThuNganBUS.getTax(total);
            TaxTextBlock.Text = tax.ToString() + " đ";
            TotalPriceTextBlock.Text = total.ToString() + " đ";
            
        }

        private void LvBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
        }

        private void BookQuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if(textBox.Text != "")
            { 
                var newQuantity =Int32.Parse(textBox.Text);
                ThuNganBUS.updateCart(ref booksInCart, newQuantity ,(string)textBox.Tag);
                lvBooks.ItemsSource = booksInCart;

                var total = ThuNganBUS.getTotal(booksInCart);
                var tax = ThuNganBUS.getTax(total);
                TaxTextBlock.Text = tax.ToString() + " đ";
                TotalPriceTextBlock.Text = total.ToString() + " đ";
            }
        }

        private void DeleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            ThuNganBUS.deleteBook(ref booksInCart, button.Tag.ToString());

            lvBooks.ItemsSource = booksInCart;
            var total = ThuNganBUS.getTotal(booksInCart);
            var tax = ThuNganBUS.getTax(total);
            TaxTextBlock.Text = tax.ToString() + " đ";
            TotalPriceTextBlock.Text = total.ToString() + " đ";
        }
    }
}
