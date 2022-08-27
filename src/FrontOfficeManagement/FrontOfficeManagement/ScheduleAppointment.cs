using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFetcher;
using System.Data.SqlClient;

namespace FrontOfficeManagement
{
    public class ScheduleAppointment
    {
        public static AdoDataBase adoData = new AdoDataBase();
        public static SqlDataReader drr;
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public  string PhoneNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public ScheduleAppointment() { }

        public ScheduleAppointment(int patientID, int doctorID, string doctorName, string phoneNumber, DateTime appointmentDate, string appointmentTime)
        {
            PatientID = patientID;
            this.DoctorID = doctorID;
            DoctorName = doctorName;
            PhoneNumber = phoneNumber;
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
        }
        public int BookAppointment()
        {
           int fetchrows = adoData.InsertAppointment(PatientID, DoctorID, DoctorName, PhoneNumber, AppointmentDate, AppointmentTime);
            return fetchrows;
        }


    }
}
