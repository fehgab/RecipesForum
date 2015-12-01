namespace WebPPublished.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "PictureUrl", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Recipes", "Ingredients", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Recipes", "PrepareTime", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Recipes", "HowToPrepare", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "HowToPrepare", c => c.String(maxLength: 500));
            AlterColumn("dbo.Recipes", "PrepareTime", c => c.String(maxLength: 50));
            AlterColumn("dbo.Recipes", "Ingredients", c => c.String(maxLength: 500));
            AlterColumn("dbo.Recipes", "PictureUrl", c => c.String(maxLength: 100));
        }
    }
}
