namespace WebPPublished.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Category2_ID", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "Category2_ID" });
            DropColumn("dbo.Categories", "Category2_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Category2_ID", c => c.Int());
            CreateIndex("dbo.Categories", "Category2_ID");
            AddForeignKey("dbo.Categories", "Category2_ID", "dbo.Categories", "ID");
        }
    }
}
