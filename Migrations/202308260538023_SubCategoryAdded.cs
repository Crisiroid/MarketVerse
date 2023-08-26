namespace MarketVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubCategoryAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ItemCount = c.Int(nullable: false),
                        Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Products", "SubCategory_id", c => c.Int());
            CreateIndex("dbo.Products", "SubCategory_id");
            AddForeignKey("dbo.Products", "SubCategory_id", "dbo.SubCategories", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SubCategory_id", "dbo.SubCategories");
            DropIndex("dbo.Products", new[] { "SubCategory_id" });
            DropColumn("dbo.Products", "SubCategory_id");
            DropTable("dbo.SubCategories");
        }
    }
}
