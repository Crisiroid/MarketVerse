using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketVerse.Models
{
    public class Content
    {
        [Key] public int id { get; set; }
        [Required] public int ProductId { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Text { get; set; }

        public static Content FindContentByProductId(int ProductId)
        {
            return DatabaseModel.db.Contents.FirstOrDefault(x => x.ProductId == ProductId);
        }
    }
}