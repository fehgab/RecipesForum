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
            AddColumn("dbo.Recipes", "CategoryID", c => c.Int());
            CreateIndex("dbo.Recipes", "CategoryID");
            AddForeignKey("dbo.Recipes", "CategoryID", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "UserID" });
            DropColumn("dbo.Recipes", "UserID");
            DropForeignKey("dbo.Recipes", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Recipes", new[] { "CategoryID" });
            DropColumn("dbo.Recipes", "CategoryID");
        }
    }
}
