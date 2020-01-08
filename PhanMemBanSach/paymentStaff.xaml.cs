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



        List<Sach> booksInDatabase = new List<Sach>();
        QuanLyCuaHangBanSachEntities db = new QuanLyCuaHangBanSachEntities();
        List<KhachHang> khachhang = new List<KhachHang>();

        public paymentStaff()
        {
            InitializeComponent();
            DateTextBlock.Text = DateTime.Now.ToShortDateString();
            booksInDatabase = db.Saches.ToList();
        }

        /// <summary>
        /// chứa các sách có trong cơ sở dử liệu
        /// </summary>
        class DonHang
        {
            public string MaSach { get; set; }
            public string TenSach { get; set; }
            public int SoLuong { get; set; }
            public double GiaTien { get; set; }
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
                foreach (var book in books)
                {
                    if (book.MaSach == bookID)
                    {
                        return true;
                    }
                }
                return false;
            }


            public static void addBookToCart(ref BindingList<DonHang> cart, List<Sach> books, string bookID, int qty)
            {
                foreach (var book in books)
                {
                    if (book.MaSach == bookID)
                    {
                        DonHang item = new DonHang();
                        item.MaSach = book.MaSach;
                        item.TenSach = book.TenSach;
                        item.SoLuong = qty;
                        item.GiaTien = book.GiaTienBan;
                        cart.Add(item);
                    }
                }
            }

            public static void updateCart(ref BindingList<DonHang> cart, int qty, string bookID)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    if (cart[i].MaSach == bookID)
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

            public static double getTotal(BindingList<DonHang> cart)
            {
                double total = 0;
                for (int i = 0; i < cart.Count; i++)
                {
                    total += cart[i].GiaTien * cart[i].SoLuong;
                }
                return total;
            }

            public static double getTax(double total)
            {
                double tax = 0;
                tax = 0.1 * total;
                return tax;
            }

            public static bool CheckPhone(string phone, QuanLyCuaHangBanSachEntities db)
            {
                bool check = false;
                var customer = from khachhang in db.KhachHangs
                               where khachhang.SDT_KH == phone
                               select khachhang;
                if (customer.ToList().Count > 0)
                {
                    check = true;
                }
                return check;
            }
            public static bool checkMaHoaDon(string maHD, QuanLyCuaHangBanSachEntities db)
            {
                bool isNotValid = false;
                var maHoaDon = Int32.Parse(maHD);
                var hoadon = from hd in db.HoaDons
                             where hd.MaHD == maHoaDon
                             select hd;
                if(hoadon.ToList().Count > 0)
                {
                    isNotValid = true;
                }
                return isNotValid;
            }


            public static bool CheckOut(BindingList<DonHang> books, List<Sach> booksInDatabase, QuanLyCuaHangBanSachEntities db, List<KhachHang> customer)
            {
                //luu xuong hoa don
                var total = getTotal(books);
                var tax = getTax(total);
                String maHoaDon;
                do
                {
                    Random generator = new Random();
                    maHoaDon = generator.Next(0, 999999).ToString("D6");
                
                } while (checkMaHoaDon(maHoaDon,db));
                string customerPhone = null;
                if (customer.Count != 0)
                {
                    customerPhone = customer[0].SDT_KH;
                    //luu tong giao dich cua khach hang
                    customer[0].TongGiaoDich += (decimal)total;
                }
           
                db.HoaDons.Add(new HoaDon() { MaHD  = Int32.Parse(maHoaDon),  NgayLap = DateTime.Now, KhachHang = customerPhone, TongGiaTriHD = (decimal)total, TAX = (decimal)tax });


                //luu xuong chi tiet hoa don

                foreach(var book in books)
                {
                    db.ChiTietHoaDons.Add(new ChiTietHoaDon() {HoaDon =Int32.Parse(maHoaDon) , MaSachMua = book.MaSach, SoLuongMua = book.SoLuong, TongTien = (decimal)(book.SoLuong * book.GiaTien) });
                }

                //luu lai du lieu so luong sach
                for (int i = 0; i < books.Count; i++)
                {
                    for (int j = 0; j < booksInDatabase.Count; j++)
                    {
                        if (books[i].MaSach == booksInDatabase[j].MaSach)
                        {
                            booksInDatabase[j].SoLuong -= books[i].SoLuong;
                        }
                    }
                }

                db.SaveChanges();
                return true;
            }
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            var bookID = maSachTextBox.Text.ToUpper();
            var qty = QuantityTextBox.Text;
            if (bookID == "")
            {
                MessageBox.Show("Chưa nhập mã sách");
            }
            else if (qty == "")
            {
                MessageBox.Show("Chưa nhập số lượng sách");
            }
            else
            {
                int quantity = Int32.Parse(qty);
                bool isValid = ThuNganBUS.isVaLidBook(booksInDatabase, bookID);
                if (isValid == false)
                {
                    MessageBox.Show("Sách vừa nhập không có trong dữ liệu");
                }
                else
                {
                    ThuNganBUS.addBookToCart(ref booksInCart, booksInDatabase, bookID, quantity);
                    lvBooks.ItemsSource = booksInCart;
                }

                var total = ThuNganBUS.getTotal(booksInCart);
                var tax = ThuNganBUS.getTax(total);
                TaxTextBlock.Text = tax.ToString() + " đ";
                TotalPriceTextBlock.Text = (total+tax).ToString() + " đ";
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
            TotalPriceTextBlock.Text = (total + tax).ToString() + " đ";
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            bool state = ThuNganBUS.CheckOut(booksInCart, booksInDatabase, db, khachhang);
            if (state == true)
            {
                //xoa thong tin khach hang
                khachhang.Clear();
                //xoa hoa don
                booksInCart.Clear();

                maSachTextBox.Text = "";
                QuantityTextBox.Text = "";
                KMaiTextBox.Text = "";
                CustomerListBox.ItemsSource = khachhang;
                lvBooks.ItemsSource = booksInCart;
                MessageBox.Show("Thanh toán hóa đơn thành công");
            }

        }

        private void CustomerButton_Click(object sender, RoutedEventArgs e)
        {
            var CustomerWindow = new Customer();
            var phone = KMaiTextBox.Text;
            var checkPhone = ThuNganBUS.CheckPhone(phone, db);
            if (checkPhone == false)
            {
                if (CustomerWindow.ShowDialog() == true)
                {
                    MessageBox.Show("Đã thêm khách hàng thành công");
                }
            }
            else
            {
                var customer = from kh in db.KhachHangs
                               where kh.SDT_KH == phone
                               select kh;

                khachhang = customer.ToList();
                CustomerListBox.ItemsSource = khachhang;
            }
        }

        private void LvBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
