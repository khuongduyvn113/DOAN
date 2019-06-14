using DOAN2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN2.ViewModel
{
    public class LopViewModel
    {
        public int IdKhoa { get; set; }
        public IEnumerable<Khoa> DSKhoa { get; set; }
        public int IdChuyenNganh { get; set; }
        public IEnumerable<ChuyenNganh> DSChuyenNganh { get; set; }
        public int IdHDT { get; set; }
        public IEnumerable<HeDaoTao> DSHeDaoTao { get; set; }
        public int IdNienKhoa { get; set; }
        public IEnumerable<NienKhoa> DSNienKhoa { get; set; }
    }
}