namespace WebPPublished.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Recipes", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "RecipesId", "dbo.Recipes");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "CategoryID" });
            DropIndex("dbo.Recipes", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "RecipesId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropColumn("dbo.AspNetUsers", "RealName");
            DropTable("dbo.Categories");
            DropTable("dbo.Recipes");
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        RecipesId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 40),
                        FriendlyUrl = c.String(maxLength: 100),
                        PictureUrl = c.String(maxLength: 100),
                        Ingredients = c.String(nullable: false, maxLength: 100),
                        PrepareTime = c.String(nullable: false, maxLength: 10),
                        HowToPrepare = c.String(nullable: false, maxLength: 500),
                        CategoryID = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        FriendlyUrl = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.AspNetUsers", "RealName", c => c.String());
            CreateIndex("dbo.Comments", "UserId");
            CreateIndex("dbo.Comments", "RecipesId");
            CreateIndex("dbo.Recipes", "UserID");
            CreateIndex("dbo.Recipes", "CategoryID");
            AddForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Comments", "RecipesId", "dbo.Recipes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Recipes", "UserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Recipes", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
        }
    }
}
