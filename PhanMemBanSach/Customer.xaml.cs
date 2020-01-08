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
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            var phone = PhoneTextBox.Text;
            var name = NameTextBox.Text;
            var dob = DoBTextBox.Text;
            var email = EmailTextBox.Text;
            if (phone == "" || name == "" || dob == "" || email == "")
            {
                MessageBox.Show("Chưa điền đủ thông tin khách hàng");
            }
            else
            {
                var date = new DateTime();
                date = Convert.ToDateTime(dob);
                //them khach hang vao db
                var db = new QuanLyCuaHangBanSachEntities();
                db.KhachHangs.Add(new KhachHang() { TenKH = name, Email = email, NgaySinh = date, SDT_KH = phone, TongGiaoDich = 0 });
                db.SaveChanges();
                this.DialogResult = true;
            }
        }
    }

}
