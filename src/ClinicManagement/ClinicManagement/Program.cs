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
        public static AddPatient addPatient = new AddPatient();
        public static void Main()
        {
            
            static bool  LoginCheck()
            {
                Console.WriteLine("Welcome to Clinic Management");
                Console.WriteLine();
                Console.Write("Enter UserName ");
                string username = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Enter Password ");
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
            static void AddPatientDetails()
            {
                Console.WriteLine("Please add patient details below  ");
                Console.WriteLine();
                Console.Write("Enter FirstName ");
                string fname = Console.ReadLine();
                Console.Write("Enter LastName  ");
                string lname = Console.ReadLine();
                Console.Write("Enter Gender  ");
                string gender = Console.ReadLine();
                Console.WriteLine("Enter DateofBirth in DD/MM/YYY Format");
                DateTime dt = Convert.ToDateTime(Console.ReadLine());

                addPatient = new AddPatient(fname, lname, gender, dt);
               int data = addPatient.Insertdata();
                if (data > 0)
                {
                    Console.WriteLine("Patient details added succesfully");
                }
                else
                {
                    Console.WriteLine("Error in database");
                }
                

            }

            bool status = true;
            bool is_sucessful = false;

            while (status)
            {
                bool result = LoginCheck();
                if (result)
                {
                    Console.WriteLine();
                    Console.WriteLine("Login Sucessful");
                    status = false;
                    is_sucessful = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid user name or password");
                }

                Console.WriteLine();

                while (is_sucessful)
                {
                    bool on_input = false;
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
                        case 2:
                            AddPatientDetails();
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            is_sucessful = false;
                            status = true;
                            Console.WriteLine();
                            Console.WriteLine("Logged out successfully");
                            Console.WriteLine();
                            break;

                        default:
                            break;
                    }

                }
            }
           
        }
    }
    
}


