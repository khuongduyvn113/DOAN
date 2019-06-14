namespace DOAN2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecn4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChuyenNganhs", "Khoa_Id", "dbo.Khoas");
            DropIndex("dbo.ChuyenNganhs", new[] { "Khoa_Id" });
            RenameColumn(table: "dbo.ChuyenNganhs", name: "Khoa_Id", newName: "KhoaId");
            AlterColumn("dbo.ChuyenNganhs", "KhoaId", c => c.Int(nullable: false));
            CreateIndex("dbo.ChuyenNganhs", "KhoaId");
            AddForeignKey("dbo.ChuyenNganhs", "KhoaId", "dbo.Khoas", "Id", cascadeDelete: true);
            DropColumn("dbo.ChuyenNganhs", "IdKhoa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChuyenNganhs", "IdKhoa", c => c.Int(nullable: false));
            DropForeignKey("dbo.ChuyenNganhs", "KhoaId", "dbo.Khoas");
            DropIndex("dbo.ChuyenNganhs", new[] { "KhoaId" });
            AlterColumn("dbo.ChuyenNganhs", "KhoaId", c => c.Int());
            RenameColumn(table: "dbo.ChuyenNganhs", name: "KhoaId", newName: "Khoa_Id");
            CreateIndex("dbo.ChuyenNganhs", "Khoa_Id");
            AddForeignKey("dbo.ChuyenNganhs", "Khoa_Id", "dbo.Khoas", "Id");
        }
    }
}
