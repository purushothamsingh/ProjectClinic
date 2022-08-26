using System;
using DataFetcher;
using System.Data.SqlClient;
using FrontOfficeManagement;
using System.Linq;
using System.Collections.Generic;
namespace ClinicManagement
{
    internal class Program
    {
        public static AdoDataBase adoData = new AdoDataBase();
        public static SqlDataReader dr2;
        public static Login login;
        public static ViewDoctors viewDoctors = new ViewDoctors();
        public static AddPatient addPatient = new AddPatient();
        public static List<SqlDataReader> listdr1 = new List<SqlDataReader>();
       static string docName;
       static int docID;
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
                Console.WriteLine();
                while (dr2.Read())
                {
                    Console.WriteLine(dr2[0] + " "+ dr2[1] +" "+ dr2[2]+" " +dr2[3] + " " + dr2[4] + " " + dr2[5]+" " + dr2[6]);
                }
                Console.WriteLine();
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
            static void AppointmentCreation()
            {
                bool is_sucess = true;
                int pid;
                string sname;
               
                Console.WriteLine("Welcome to AppointmentCreation ");
                while (is_sucess)
                {
                    Console.Write("Enter Patient ID");
                     pid = Convert.ToInt32(Console.ReadLine());
                    bool check = adoData.CheckPatientID(pid);
                   
                    if (check)
                    {
                        is_sucess = false;
                        Console.WriteLine("Select the Specialization Required below");
                        Console.WriteLine();
                         Console.WriteLine("Press 1 For Genereal\n Press 2 For Internal Medicine" +
                             "\n Press 3 For Pediatrics\n Press 4 For Orthopedics\n Press 5 For Opthalmology ");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                sname = "General Medicine";
                                listdr1 =   adoData.FindSpecialization(sname);
                                Console.WriteLine();
                                CheckDoctorAvailability();
                                Console.WriteLine();
                                break;
                            case 2:
                                 sname = "Internal Medicine";
                                listdr1 = adoData.FindSpecialization(sname);
                                CheckDoctorAvailability();
                                Console.WriteLine();
                                break;
                            case 3:
                                 sname = "Pediatrics";
                                listdr1 = adoData.FindSpecialization(sname);
                                CheckDoctorAvailability();
                                Console.WriteLine();
                                break;
                            case 4:
                                sname = "Orthopedics";
                                listdr1 = adoData.FindSpecialization(sname);
                                CheckDoctorAvailability();
                                Console.WriteLine();
                                break;
                            case 5:
                                sname = "Opthalmology";
                                listdr1 = adoData.FindSpecialization(sname);
                                CheckDoctorAvailability();
                                Console.WriteLine();
                               
                                break;
                            default:
                                Console.WriteLine("Please Select From List Of Doctors");
                                break;
                        }


                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid Patient ID Please try Again..");
                        Console.WriteLine();
                    }
                }



            }
            static void CheckDoctorAvailability()
            {
               

                if (listdr1[0].HasRows)
                {
                    FindAvailability();
                    Console.WriteLine("Enter doctor id to Select Specific doctor");
                    docID = Convert.ToInt32(Console.ReadLine());
                    dr2 = adoData.FindDoctor(docID);
                    string time1, time2;
                    while (dr2.Read())
                    {
                        docName = dr2[1].ToString();

                        time1 = dr2[5].ToString();
                        time2 = dr2[6].ToString();
                        for (int i = Convert.ToInt32(time1.Substring(0,2)); i < Convert.ToInt32(time2.Substring(0, 2)); i++)
                        {
                            Console.WriteLine("slots available are {0}:00",i);
                        }
                        Console.WriteLine(time1);
                        Console.WriteLine(time2);
                    }

                    Console.WriteLine(docName);
                    


                }
                else
                {
                    Console.WriteLine("Currently We dont have any doctors");
                    listdr1.Clear();
                }
            }
            static void FindAvailability()
            {
                Console.WriteLine("Please Find Available list of doctors ");
                Console.WriteLine();
                foreach (var dr2 in listdr1)
                {
                    while (dr2.Read())
                    {
                        Console.WriteLine(dr2[0] + " " + dr2[1] + " " + dr2[2] + " " + dr2[3] + " " + dr2[4] + " " + dr2[5] + " " + dr2[6]);
                    }
                }
                listdr1.Clear();
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
                            AppointmentCreation();
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


