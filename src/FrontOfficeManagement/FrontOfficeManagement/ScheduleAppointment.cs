using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontOfficeManagement
{
    public class ScheduleAppointment
    {
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public  int PhoneNumber { get; set; }
        public DateTime AppointmentTime { get; set; }
        public ScheduleAppointment() { }

        public ScheduleAppointment(int patientID, int doctorID, string doctorName, int phoneNumber, DateTime appointmentTime)
        {
            PatientID = patientID;
            this.DoctorID = doctorID;
            DoctorName = doctorName;
            PhoneNumber = phoneNumber;
            AppointmentTime = appointmentTime;
        }



    }
}
