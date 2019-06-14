using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOAN2.Models
{
    public class GiaoVien
    {
        [Key]
        [Display(Name = "Mã giáo viên")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên Giáo Viên")]
        public string Name { get; set; }
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
        public string Date  { get; set; }
        public ChuyenNganh ChuyenNganh { get; set; }
        [Required]
        [Display(Name = " Tên Chuyên Ngành")]
        public int ChuyenNganhId { get; set; }


    }
}