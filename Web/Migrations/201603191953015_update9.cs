namespace WebPPublished.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RealName", c => c.String(maxLength: 50));
            CreateIndex("dbo.AspNetUsers", "RealName", true);
        }

        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", "RealName");
            DropColumn("dbo.AspNetUsers", "RealName");
        }
    }
}
