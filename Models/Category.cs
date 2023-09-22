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
        [Required] public int SubcategoryCount { get; set; }


        //Finding Methods
        public static List<Category> ShowAllCategories()
        {
            return DatabaseModel.db.Categories.ToList();
        }

        public static Category FindCategory(int id)
        {
            return DatabaseModel.db.Categories.Find(id);
        }

        //Editing Methods
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

        public static string Edit(Category category)
        {
            try
            {
                Category c = FindCategory(category.id);
                c.Name = category.Name;
                c.SubcategoryCount = category.SubcategoryCount;
                DatabaseModel.db.SaveChanges();
                return "200";

            }
            catch (Exception ex)
            {
                return ex.Message;
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

        public static void IncreaseCount(int id)
        {
            try{
                if(id != null)
                {
                    Category category = Category.FindCategory(id);
                    category.SubcategoryCount += 1;
                    DatabaseModel.db.SaveChanges();
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}