using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MarketVerse.Models
{
    public class SubCategory
    {
        [Key] public int id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int ItemCount { get; set; }
        [Required] public int Code { get; set; }
        public ICollection<Product> Products { get; set; }

        public static List<SubCategory> ShowAllSubCategories()
        {
            return DatabaseModel.db.SubCategories.ToList();
        }
        
        public static SubCategory FindSubCategory(int id)
        {
            return DatabaseModel.db.SubCategories.Find(id);
        }

        public static bool Create(SubCategory category)
        {
            try
            {
                DatabaseModel.db.SubCategories.Add(category);
                DatabaseModel.db.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
            
        }

        public static bool Edit(SubCategory category)
        {
            try
            {
                DatabaseModel.db.Entry(category).State = EntityState.Modified;
                DatabaseModel.db.SaveChanges();
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static bool Delete(int id)
        {
            try
            {
                SubCategory subCategory = SubCategory.FindSubCategory(id);
                DatabaseModel.db.SubCategories.Remove(subCategory);
                DatabaseModel.db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}