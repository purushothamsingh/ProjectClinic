using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFetcher;
using System.Data.SqlClient;


namespace FrontOfficeManagement
{
    public class CancleAppointment
    {
        public static AdoDataBase adoData = new AdoDataBase();
        public static SqlDataReader drr;
        public int PatientID { get; set; }
        public DateTime VisitDate { get; set; }
        public string VisitTime { get; set; }

        public CancleAppointment() { }

        public CancleAppointment(int patientID, DateTime visitDate,string visitTime)
        {
            PatientID = patientID;
            VisitDate = visitDate;
            VisitTime = visitTime;
        }

        public int CancleAppointments()
        {
            int result = adoData.CancleAppointment(PatientID, VisitDate, VisitTime);
            return result;
        }



    }
}
