namespace MarketVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Addr", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Addr");
        }
    }
}
