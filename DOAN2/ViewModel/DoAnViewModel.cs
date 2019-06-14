using DOAN2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN2.ViewModel
{
    public class DoAnViewModel
    {
        public int KhoaId { get; set; }
        public IEnumerable<Khoa> DSKhoa { get; set; }
        public int ChuyenNganhId { get; set; }
        public IEnumerable<ChuyenNganh> DSChuyenNganh { get; set; }
        public int LopId { get; set; }
        public IEnumerable<Lop> DSLop { get; set; }
        public int GiaoVienId { get; set; }
        public IEnumerable<GiaoVien> DSGiaoVien { get; set; }
        public int SinhVienId { get; set; }
        public IEnumerable<SinhVien> DSSinhVien { get; set; }
    }
}