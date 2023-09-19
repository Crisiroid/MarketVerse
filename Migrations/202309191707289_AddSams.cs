namespace MarketVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSams : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SAMs", "Year", c => c.String(nullable: false));
            AddColumn("dbo.SAMs", "Month", c => c.String(nullable: false));
            AddColumn("dbo.SAMs", "Day", c => c.String(nullable: false));
            AddColumn("dbo.SAMs", "TotalSale", c => c.Int(nullable: false));
            DropColumn("dbo.SAMs", "Name");
            DropColumn("dbo.SAMs", "SaleNum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SAMs", "SaleNum", c => c.Int(nullable: false));
            AddColumn("dbo.SAMs", "Name", c => c.String(nullable: false));
            DropColumn("dbo.SAMs", "TotalSale");
            DropColumn("dbo.SAMs", "Day");
            DropColumn("dbo.SAMs", "Month");
            DropColumn("dbo.SAMs", "Year");
        }
    }
}
