using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBanSach
{
    public class DataProvider
    {
        // Singleton Design
        /* Cách dùng: Khi muốn sử dụng database thì gõ như sau:
         * DataProvider.Ins.DB.<Table_Name>
         */
        public static DataProvider _ins;
        public static DataProvider Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new DataProvider();
                return _ins;
            }
            set { _ins = value; }
        }

        public QuanLyCuaHangBanSachEntities DB { get; set; }

        public DataProvider()
        {
            DB = new QuanLyCuaHangBanSachEntities();
        }
    }
}
