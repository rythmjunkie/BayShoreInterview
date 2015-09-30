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
        public ActionResult Index(decimal amount = 0)
        {
            if (amount != 0)
            {
                ViewBag.intResult = String.Format("${0:0,0.00}", amount);
                int decimalResult = Convert.ToInt16((amount % 1.0m) * 100);
                ViewBag.result = char.ToUpper(convertIntToWord(amount)[0]) + convertIntToWord(amount).Substring(1) + " and " + decimalResult + "/100 dollars";
            }
            return View();
        }
        public static string convertIntToWord(decimal amount)
        {
            var n = (long)amount;
            if (n > 1000000000)
            {
                return convertIntToWord(n / 1000000000) + " billion " + convertIntToWord(n % 1000000000);
            }
            else if (n >= 1000000000 && n <= 1999999999)
            {
                return "one billion " + convertIntToWord(n % 1000000000);
            }
            else if (n >= 1000000 && n <= 999999999)
            {
                return convertIntToWord(n / 1000000) + " million " + convertIntToWord(n % 1000000);
            }
            else if (n >= 1000000 && n <= 1999999)
            {
                return "one million " + convertIntToWord(n % 1000000);
            }
            else if (n >= 2000 && n <= 999999)
            {
                return convertIntToWord(n / 1000) + " thousand " + convertIntToWord(n % 1000);
            }
            else if (n >= 1000 && n <= 1999)
            {
                return "one Thousand " + convertIntToWord(n % 1000);
            }
            else if (n >= 200 && n <= 999)
            {
                return convertIntToWord(n / 100) + " hundred " + convertIntToWord(n % 100);
            }
            else if (n >= 100 && n <= 199)
            {
                return "one Hundred " + convertIntToWord(n % 100);
            }
            else if (n >= 20 && n <= 99)
            {
                var arr = new string[] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
                return arr[n / 10 - 2] + " " + convertIntToWord(n % 10);
            }
            else if (n > 0 && n <= 19)
            {
                var arr = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                return arr[n - 1];
            }
          
            else
                return "";
            }
        
    }
}
