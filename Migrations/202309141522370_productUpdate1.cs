namespace MarketVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productUpdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageFileName", c => c.String(nullable: false));
            DropColumn("dbo.Products", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Image", c => c.Binary(nullable: false));
            DropColumn("dbo.Products", "ImageFileName");
        }
    }
}
