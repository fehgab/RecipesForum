namespace WebPPublished.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Recipes", "UserID");
            AddForeignKey("dbo.Recipes", "UserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "UserID" });
            DropColumn("dbo.Recipes", "UserID");
        }
    }
}
