﻿namespace MarketVerse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SAMs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SaleNum = c.Int(nullable: false),
                        TotalProfit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SAMs");
        }
    }
}
