using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace DataFetcher
{
    public class Validations
    {

        public static bool ValidatePassword(string passw)
        {
            if (passw.Contains("@"))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public static bool ValidateString(string str)
        {
            if (Regex.Match(str,"^[a-z A-Z]*$").Success)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool ValidateDate(DateTime dt)
        {
            if (Regex.Match(Convert.ToString(dt).Substring(0,10) , "^(3[01]|[12][0-9]|0?[1-9])-(1[0-2]|0?[1-9])-(?:[0-9]{2})?[0-9]{2}$").Success)
            {
               
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool ValidateDate1(string dt)
        {
            if (Regex.Match(dt, "^(3[01]|[12][0-9]|0?[1-9])/(1[0-2]|0?[1-9])/(?:[0-9]{2})?[0-9]{2}$").Success)
            {
                
                return true;
            }
            else
            {
                return false;
            }

        }



    }
}
