using DOAN2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN2.ViewModel
{
    public class SinhVienViewModel
    {
        public int KhoaId { get; set; }
        public IEnumerable<Khoa> DSKhoa { get; set; }
        public int ChuyenNganhId { get; set; }
        public IEnumerable<ChuyenNganh> DSChuyenNganh { get; set; }
        public int HeDaoTaoId { get; set; }
        public IEnumerable<HeDaoTao> DSHeDaoTao { get; set; }
        public int NienKhoaId { get; set; }
        public IEnumerable<NienKhoa> DSNienKhoa { get; set; }



    }
}