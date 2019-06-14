namespace DOAN2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Khoas", "Date", c => c.String(nullable: false));
            AlterColumn("dbo.GiaoViens", "Date", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GiaoViens", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Khoas", "Date", c => c.DateTime(nullable: false));
        }
    }
}
