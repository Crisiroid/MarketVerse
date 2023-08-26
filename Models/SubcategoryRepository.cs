using MarketVerse.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketVerse.Models
{
    public class SubcategoryRepository
    {
        public static MarketVerseContext db = new MarketVerseContext();

        public static List<SubCategory> ShowAllSubCategories()
        {
            return db.SubCategories.ToList();
        }

    }
}