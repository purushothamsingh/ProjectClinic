using System;
using DataFetcher;
using System.Data.SqlClient;
using FrontOfficeManagement;
using System.Linq;
using System.Collections.Generic;
namespace ClinicManagement
{
    public class Program
    {
        public static AdoDataBase adoData = new AdoDataBase();
        public static ViewDoctors viewDoctors = new ViewDoctors();
        public static AddPatient addPatient = new AddPatient();
        public static ScheduleAppointment ScheduleAppointment = new ScheduleAppointment();
        public static List<SqlDataReader> listdr1 = new List<SqlDataReader>();
        public static Validations validation;
        public static List<int> timelist = new List<int>();
        public static List<int> docIdList = new List<int>();
        public static List<int> slotsList = new List<int>();
        public static SqlDataReader dr2;
        public static Login login;
        static string docName ,date,slot,number;
        static int docID,pid;
        public static void Main()
        {
            
            static bool  LoginCheck()
            {
                Console.WriteLine("Welcome to Clinic Management");
                Console.WriteLine();
                Console.Write("Enter UserName ");
                string username = Console.ReadLine();
                if (username.Count() > 10)
                {
                    Console.WriteLine("User name should be less than 10 charecters");
                    LoginCheck();
                }
                Console.WriteLine();
                Console.Write("Enter Password is ");
                string password = Console.ReadLine();
                bool check = Validations.ValidatePassword(password);
                while (check==false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Your password doest not contain @ symbol");
                    Console.WriteLine();
                    Console.Write("Enter Password ");
                    password = Console.ReadLine();
                    check = Validations.ValidatePassword(password);
                }


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
                bool check = Validations.ValidateString(fname);
                while(check == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid format please give only alphabets");
                    Console.WriteLine();
                    Console.Write("Enter FirstName ");
                     fname = Console.ReadLine();
                    check = Validations.ValidateString(fname);
                }
                Console.Write("Enter LastName  ");
                string lname = Console.ReadLine();
                bool check1 = Validations.ValidateString(lname);
                while (check1 == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid format please give only alphabets");
                    Console.WriteLine();
                    Console.Write("Enter LastName ");
                    lname = Console.ReadLine();
                    check1 = Validations.ValidateString(fname);
                }
                Console.Write("Enter Gender  ");
                string gender = Console.ReadLine();
                bool check2 = Validations.ValidateString(gender);
                while (check2 == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid format please give only alphabets");
                    Console.WriteLine();
                    Console.Write("Enter Gender  ");
                    gender = Console.ReadLine();
                    check2 = Validations.ValidateString(fname);
                }
                Console.Write("Enter DateofBirth in DD/MM/YYY Format ");
                string dt1 = Console.ReadLine();
                bool check4 = Validations.ValidateDate1(dt1);
                while (check4 == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid Format or it doest accepts strings ");
                    Console.WriteLine();
                    Console.Write("Enter DateofBirth in DD/MM/YYY Format ");
                    dt1 = Console.ReadLine();
                    check4 = Validations.ValidateDate1(dt1);
                }
                DateTime dt = Convert.ToDateTime(dt1);
                bool check3 = Validations.ValidateDate(dt);

                while (check3 == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid format or you entered past date");
                    Console.WriteLine();
                    Console.Write("Enter DateofBirth in DD/MM/YYY Format  ");
                     dt = Convert.ToDateTime(Console.ReadLine());
                     check3 = Validations.ValidateDate(dt);
                }

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
                string sname;
               
                Console.WriteLine("Welcome to AppointmentCreation ");
                while (is_sucess)
                {
                    Console.Write("Enter Patient ID ");
                     pid = Convert.ToInt32(Console.ReadLine());
                    bool check = adoData.CheckPatientID(pid);
                   
                    if (check)
                    {
                        is_sucess = false;
                        Console.WriteLine("Select the Specialization Required below");
                        Console.WriteLine();
                         Console.WriteLine("Press 1 For Genereal\nPress 2 For Internal Medicine" +
                             "\nPress 3 For Pediatrics\nPress 4 For Orthopedics\nPress 5 For Opthalmology ");
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
                    bool check = docIdList.Contains(docID);
                    while (check==false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please Enter Corret doctor id from above");
                        Console.WriteLine();
                        docID = Convert.ToInt32(Console.ReadLine());
                        check = docIdList.Contains(docID);

                    }
                    docIdList.Clear();
                    Console.WriteLine("Please enter date for doctor appointment YYY/MM/DD format");
                    date = Console.ReadLine();
                    timelist = adoData.DoctorsTimeAvailability(docID, date);
                    dr2 = adoData.FindDoctor(docID);
                    string time1, time2;
                    int empty = 0;
                    while (dr2.Read())
                    {
                        docName = dr2[1].ToString();
                        time1 = dr2[5].ToString();
                        time2 = dr2[6].ToString();
                        for (int i = Convert.ToInt32(time1.Substring(0, 2)); i < Convert.ToInt32(time2.Substring(0, 2)); i++)
                        {
                            if (timelist.Contains(i))
                            {
                                continue;
                            }
                            else
                            { 
                                Console.WriteLine("slots available are {0}:00", i);
                                slotsList.Add(i);
                                empty += 1;
                            }
                           
                            

                        }
                        timelist.Clear();
                        if (empty == 0)
                        {
                            Console.WriteLine("All Slots are booked for this date");
                            
                        }
                       
                        else
                        {
                            Console.WriteLine();
                            Console.Write("Please Enter the slot specified above ");
                            slot = Console.ReadLine();
                            bool check4 = slotsList.Contains(Convert.ToInt32(slot.Substring(0,1)));
                            while(check4 == false)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Please select correct slot from above only");
                                Console.WriteLine();
                                Console.Write("Please Enter the slot specified above ");
                                slot = Console.ReadLine();
                                check4 = slotsList.Contains(Convert.ToInt32(slot.Substring(0, 1)));
                            }
                            slotsList.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Enter your Phone Number to Confirm Your solt ");
                            number = Console.ReadLine();
                            ScheduleAppointment = new ScheduleAppointment(pid, docID, docName, number, Convert.ToDateTime(date), slot + ":00");
                            int row = ScheduleAppointment.BookAppointment();

                            if (row > 0)
                            {
                                Console.WriteLine("Your solt is booked sucessfully ..");
                            }
                            else
                            {
                                Console.WriteLine("slot is not booked error in database");
                            }


                        }



                    }

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
                        docIdList.Add(Convert.ToInt32(Convert.ToString(dr2[0])));
                        Console.WriteLine(dr2[0] + " " + dr2[1] + " " + dr2[2] + " " + dr2[3] + " " + dr2[4] + " " + dr2[5] + " " + dr2[6]);
                    }
                }
                listdr1.Clear();
            }
            static void CancelAppoinment()
            {
                bool status = true;
                bool is_sucessful = false;
                Console.WriteLine();
                while (status)
                {
                    Console.WriteLine("Welcome to Cancellation Of Your Appointment");
                    Console.WriteLine();
                    Console.Write("Enter Patient ID ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    bool check = adoData.CheckPatientID(id);
                    if (check)
                    {
                        status = false;
                        is_sucessful = true;
                    }

                    if (is_sucessful)
                    {
                        dr2 = adoData.ListOfAppointments(id);
                        Console.WriteLine();
                        while (dr2.Read())
                        {
                            Console.WriteLine(dr2[0] + " " + dr2[1] + " " + dr2[2] + " " + dr2[3] + " " + dr2[4] + " " + dr2[5] );
                        }
                        Console.WriteLine();
                        Console.Write("Enter date to cancle your appointment in YYYY/MM/DD ");
                        string dt = Console.ReadLine();
                        dr2 = adoData.ListOfAppointments(id, dt);
                        Console.WriteLine();
                        while (dr2.Read())
                        {
                            Console.WriteLine(dr2[0] + " " + dr2[1] + " " + dr2[2] + " " + dr2[3] + " " + dr2[4] + " " + dr2[5]);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Enter time to cancle the appointemnt HH:00");
                        string hour = Console.ReadLine() + ":00";

                        int rows = adoData.CancleAppointment(id, Convert.ToDateTime(dt), hour);
                        if (rows > 0)
                        {
                            Console.WriteLine("Your Appointment Canclled Sucessfully");
                        }
                        else
                        {
                            Console.WriteLine("Error in data base Appointment cancellation failed");
                        }
                    }

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
                    int defaultt = 0;
                    int userinput = 0;
                    string  userinput1 = Console.ReadLine();
                    bool handle = int.TryParse(userinput1, out  defaultt);
                    userinput = handle ? Convert.ToInt32(userinput1) : 0;
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
                            CancelAppoinment();
                            break;
                        case 5:
                            is_sucessful = false;
                            status = true;
                            Console.WriteLine();
                            Console.WriteLine("Logged out successfully");
                            Console.WriteLine();
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("Invalid selection Please Select from above options");
                            Console.WriteLine();
                            break;
                    }

                }
            }
           
        }
    }
    
}


