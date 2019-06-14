using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOAN2.Models
{
    public class Lop
    {
        [Key]
        [Display(Name = "Mã Lớp")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên Lớp")]
        public string NameCN { get; set; }       
        public ChuyenNganh ChuyenNganh { get; set; }
        [Required]
        [Display(Name = "Chuyên Ngành")]
        public int ChuyenNganhId { get; set; }
        public HeDaoTao HeDaoTao { get; set; }
        [Required]
        [Display(Name = "Hệ Đào Tạo")]
        public int HeDaoTaoId { get; set; }
        public NienKhoa NienKhoa { get; set; }
        [Required]
        [Display(Name = "Niên Khóa")]
        public int NienKhoaId { get; set; }
        [Required]
        [Display(Name = "Sỉ Số")]
        public string SS { get; set; }
        public IEnumerable<Lop> GetLop(ApplicationDbContext dbContext)
        {
            return dbContext.Lops.ToList();
        }
    }
}