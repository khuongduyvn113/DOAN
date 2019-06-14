namespace DOAN2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameCN = c.String(nullable: false),
                        IdKhoa = c.Int(nullable: false),
                        IdChuyenNganh = c.Int(nullable: false),
                        IdHDT = c.Int(nullable: false),
                        IdNienKhoa = c.Int(nullable: false),
                        SS = c.String(nullable: false),
                        ChuyenNganh_Id = c.Int(),
                        HeDaoTao_Id = c.Int(),
                        Khoa_Id = c.Int(),
                        NienKhoa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChuyenNganhs", t => t.ChuyenNganh_Id)
                .ForeignKey("dbo.HeDaoTaos", t => t.HeDaoTao_Id)
                .ForeignKey("dbo.Khoas", t => t.Khoa_Id)
                .ForeignKey("dbo.NienKhoas", t => t.NienKhoa_Id)
                .Index(t => t.ChuyenNganh_Id)
                .Index(t => t.HeDaoTao_Id)
                .Index(t => t.Khoa_Id)
                .Index(t => t.NienKhoa_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lops", "NienKhoa_Id", "dbo.NienKhoas");
            DropForeignKey("dbo.Lops", "Khoa_Id", "dbo.Khoas");
            DropForeignKey("dbo.Lops", "HeDaoTao_Id", "dbo.HeDaoTaos");
            DropForeignKey("dbo.Lops", "ChuyenNganh_Id", "dbo.ChuyenNganhs");
            DropIndex("dbo.Lops", new[] { "NienKhoa_Id" });
            DropIndex("dbo.Lops", new[] { "Khoa_Id" });
            DropIndex("dbo.Lops", new[] { "HeDaoTao_Id" });
            DropIndex("dbo.Lops", new[] { "ChuyenNganh_Id" });
            DropTable("dbo.Lops");
        }
    }
}
