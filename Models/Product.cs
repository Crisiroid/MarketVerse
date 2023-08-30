using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MarketVerse.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public decimal Price { get; set; }
        [Required] public decimal Quantity { get; set; }

        [Required] public int SubCategoryid { get; set; }
        [Required] public int Purchuses { get; set; }
        [Required] public int Views { get; set; } = 0;

        public static List<Product> ShowAllProducts()
        {
            return DatabaseModel.db.Products.ToList();
        }

        public static Product FindProduct(int id)
        {
            return DatabaseModel.db.Products.FirstOrDefault(x => x.id == id);
        }

        public static bool Create(Product product)
        {
            try
            {
                product.Purchuses = 0;
                product.Views = 0;
                DatabaseModel.db.Products.Add(product);
                DatabaseModel.db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public static bool Edit(Product product)
        {
            try
            {
                DatabaseModel.db.Entry(product).State = EntityState.Modified;
                DatabaseModel.db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public static bool Delete(int id)
        {
            try
            {
                Product product = FindProduct(id);
                DatabaseModel.db.Products.Remove(product);
                DatabaseModel.db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}