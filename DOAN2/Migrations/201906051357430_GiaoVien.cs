namespace DOAN2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GiaoVien : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GiaoViens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SDT = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Village = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ChuyenNganhId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChuyenNganhs", t => t.ChuyenNganhId, cascadeDelete: true)
                .Index(t => t.ChuyenNganhId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GiaoViens", "ChuyenNganhId", "dbo.ChuyenNganhs");
            DropIndex("dbo.GiaoViens", new[] { "ChuyenNganhId" });
            DropTable("dbo.GiaoViens");
        }
    }
}
