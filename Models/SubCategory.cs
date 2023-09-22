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

        public static string Edit(SubCategory category)
        {
            try
            {
                SubCategory s = FindSubCategory(category.id);
                s.Name = category.Name;
                s.ItemCount = category.ItemCount;
                s.Code = category.Code; 
                DatabaseModel.db.SaveChanges();
                return "200";

            }
            catch(Exception ex)
            {
                return ex.Message;
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

        public static void IncreaseProductNumbers(int id)
        {
            SubCategory sb = DatabaseModel.db.SubCategories.FirstOrDefault(x => x.id == id);
            sb.ItemCount++;
            DatabaseModel.db.SaveChanges();
        }
    }
}