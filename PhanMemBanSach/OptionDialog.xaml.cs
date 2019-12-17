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
    /// Interaction logic for OptionDialog.xaml
    /// </summary>
    public partial class OptionDialog : Window
    {
        public OptionDialog()
        {
            InitializeComponent();
        }

        private void Staff_Click(object sender, RoutedEventArgs e)
        {
            var screen = new paymentStaff();
            screen.ShowDialog();
        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            var screen = new manageStore();
            screen.ShowDialog();
        }
    }
}
