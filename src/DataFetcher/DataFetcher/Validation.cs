using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace DataFetcher
{
    public class Validation
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

        


    }
}
