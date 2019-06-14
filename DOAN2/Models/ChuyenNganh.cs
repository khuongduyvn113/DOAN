using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN2.Models
{
    public class ChuyenNganh
    {
        [Key]
        [Display(Name = "Mã Chuyên Ngành")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Chuyên Ngành")]
        public string NameCN { get; set; }
        
        [Required]
        [Display(Name = "Tên Khoa")]
        public int KhoaId { get; set; }
        public Khoa Khoa { get; set; }
        public IEnumerable<ChuyenNganh> GetChuyenNganh(ApplicationDbContext dbContext)
        {
            return dbContext.ChuyenNganhs.ToList();
        }
    }
}