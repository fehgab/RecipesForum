namespace WebPPublished.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class u1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "RealName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.UserProfile", "UserName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.UserProfile", "DisplayName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfile", "DisplayName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.UserProfile", "UserName");
            DropColumn("dbo.UserProfile", "RealName");
        }
    }
}
