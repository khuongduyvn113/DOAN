using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DOAN2.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<ChuyenNganh> ChuyenNganhs { get; set; }
        public DbSet<HeDaoTao> HeDaoTaos { get; set; }
        public DbSet<NienKhoa> NienKhoas { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<GiaoVien> GiaoViens { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<DoAn> DoAns { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}