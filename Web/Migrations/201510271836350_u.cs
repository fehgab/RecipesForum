namespace WebPPublished.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class u : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AspNetUsers", "UserName", true);
        }

        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", "UserName");
        }
    }
}
