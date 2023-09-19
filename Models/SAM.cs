using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MarketVerse.Models
{
    public class SAM
    {
        //Site Activity Month
        [Key] public int Id { get; set; }
        [Required] public string Year { get; set; }
        [Required] public string Month { get; set; }
        [Required] public string Day { get; set; }
        [Required] public int TotalSale { get; set; }
        [Required] public int TotalProfit { get; set; }

        //Finding Methods
        public static string FindMonth(DateTime date)
        {
            return DatabaseModel.db.MonthSale.FirstOrDefault(x => x.Year == date.Year.ToString() && x.Month == date.Month.ToString()).Month.ToString();
        }
        public static SAM FindRow(DateTime date)
        {
            return DatabaseModel.db.MonthSale.FirstOrDefault(x => x.Year == date.Year.ToString() && x.Month == date.Month.ToString());
        }
        //Editing Methods
        public static void CreateMonth()
        {
            try
            {
                SAM month = new SAM
                {
                    Year = DateTime.Now.Year.ToString(),
                    Month = DateTime.Now.Month.ToString(),
                    Day = DateTime.Now.DayOfWeek.ToString(),
                    TotalSale = 0,
                    TotalProfit = 0,

                };
                DatabaseModel.db.MonthSale.Add(month);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static String IncreaseSale(int amount)
        {
            try
            {
                SAM s = FindRow(DateTime.Now);
                s.TotalSale += 1;
                s.TotalProfit += amount;
                DatabaseModel.db.SaveChanges();
                return ("Confirmed");
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}