using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOAN2.Models
{
    public class SinhVien
    {
        [Key]
        [Display(Name = "Mã ")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên Sinh Viên")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Mã Sinh Viên")]
        public string SV { get; set; }
        [Required]
        [Display(Name = "Số Điện Thoại")]
        public string SDT { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Quê Quán")]
        public string Village { get; set; }
        [Required]
        [Display(Name = "Ngày Sinh")]
        public string Date { get; set; }
        [Required]
        [Display(Name = "Lớp")]
        public int LopId { get; set; }
        public Lop Lop { get; set; }
        public IEnumerable<SinhVien> GetSinhVien(ApplicationDbContext dbContext)
        {
            return dbContext.SinhViens.ToList();
        }











    }
}