namespace WebPPublished.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "CreatedDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
