namespace MarketVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Views", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Views");
        }
    }
}
