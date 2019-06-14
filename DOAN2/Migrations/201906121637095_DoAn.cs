namespace DOAN2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoAn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoAns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        MDA = c.String(nullable: false),
                        Human = c.String(nullable: false),
                        Score = c.String(nullable: false),
                        Humans = c.String(nullable: false),
                        SinhVienId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SinhViens", t => t.SinhVienId, cascadeDelete: true)
                .Index(t => t.SinhVienId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoAns", "SinhVienId", "dbo.SinhViens");
            DropIndex("dbo.DoAns", new[] { "SinhVienId" });
            DropTable("dbo.DoAns");
        }
    }
}
