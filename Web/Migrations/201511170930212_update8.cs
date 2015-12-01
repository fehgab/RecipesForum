namespace WebPPublished.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "Title", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Recipes", "Ingredients", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Recipes", "PrepareTime", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Recipes", "PrepareTime", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Recipes", "Ingredients", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Recipes", "Title", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
