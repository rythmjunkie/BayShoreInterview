using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TestQ.Controllers
{
    public class MoneyController : Controller
    {
        //
        // GET: /Money/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(double amount)
        {
             ViewBag.intResult = amount.ToString("$#0.##");
             decimal fraction = (decimal)amount;
             int iPart = (int)fraction;
             int decimalResult = Convert.ToInt16((fraction % 1.0m) * 100);
              
                ViewBag.result = convertIntToWord(amount) + " and " +  decimalResult + "/100 dollars";

           

            return View();
        }
        public static string convertIntToWord(double amount)
        {
            var n = (int)amount;
            
             

            if (n > 1000000000)
            {
                return convertIntToWord(n / 1000000000) + "Billion " + convertIntToWord(n % 1000000000);
            }
            else if (n >= 1000000000 && n <= 1999999999)
            {
                return "One Billion " + convertIntToWord(n % 1000000000);
            }
            else if (n >= 1000000 && n <= 999999999)
            {
                return convertIntToWord(n / 1000000) + " Million " + convertIntToWord(n % 1000000);
            }
            else if (n >= 1000000 && n <= 1999999)
            {
                return "One Million " + convertIntToWord(n % 1000000);
            }
            else if (n >= 2000 && n <= 999999)
            {
                return convertIntToWord(n / 1000) + " Thousand " + convertIntToWord(n % 1000);
            }
            else if (n >= 1000 && n <= 1999)
            {
                return "One Thousand " + convertIntToWord(n % 1000);
            }
            else if (n >= 200 && n <= 999)
            {
                return convertIntToWord(n / 100) + " Hundred " + convertIntToWord(n % 100);
            }
            else if (n >= 100 && n <= 199)
            {
                return "One Hundred " + convertIntToWord(n % 100);
            }
            else if (n >= 20 && n <= 99)
            {
                var arr = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
                return arr[n / 10 - 2] + " " + convertIntToWord(n % 10);
            }
            else if (n > 0 && n <= 19)
            {
                var arr = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                return arr[n - 1];
            }
          
            else
                return "Zero";
        }
    }
}
