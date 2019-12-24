using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        #region Declare variable
        private ObservableCollection<Sach> _listBook;
        public ObservableCollection<Sach> ListBook
        {
            get => _listBook;
            set { _listBook = value; OnPropertyChanged(); }
        }
        #endregion

        public StoreManagementVM()
        {
            ListBook = new ObservableCollection<Sach>();
            var @books = DataProvider.Ins.DB.Saches;
            foreach (var book in @books)
            {
                ListBook.Add(book);
            }
        }
    }
}

