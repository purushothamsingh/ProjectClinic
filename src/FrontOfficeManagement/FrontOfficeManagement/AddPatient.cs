using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFetcher;
using System.Data.SqlClient;

namespace FrontOfficeManagement
{
    public class AddPatient
    {
        public static AdoDataBase adoData = new AdoDataBase();
        public static SqlDataReader drr;
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Sex { get; set; }
        public DateTime Dob { get; set; }
        public  int  Age { get; set; }

        public AddPatient() { }
        public AddPatient(string firstname, string lastname, string sex, DateTime dob)
        {
            Firstname = firstname;
            Lastname = lastname;
            Sex = sex;
            Dob = dob;
            Age = DateTime.Now.Year - dob.Year;
        }

        public int Insertdata()
        {
          int k=   adoData.InsertPatientData(Firstname, Lastname, Sex, Age , Dob);
            return k;
        }
        
    }
}
