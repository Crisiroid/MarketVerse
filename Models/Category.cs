using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MarketVerse.Models
{
    public class Category
    {
        [Key] public int id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string SubcategoryCount { get; set; }


        public static List<Category> ShowAllCategories()
        {
            return DatabaseModel.db.Categories.ToList();
        }

        public static Category FindCategory(int id)
        {
            return DatabaseModel.db.Categories.Find(id);
        }

        public static bool Create(Category category)
        {
            try
            {
                DatabaseModel.db.Categories.Add(category);
                DatabaseModel.db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static bool Edit(Category category)
        {
            try
            {
                DatabaseModel.db.Entry(category).State = EntityState.Modified;
                DatabaseModel.db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool Delete(int id)
        {
            try
            {
                Category category = Category.FindCategory(id);
                DatabaseModel.db.Categories.Remove(category);
                DatabaseModel.db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}