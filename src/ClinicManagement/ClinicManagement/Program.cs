using System;
using DataFetcher;
using System.Data.SqlClient;
using FrontOfficeManagement;
namespace ClinicManagement
{
    internal class Program
    {
        public static AdoDataBase adoData = new AdoDataBase();
        public static SqlDataReader drr;
        public static Login login;
        public static void Main()
        {

             static bool  LoginCheck()
            {
                Console.WriteLine("Welcome to Clinic Management");
                Console.WriteLine();
                Console.WriteLine();
                string username = Console.ReadLine();
                string password = Console.ReadLine();
                login = new Login(username, password);
                if (login.ValidateCredentials())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            bool status = true;
            while (status)
            {
                bool result = LoginCheck();
                if (result)
                {
                    Console.WriteLine("Login Sucessful");
                    status = false;
                }
                else
                {
                    Console.WriteLine("Invalid user name or password");
                }

            }

        }
    }
    
}


