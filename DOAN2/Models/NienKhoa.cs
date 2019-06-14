using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOAN2.Models
{
    public class NienKhoa
    {
        [Key]
        [Display(Name = "Mã Niên Khóa")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Niên Khóa")]
        public string Name { get; set; }
        public IEnumerable<NienKhoa> GetNienKhoa(ApplicationDbContext dbContext)
        {
            return dbContext.NienKhoas.ToList();
        }
    }
}