using System;
using DataFetcher;
using System.Data.SqlClient;
using FrontOfficeManagement;
namespace ClinicManagement
{
    internal class Program
    {
        public static AdoDataBase adoData = new AdoDataBase();
        public static SqlDataReader dr2;
        public static Login login;
        public static ViewDoctors viewDoctors = new ViewDoctors();
        public static void Main()
        {
            Console.WriteLine("Welcome to Clinic Management");
            static bool  LoginCheck()
            { 
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
            static void ViewDoctorsInformation()
            {
                dr2 = viewDoctors.ShowDoctorAvailability();

                while (dr2.Read())
                {
                    Console.WriteLine(dr2[0] + " "+ dr2[1] +" "+ dr2[2]+" " +dr2[3] + " " + dr2[4] + " " + dr2[5]+" " + dr2[6]);
                }
            }
            bool status = true;
            bool is_sucessful = false;
            while (status)
            {
                bool result = LoginCheck();
                if (result)
                {
                    Console.WriteLine("Login Sucessful");
                    status = false;
                    is_sucessful = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid user name or password");
                }

            }

            Console.WriteLine();
            while (is_sucessful)
            {
                bool on_input = false;
                Console.WriteLine();
                Console.WriteLine("Press 1 to ViewDoctor Details");
                Console.WriteLine("Press 2 to Add Patient Details");
                Console.WriteLine("Press 3 to Schedule Appointment");
                Console.WriteLine("Press 4 to Cancle Appointment");
                Console.WriteLine("Press 5 to Logout");
                Console.WriteLine("Please Select the option below to proceed");
                int userinput = Convert.ToInt32(Console.ReadLine());
                


                switch (userinput)
                {
                    case 1:
                        ViewDoctorsInformation();
                        break;
                    default:
                        break;
                }




            }
           
        }
    }
    
}


