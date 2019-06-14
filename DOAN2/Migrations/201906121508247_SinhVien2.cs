namespace DOAN2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SinhVien2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SinhViens", "LopId", c => c.Int(nullable: false));
            CreateIndex("dbo.SinhViens", "LopId");
            AddForeignKey("dbo.SinhViens", "LopId", "dbo.Lops", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SinhViens", "LopId", "dbo.Lops");
            DropIndex("dbo.SinhViens", new[] { "LopId" });
            DropColumn("dbo.SinhViens", "LopId");
        }
    }
}
