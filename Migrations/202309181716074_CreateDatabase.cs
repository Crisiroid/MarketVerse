namespace MarketVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SubcategoryCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Username = c.String(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.String(nullable: false),
                        TrackingID = c.String(),
                        TotalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Order_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_id)
                .Index(t => t.Order_id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageFileName = c.String(nullable: false),
                        SubCategoryid = c.Int(nullable: false),
                        Purchuses = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryid, cascadeDelete: true)
                .Index(t => t.SubCategoryid);
            
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
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phonenumber = c.String(nullable: false),
                        Providence = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        IpAddress = c.String(nullable: false),
                        Browser = c.String(nullable: false),
                        Operatingsystem = c.String(nullable: false),
                        Orders = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SubCategoryid", "dbo.SubCategories");
            DropForeignKey("dbo.CartItems", "Order_id", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "SubCategoryid" });
            DropIndex("dbo.CartItems", new[] { "Order_id" });
            DropTable("dbo.Customers");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Products");
            DropTable("dbo.CartItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
        }
    }
}
