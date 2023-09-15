using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketVerse.Models
{
    public class PFMP
    {
        //Products for Main Page

        public List<Product> Products { get; set; }
        //Product sorted by View
        public List<Product> PBV { get; set; }
        //Product sorted by Purchase
        public List <Product> PBP { get; set; }
    }
}