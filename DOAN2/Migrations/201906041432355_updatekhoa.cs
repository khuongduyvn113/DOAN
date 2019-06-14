namespace DOAN2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatekhoa : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Khoas", "IdKhoa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Khoas", "IdKhoa", c => c.String(nullable: false));
        }
    }
}
