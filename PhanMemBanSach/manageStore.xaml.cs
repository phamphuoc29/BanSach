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
        public manageStore()
        {
            InitializeComponent();

            //list Notification
            var listNoTify = new List<Notification>();
            listNoTify.Add(new Notification() { Date = "17/02/2017", Act = "Hết hàng", Detail = "MSS0001XX - Sự cứu rỗi của thánh nữ (2019) - Higashino Keigo" });
            listNoTify.Add(new Notification() { Date = "16/02/2017", Act = "Cập nhật chi tiêu tháng 2", Detail = "" });
            listNoTify.Add(new Notification() { Date = "15/02/2017", Act = "Nhập hàng thành công", Detail = "20x MSS0001XX - Sự cứu rỗi của thánh nữ (2019) - Higashino Keigo" });
            listNoTify.Add(new Notification() { Date = "14/02/2017", Act = "Cập nhật chi tiêu tháng 2", Detail = "" });
            listNoTify.Add(new Notification() { Date = "13/02/2017", Act = "Hết hàng", Detail = "MSS0001XX - Sự cứu rỗi của thánh nữ (2019) - Higashino Keigo" });
            lvNotification.ItemsSource = listNoTify;

            //list Books
            var listBooks = new List<Books>();
            listBooks.Add(new Books() { IDBook = "MSS0001XX", NameBook = "Sự cứu rỗi của thánh nữ (2019)", Price = 90000, Amount = 20, Author = "Higashino Keigo", Publish = "NXB Trẻ", DateUpdate = "30/11/2018" });
            listBooks.Add(new Books() { IDBook = "MSS0001XX", NameBook = "Sự cứu rỗi của thánh nữ (2019)", Price = 90000, Amount = 20, Author = "Higashino Keigo", Publish = "NXB Trẻ", DateUpdate = "30/11/2018" });
            listBooks.Add(new Books() { IDBook = "MSS0001XX", NameBook = "Sự cứu rỗi của thánh nữ (2019)", Price = 90000, Amount = 20, Author = "Higashino Keigo", Publish = "NXB Trẻ", DateUpdate = "30/11/2018" });
            listBooks.Add(new Books() { IDBook = "MSS0001XX", NameBook = "Sự cứu rỗi của thánh nữ (2019)", Price = 90000, Amount = 20, Author = "Higashino Keigo", Publish = "NXB Trẻ", DateUpdate = "30/11/2018" });
            listBooks.Add(new Books() { IDBook = "MSS0001XX", NameBook = "Sự cứu rỗi của thánh nữ (2019)", Price = 90000, Amount = 20, Author = "Higashino Keigo", Publish = "NXB Trẻ", DateUpdate = "30/11/2018" });
            listBooks.Add(new Books() { IDBook = "MSS0001XX", NameBook = "Sự cứu rỗi của thánh nữ (2019)", Price = 90000, Amount = 20, Author = "Higashino Keigo", Publish = "NXB Trẻ", DateUpdate = "30/11/2018" });
            listBooks.Add(new Books() { IDBook = "MSS0001XX", NameBook = "Sự cứu rỗi của thánh nữ (2019)", Price = 90000, Amount = 20, Author = "Higashino Keigo", Publish = "NXB Trẻ", DateUpdate = "30/11/2018" });
            listBooks.Add(new Books() { IDBook = "MSS0001XX", NameBook = "Sự cứu rỗi của thánh nữ (2019)", Price = 90000, Amount = 20, Author = "Higashino Keigo", Publish = "NXB Trẻ", DateUpdate = "30/11/2018" });
            lvInfoBooks.ItemsSource = listBooks;

            //list customer
            var listCustomer = new List<Customers>();
            listCustomer.Add(new Customers() { NumberPhone = "0123456789", NameCus = "Nguyen van A", Birth = "01/01/1999", Email = "nguyenvana@gmail.com", Total = 500000, DateUpdate = "30/11/2018" });
            listCustomer.Add(new Customers() { NumberPhone = "0123456789", NameCus = "Nguyen van A", Birth = "01/01/1999", Email = "nguyenvana@gmail.com", Total = 500000, DateUpdate = "30/11/2018" });
            listCustomer.Add(new Customers() { NumberPhone = "0123456789", NameCus = "Nguyen van A", Birth = "01/01/1999", Email = "nguyenvana@gmail.com", Total = 500000, DateUpdate = "30/11/2018" });
            listCustomer.Add(new Customers() { NumberPhone = "0123456789", NameCus = "Nguyen van A", Birth = "01/01/1999", Email = "nguyenvana@gmail.com", Total = 500000, DateUpdate = "30/11/2018" });
            listCustomer.Add(new Customers() { NumberPhone = "0123456789", NameCus = "Nguyen van A", Birth = "01/01/1999", Email = "nguyenvana@gmail.com", Total = 500000, DateUpdate = "30/11/2018" });
            listCustomer.Add(new Customers() { NumberPhone = "0123456789", NameCus = "Nguyen van A", Birth = "01/01/1999", Email = "nguyenvana@gmail.com", Total = 500000, DateUpdate = "30/11/2018" });
            listCustomer.Add(new Customers() { NumberPhone = "0123456789", NameCus = "Nguyen van A", Birth = "01/01/1999", Email = "nguyenvana@gmail.com", Total = 500000, DateUpdate = "30/11/2018" });
            listCustomer.Add(new Customers() { NumberPhone = "0123456789", NameCus = "Nguyen van A", Birth = "01/01/1999", Email = "nguyenvana@gmail.com", Total = 500000, DateUpdate = "30/11/2018" });
            listCustomer.Add(new Customers() { NumberPhone = "0123456789", NameCus = "Nguyen van A", Birth = "01/01/1999", Email = "nguyenvana@gmail.com", Total = 500000, DateUpdate = "30/11/2018" });
            lvCustomer.ItemsSource = listCustomer;
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

        public class Books
        {
            public string IDBook { get; set; }
            public string NameBook { get; set; }
            public long Price { get; set; }
            public int Amount { get; set; }
            public string Author { get; set; }
            public string Publish { get; set; }
            public string DateUpdate { get; set; }
        }

        public class Notification
        {
            public string Date { get; set; }
            public string Act { get; set; }
            public string Detail { get; set; }
        }
    }
}
