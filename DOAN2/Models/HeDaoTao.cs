using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOAN2.Models
{
    public class HeDaoTao
    {
        [Key]
        [Display(Name = "Mã HDT")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên Hệ Đào Tạo")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Mã Hệ Đào Tạo")]
        public string HDT { get; set; }
        public IEnumerable<HeDaoTao> GetHeDaoTao(ApplicationDbContext dbContext)
        {
            return dbContext.HeDaoTaos.ToList();
        }
    }
}