using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MarketVerse.Models
{
    public class Post
    {
        [Key] public int id { get; set; }
        [Required] public int ProductId { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Text { get; set; }

        public static List<Post> ShowAllContents()
        {
            return DatabaseModel.db.Contents.ToList();
        }
        public static Post FindContentByProductId(int ProductId)
        {
            return DatabaseModel.db.Contents.FirstOrDefault(x => x.ProductId == ProductId);
        }

        public static bool Create(Post content)
        {
            try
            {
                DatabaseModel.db.Contents.Add(content);
                DatabaseModel.db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}