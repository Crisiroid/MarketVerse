namespace MarketVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Contents", newName: "Posts");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Posts", newName: "Contents");
        }
    }
}
