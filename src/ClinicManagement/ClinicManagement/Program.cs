using System;
using DataFetcher;
using System.Data.SqlClient;
namespace ClinicManagement
{
    internal class Program
    {
        public static AdoDataBase adoData = new AdoDataBase();
        public static SqlDataReader drr;
        public static void Main()
        {
            Console.WriteLine("helo");
         drr =  adoData.getUserDetails();

            while (drr.Read())
            {
                Console.WriteLine("FirstColumn\tSecond Column\t\tThird Column\t\tForth Column\t");
                    Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}",
                    drr[0], drr[1], drr[2], drr[3]));
                

            }
        }
    }
    
}


