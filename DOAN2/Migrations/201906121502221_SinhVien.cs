namespace DOAN2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SinhVien : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SV = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        SDT = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Village = c.String(nullable: false),
                        Date = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SinhViens");
        }
    }
}
