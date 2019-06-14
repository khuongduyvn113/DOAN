namespace DOAN2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChuyenNganh2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChuyenNganhs", "Khoa_Id", "dbo.Khoas");
            DropIndex("dbo.ChuyenNganhs", new[] { "Khoa_Id" });
            AlterColumn("dbo.ChuyenNganhs", "Khoa_Id", c => c.Int());
            CreateIndex("dbo.ChuyenNganhs", "Khoa_Id");
            AddForeignKey("dbo.ChuyenNganhs", "Khoa_Id", "dbo.Khoas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChuyenNganhs", "Khoa_Id", "dbo.Khoas");
            DropIndex("dbo.ChuyenNganhs", new[] { "Khoa_Id" });
            AlterColumn("dbo.ChuyenNganhs", "Khoa_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ChuyenNganhs", "Khoa_Id");
            AddForeignKey("dbo.ChuyenNganhs", "Khoa_Id", "dbo.Khoas", "Id", cascadeDelete: true);
        }
    }
}