namespace DOAN2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelop : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lops", "Khoa_Id", "dbo.Khoas");
            DropForeignKey("dbo.Lops", "ChuyenNganh_Id", "dbo.ChuyenNganhs");
            DropForeignKey("dbo.Lops", "HeDaoTao_Id", "dbo.HeDaoTaos");
            DropForeignKey("dbo.Lops", "NienKhoa_Id", "dbo.NienKhoas");
            DropIndex("dbo.Lops", new[] { "ChuyenNganh_Id" });
            DropIndex("dbo.Lops", new[] { "HeDaoTao_Id" });
            DropIndex("dbo.Lops", new[] { "Khoa_Id" });
            DropIndex("dbo.Lops", new[] { "NienKhoa_Id" });
            RenameColumn(table: "dbo.Lops", name: "ChuyenNganh_Id", newName: "ChuyenNganhId");
            RenameColumn(table: "dbo.Lops", name: "HeDaoTao_Id", newName: "HeDaoTaoId");
            RenameColumn(table: "dbo.Lops", name: "NienKhoa_Id", newName: "NienKhoaId");
            AlterColumn("dbo.Lops", "ChuyenNganhId", c => c.Int(nullable: false));
            AlterColumn("dbo.Lops", "HeDaoTaoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Lops", "NienKhoaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Lops", "ChuyenNganhId");
            CreateIndex("dbo.Lops", "HeDaoTaoId");
            CreateIndex("dbo.Lops", "NienKhoaId");
            AddForeignKey("dbo.Lops", "ChuyenNganhId", "dbo.ChuyenNganhs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lops", "HeDaoTaoId", "dbo.HeDaoTaos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lops", "NienKhoaId", "dbo.NienKhoas", "Id", cascadeDelete: true);
            DropColumn("dbo.Lops", "IdKhoa");
            DropColumn("dbo.Lops", "IdChuyenNganh");
            DropColumn("dbo.Lops", "IdHDT");
            DropColumn("dbo.Lops", "IdNienKhoa");
            DropColumn("dbo.Lops", "Khoa_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lops", "Khoa_Id", c => c.Int());
            AddColumn("dbo.Lops", "IdNienKhoa", c => c.Int(nullable: false));
            AddColumn("dbo.Lops", "IdHDT", c => c.Int(nullable: false));
            AddColumn("dbo.Lops", "IdChuyenNganh", c => c.Int(nullable: false));
            AddColumn("dbo.Lops", "IdKhoa", c => c.Int(nullable: false));
            DropForeignKey("dbo.Lops", "NienKhoaId", "dbo.NienKhoas");
            DropForeignKey("dbo.Lops", "HeDaoTaoId", "dbo.HeDaoTaos");
            DropForeignKey("dbo.Lops", "ChuyenNganhId", "dbo.ChuyenNganhs");
            DropIndex("dbo.Lops", new[] { "NienKhoaId" });
            DropIndex("dbo.Lops", new[] { "HeDaoTaoId" });
            DropIndex("dbo.Lops", new[] { "ChuyenNganhId" });
            AlterColumn("dbo.Lops", "NienKhoaId", c => c.Int());
            AlterColumn("dbo.Lops", "HeDaoTaoId", c => c.Int());
            AlterColumn("dbo.Lops", "ChuyenNganhId", c => c.Int());
            RenameColumn(table: "dbo.Lops", name: "NienKhoaId", newName: "NienKhoa_Id");
            RenameColumn(table: "dbo.Lops", name: "HeDaoTaoId", newName: "HeDaoTao_Id");
            RenameColumn(table: "dbo.Lops", name: "ChuyenNganhId", newName: "ChuyenNganh_Id");
            CreateIndex("dbo.Lops", "NienKhoa_Id");
            CreateIndex("dbo.Lops", "Khoa_Id");
            CreateIndex("dbo.Lops", "HeDaoTao_Id");
            CreateIndex("dbo.Lops", "ChuyenNganh_Id");
            AddForeignKey("dbo.Lops", "NienKhoa_Id", "dbo.NienKhoas", "Id");
            AddForeignKey("dbo.Lops", "HeDaoTao_Id", "dbo.HeDaoTaos", "Id");
            AddForeignKey("dbo.Lops", "ChuyenNganh_Id", "dbo.ChuyenNganhs", "Id");
            AddForeignKey("dbo.Lops", "Khoa_Id", "dbo.Khoas", "Id");
        }
    }
}
