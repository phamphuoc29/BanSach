using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class DetailBooks : Window,INotifyPropertyChanged
    {
        #region Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region declare variable
        private string _maSach;
        public string MaSach { get => _maSach; set { _maSach = value; OnPropertyChanged(); } }
        private string _tenSach;
        public string TenSach { get => _tenSach; set { _tenSach = value; OnPropertyChanged(); } }
        private string _tacGia;
        public string TacGia { get => _tacGia; set { _tacGia = value; OnPropertyChanged(); } }
        private string _nhaXuatBan;
        public string NhaXuatBan { get => _nhaXuatBan; set { _nhaXuatBan = value; OnPropertyChanged(); } }
        private int _soLuong;
        public int SoLuong { get => _soLuong; set { _soLuong = value; OnPropertyChanged(); } }
        private decimal _giaTienBan;
        public decimal GiaTienBan { get => _giaTienBan; set { _giaTienBan = value; OnPropertyChanged(); } }
        #endregion

        public DetailBooks(Sach s)
        {
            InitializeComponent();
            this.DataContext = this;

            MaSach = s.MaSach;
            TenSach = s.TenSach;
            TacGia = s.TacGia;
            NhaXuatBan = s.NhaXuatBan;
            SoLuong = s.SoLuong;
            GiaTienBan = s.GiaTienBan;
        }

        private void EditBookButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection sqlConnect = new SqlConnection(DataProvider.Ins.DB.Database.Connection.ConnectionString);
                sqlConnect.BeginTransaction();
                SqlCommand sql = new SqlCommand("sp_UpdateBook", sqlConnect);
                sql.CommandType = System.Data.CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@maSach", MaSach);
                sql.Parameters.AddWithValue("@tenSach", TenSach);
                sql.Parameters.AddWithValue("@tacGia", TacGia);
                sql.Parameters.AddWithValue("@NXB", NhaXuatBan);
                sql.Parameters.AddWithValue("@soLuong", SoLuong);
                sql.Parameters.AddWithValue("@giaTien", GiaTienBan);
                sqlConnect.Open();
                int result = sql.ExecuteNonQuery();
                DataProvider.Ins.DB.SaveChanges();
                sqlConnect.Close();
                if (result == 1)
                    MessageBox.Show("Sửa sách thành công! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL error:" + ex.Message.ToString());
            }
        }

        private void DelBookButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new DeleteBooks();
            screen.ShowDialog();
        }
    }
}
