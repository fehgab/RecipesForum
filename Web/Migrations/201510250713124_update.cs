namespace WebPPublished.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 40),
                    FriendlyUrl = c.String(nullable: false, maxLength: 100),
                    PictureUrl = c.String(maxLength: 100),
                    Ingredients = c.String(nullable: false, maxLength: 100),
                    PrepareTime = c.String(nullable: false, maxLength: 10),
                    HowToPrepare = c.String(nullable: false, maxLength: 500),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DisplayName = c.String(nullable: false),
                    FriendlyUrl = c.String(nullable: false),

                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.UserProfile");
            DropTable("dbo.Categories");
        }
    }
}
