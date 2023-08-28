using MarketVerse.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketVerse.Models
{
    public class DatabaseModel
    {
        public static MarketVerseContext db = new MarketVerseContext();
    }
}