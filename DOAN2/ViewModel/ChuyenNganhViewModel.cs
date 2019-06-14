using DOAN2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN2.ViewModel
{
    public class ChuyenNganhViewModel
    {
        public string Name { get; set; }
        public string NameCN { get; set; }
        public int IdKhoa { get; set; }
        public IEnumerable<Khoa> DSKhoa { get; set; }
    }
}