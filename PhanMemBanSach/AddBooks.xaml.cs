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
    /// Interaction logic for AddBooks.xaml
    /// </summary>
    public partial class AddBooks : Window
    {
        public AddBooks()
        {
            InitializeComponent();

            var listBooks = new List<Books>();
            listBooks.Add(new Books() { IDBook = "MSS0001XX", NameBook = "Sự cứu rỗi của thánh nữ (2019)", Amount = 20, Price = 90000 });
            listBooks.Add(new Books() { IDBook = "MSS0001XX", NameBook = "Sự cứu rỗi của thánh nữ (2019)", Amount = 20, Price = 90000 });
            listBooks.Add(new Books() { IDBook = "MSS0001XX", NameBook = "Sự cứu rỗi của thánh nữ (2019)", Amount = 20, Price = 90000 });
            listBooks.Add(new Books() { IDBook = "MSS0001XX", NameBook = "Sự cứu rỗi của thánh nữ (2019)", Amount = 20, Price = 90000 });
            listBooks.Add(new Books() { IDBook = "MSS0001XX", NameBook = "Sự cứu rỗi của thánh nữ (2019)", Amount = 20, Price = 90000 });
            lvAddedBooks.ItemsSource = listBooks;
        }

        public class Books
        {
            public string IDBook { get; set; }
            public string NameBook { get; set; }
            public int Amount { get; set; }
            public long Price { get; set; }
        }
    }
}
