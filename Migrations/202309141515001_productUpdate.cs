namespace MarketVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Image", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Image");
        }
    }
}
