namespace DOAN2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChuyenNganh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChuyenNganhs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameCN = c.String(nullable: false),
                        IdKhoa = c.Int(nullable: false),
                        Khoa_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Khoas", t => t.Khoa_Id, cascadeDelete: true)
                .Index(t => t.Khoa_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChuyenNganhs", "Khoa_Id", "dbo.Khoas");
            DropIndex("dbo.ChuyenNganhs", new[] { "Khoa_Id" });
            DropTable("dbo.ChuyenNganhs");
        }
    }
}
