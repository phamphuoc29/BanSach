﻿using System;
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

        #region Declare variable
        private BindingList<Sach> listBook;
        public BindingList<Sach> ListBook { get => listBook; set { listBook = value;OnPropertyChanged(); } }
        private Sach _selectedBook;
        public Sach SelectedBook { get => _selectedBook; set { _selectedBook = value; OnPropertyChanged(); } }
        #endregion

        public StoreManagementVM()
        {
            ListBook = new BindingList<Sach>(DataProvider.Ins.DB.Saches.ToList());
        }

        public void LoadBook()
        {
            ListBook.Clear();
        }
    }
}

