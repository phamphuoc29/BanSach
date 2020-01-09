using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhanMemBanSach.ViewModels
{
    public class StoreManagementVM: INotifyPropertyChanged
    {
        #region Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Declare variable for book
        private ObservableCollection<Sach> listBook;
        public ObservableCollection<Sach> ListBook { get => listBook; set { listBook = value;OnPropertyChanged(); } }
        private Sach _selectedBook;
        public Sach SelectedBook { get => _selectedBook; set { _selectedBook = value; OnPropertyChanged(); } }
        private string _searchString;
        public string SearchString { get => _searchString; set { _searchString = value; OnPropertyChanged(); } }
        #endregion

        #region Declare variable for QlyChiTieu
        private int thang;
        public int Thang { get => thang; set { thang = value;OnPropertyChanged(); } }
        private int nam;
        public int Nam { get => nam; set { nam = value; OnPropertyChanged(); } }
        private decimal tienDien;
        public decimal TienDien { get => tienDien; set { tienDien = value; OnPropertyChanged(); } }
        private decimal tienNuoc;
        public decimal TienNuoc { get => tienNuoc; set { tienNuoc = value; OnPropertyChanged(); } }
        private decimal tienLuongNV;
        public decimal TienLuongNV { get => tienLuongNV; set { tienLuongNV = value; OnPropertyChanged(); } }
        private decimal tienInternet;
        public decimal TienInternet { get => tienInternet; set { tienInternet = value; OnPropertyChanged(); } }
        private decimal tienThueNha;
        public decimal TienThueNha { get => tienThueNha; set { tienThueNha = value; OnPropertyChanged(); } }
        private decimal khac;
        public decimal Khac { get => khac; set { khac = value; OnPropertyChanged(); } }

        #endregion

        public StoreManagementVM()
        {
            //ListBook = new ObservableCollection<Sach>(DataProvider.Ins.DB.Saches.ToList());
            ListBook = new ObservableCollection<Sach>();
            LoadBook();
        }

        public void LoadBook()
        {
            ListBook.Clear();
            var books = DataProvider.Ins.DB.ViewBooks();
            foreach (var @book in books)
            {
                ListBook.Add(new Sach { MaSach = book.MaSach, TenSach = book.TenSach, TacGia = book.TacGia, NhaXuatBan = book.NhaXuatBan, SoLuong = book.SoLuong, GiaTienBan = book.GiaTienBan });
            }
        }
    }
}

