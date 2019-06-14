using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOAN2.Models
{
    public class DoAn
    {
        [Key]
        [Display(Name = "Mã ")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }
        [Required]
        [Display(Name = "Tên Đồ Án")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Mã Đồ Án")]
        public string MDA { get; set; }
        [Required]
        [Display(Name = "Người Thực Hiện")]
        public string Human { get; set; }
        [Required]
        [Display(Name = "Điểm")]
        public string Score { get; set; }
        [Required]
        [Display(Name = "Giảng Viên Hướng Dẫn")]
        public string Humans { get; set; }
        [Required]
        [Display(Name = "Sinh Viên")]
        public int SinhVienId { get; set; }
        public SinhVien SinhVien { get; set; }

    }
}