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
    /// Interaction logic for DeleteBooks.xaml
    /// </summary>
    public partial class DeleteBooks : Window
    {
        #region declare variable
        private string MaSach;

        #endregion

        public DeleteBooks(string maSach)
        {
            InitializeComponent();
            this.DataContext = this;

            MaSach = maSach;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int result = DataProvider.Ins.DB.DeleteBook(MaSach);
                DataProvider.Ins.DB.SaveChanges();
                if (result == 1)
                    MessageBox.Show("Xóa sách thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL error:" + ex.Message.ToString());
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
