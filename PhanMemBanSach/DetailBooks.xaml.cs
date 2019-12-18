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
        public DetailBooks()
        {
            InitializeComponent();
        }

        private void DelBookButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new DeleteBooks();
            screen.ShowDialog();
        }

        private void EditBookButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new EditBooks();
            screen.ShowDialog();
        }
    }
}
