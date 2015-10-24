namespace WebPPublished.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Product", newName: "Recipes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Recipes", newName: "Product");
        }
    }
}
