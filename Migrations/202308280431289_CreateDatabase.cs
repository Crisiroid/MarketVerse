namespace MarketVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "SubCategoryID" });
            AddColumn("dbo.Products", "Purchuses", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "SubCategoryid");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "SubCategoryid" });
            DropColumn("dbo.Products", "Purchuses");
            CreateIndex("dbo.Products", "SubCategoryID");
        }
    }
}
