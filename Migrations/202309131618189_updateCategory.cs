namespace MarketVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "SubcategoryCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "SubcategoryCount", c => c.String(nullable: false));
        }
    }
}
