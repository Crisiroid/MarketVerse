namespace MarketVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "SubCategoryID", newName: "SubCategory_id1");
            RenameIndex(table: "dbo.Products", name: "IX_SubCategoryID", newName: "IX_SubCategory_id1");
            AddColumn("dbo.Products", "SubCategory_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "SubCategory_id");
            RenameIndex(table: "dbo.Products", name: "IX_SubCategory_id1", newName: "IX_SubCategoryID");
            RenameColumn(table: "dbo.Products", name: "SubCategory_id1", newName: "SubCategoryID");
        }
    }
}
