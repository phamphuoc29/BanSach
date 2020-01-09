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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhanMemBanSach
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string staffAccount = "staff";
        string pwStaffAccount = "staff";

        string adminAccount = "admin";
        string pwAdminAccount = "admin";
        int check = -1;
        private int checkAccount(string acc, string pass)
        {
            if (acc == staffAccount && pass == pwStaffAccount)
            {
                return 1;
            }
            if (acc == adminAccount && pass == pwAdminAccount)
            {
                return 2;
            }
            return -1;
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //var account = AccountTextBox.Text;
            //var password = PasswordBox.Password;
            //check = checkAccount(account, password);
            //if (check != -1)
            //{
            //    MainCanvas.Visibility = Visibility.Hidden;
            //    OptionCavas.Visibility = Visibility.Visible;
            //    if(check == 2)
            //    {
            //        Manager.IsEnabled = true; 
            //    }
            //    else Manager.IsEnabled = false;
            //}
            //else
            //{
            //    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác");
            //}
            MainCanvas.Visibility = Visibility.Hidden;
            OptionCavas.Visibility = Visibility.Visible;

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
