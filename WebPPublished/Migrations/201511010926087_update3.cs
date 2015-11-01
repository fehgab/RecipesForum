namespace WebPPublished.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "PictureUrl", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "PictureUrl", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
