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
    /// Interaction logic for paymentStaff.xaml
    /// </summary>
    public partial class paymentStaff : Window
    {
        public paymentStaff()
        {
            InitializeComponent();
            var list = new System.Collections.Generic.List<Books>();
            list.Add(new Books() { InfoBook = "MSS0001XX - Sự cứu rỗi của thánh nữ (2019) - Higashino Keigo", Amount = 2, Price = 10000, Del = false });
            list.Add(new Books() { InfoBook = "MSS0001XX - Sự cứu rỗi của thánh nữ (2019) - Higashino Keigo", Amount = 2, Price = 10000, Del = false });
            list.Add(new Books() { InfoBook = "MSS0001XX - Sự cứu rỗi của thánh nữ (2019) - Higashino Keigo", Amount = 2, Price = 10000, Del = false });
            list.Add(new Books() { InfoBook = "MSS0001XX - Sự cứu rỗi của thánh nữ (2019) - Higashino Keigo", Amount = 2, Price = 10000, Del = false });
            lvBooks.ItemsSource = list;
        }

        public class Books
        {
            public string InfoBook { get; set; }
            public int Amount { get; set; }
            public long Price { get; set; }
            public bool Del { get; set; }
        }
    }
}
