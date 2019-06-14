using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOAN2.Models
{
    public class Khoa
    {
        [Key]
        [Display(Name = "Mã Khoa")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên Khoa")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Ngày Thành Lập")]
        public string Date { get; set; }
        [Required]
        [Display(Name = "Mô Tả")]
        public string Des { get; set; }
        public IEnumerable<Khoa> GetKhoa(ApplicationDbContext dbContext)
        {
            return dbContext.Khoas.ToList();
        }

    }
}