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
        [Key] public int id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public decimal Price { get; set; }
        [Required] public decimal Quantity { get; set; }
        [Required] public string ImageFileName { get; set; }


        [Required] public int SubCategoryid { get; set; }
        [Required] public int Purchuses { get; set; }
        [Required] public int Views { get; set; } = 0;

        //Finding Methods
        public static List<Product> ShowAllProducts()
        {
            return DatabaseModel.db.Products.ToList();
        }

        public static List<Product> ShowAllProductsSortByCatergory(int id)
        {
            return DatabaseModel.db.Products.Where(x => x.SubCategoryid == id).ToList();
        }
        public static Product FindProduct(int id)
        {
            return DatabaseModel.db.Products.FirstOrDefault(x => x.id == id);
        }
        public static List<Product> SortByViews()
        {
            return DatabaseModel.db.Products.OrderByDescending(p => p.Views).Take(10).ToList();
        }
        public static List<Product> SortByPurchase()
        {
            return DatabaseModel.db.Products.OrderByDescending(p => p.Purchuses).Take(10).ToList();
        }
        public static ProductWithContent ShowProduct(int id)
        {
            Product product = FindProduct(id);
            Post content = Post.FindContentByProductId(id);

            IncreaseProductView(id);

            return new ProductWithContent
            {
                product = product,
                content = content
            };

        }

        public static PFMP ShowProductForMainPage()
        {
            return new PFMP
            {
                Products = ShowAllProducts(), 
                PBP = SortByPurchase(),
                PBV = SortByViews()
            };
        }
        //Editing methods
        public static void IncreaseProductView(int id)
        {
            try
            {
                Product md = FindProduct(id);
                if (md != null)
                {
                    md.Views++;
                    DatabaseModel.db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static string Create(Product product)
        {
            try
            {
                product.Purchuses = 0;
                product.Views = 0;
                DatabaseModel.db.Products.Add(product);
                DatabaseModel.db.SaveChanges();
                return "true";
            }catch(Exception ex)
            {
                string errorMessage = ex.Message;

                if (ex.InnerException != null)
                {
                    errorMessage += " Inner Exception: " + ex.InnerException.Message;
                }

                // Log or print the error message for debugging
                Console.WriteLine(errorMessage);

                return errorMessage;
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