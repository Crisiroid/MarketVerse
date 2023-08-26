﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MarketVerse.Data
{
    public class MarketVerseContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MarketVerseContext() : base("name=MarketVerseContext")
        {
        }

        public System.Data.Entity.DbSet<MarketVerse.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<MarketVerse.Models.User> Users { get; set; }
        public System.Data.Entity.DbSet<MarketVerse.Models.Product> Products { get; set; }
        public System.Data.Entity.DbSet<MarketVerse.Models.SubCategory> SubCategories { get; set; }
    }

}
