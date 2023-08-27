using MarketVerse.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketVerse.Models
{
    public class SubcategoryRepository
    {
        public static MarketVerseContext db = new MarketVerseContext();

        public static List<SubCategory> ShowAllSubCategories()
        {
            return db.SubCategories.ToList();
        }


        public static List<SelectListItem> ShowAllSubCategoriesSelectListItem()
        {
            var items = ShowAllSubCategories();
            List<SelectListItem> item = items.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.ToString(),
                    Value = a.ToString(),
                    Selected = false
                };
            });
            return item;
        }
    }
}