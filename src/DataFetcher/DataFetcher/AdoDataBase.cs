using System;
using System.Data.SqlClient;


namespace DataFetcher
{
    public class AdoDataBase 
    {
        public static SqlConnection connect;
        public static SqlCommand cmd;
        public static List<SqlDataReader> listdr =  new List<SqlDataReader>();
        public static List<int> timelist = new List<int>();

        private static SqlConnection GetConnection()
        {
                connect = new SqlConnection("Data Source=.;Initial Catalog=Clinic;Integrated Security=true");
                connect.Open();
                return connect;
        }
        public SqlDataReader getUserDetails()
        {
            connect = GetConnection();
            cmd = new SqlCommand("select * from USERMANAGEMENT", connect);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public  bool UserLoginCheck(string username ,string passw)
        {
            connect = GetConnection();
            string query = "select * from USERMANAGEMENT where USERNAME = @username AND USER_PASSWORD = @passw ";
            cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@passw",passw);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public  SqlDataReader ViewDoctorsData()
        {
            connect = GetConnection();
            string query = "select * from DoctorDetails";
            cmd = new SqlCommand(query, connect);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public int InsertPatientData(string fname ,string lname ,string gender,int age,DateTime dt)
        {
            connect = GetConnection();
            string query = "insert into patientInfo  values (@fname ,@lname,@gender,@age,@dt)";
            cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@dt", dt);
            int  i = cmd.ExecuteNonQuery();
            return i;
        }

        public bool CheckPatientID(int id)
        {
            connect = GetConnection();
            string query = "select * from  patientInfo where patientID = @id ";
            cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr.HasRows ?  true :  false;
        }

        public List<SqlDataReader> FindSpecialization(string name)
        {
            connect = GetConnection();
            string query = " select * from DoctorDetails where specialization = @name ";
            cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@name", name);
            SqlDataReader dr = cmd.ExecuteReader();
            listdr.Add(dr);
            return listdr;
        }

        public SqlDataReader FindDoctor(int id)
        {
            connect = GetConnection();
            string query = "select * from DoctorDetails where docID =@id ";
            cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
            
        }

        public List<int> DoctorsTimeAvailability(int docId,string date)
        {
            connect = GetConnection();
            string query = "select * from ScheduleAppointment where doctorID = @docId and appointmentdate = @date";
            cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@docId", docId);
            cmd.Parameters.AddWithValue("@date", date);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               timelist.Add(Convert.ToInt32(dr[5].ToString().Substring(0, 2)));
               
            }
            return timelist;
        }
        public int InsertAppointment(int patientID, int doctorID, string doctorName, string phoneNumber, DateTime appointmentDate, string appointmentTime)
        {
            connect = GetConnection();
            string query = "insert into ScheduleAppointment  values (@patientID ,@doctorID,@doctorName,@phoneNumber,@appointmentDate,@appointmentTime)";
            cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@patientID", patientID);
            cmd.Parameters.AddWithValue("@doctorID", doctorID);
            cmd.Parameters.AddWithValue("@doctorName", doctorName);
            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            cmd.Parameters.AddWithValue("@appointmentDate", appointmentDate);
            cmd.Parameters.AddWithValue("@appointmentTime", appointmentTime);
            int i = cmd.ExecuteNonQuery();
            return i;
        }
// Section 5 Cancle Appointment part
        public int CancleAppointment(int id, DateTime date,string time)
        {
            connect = GetConnection();
            string query = "delete from ScheduleAppointment where patientid =@id and appointmentdate = @date and appointmenttime =@time ";
            cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@time", time);
            int rowsaffected = cmd.ExecuteNonQuery();
            return rowsaffected;
        }
        public SqlDataReader ListOfAppointments(int pid, string date = "" )
        {
            connect = GetConnection();
            string str = "";
            if (date == "")
            {
                str = "or";
            }
            else
            { 
                str = "and";
            }
            string query = string.Format("select * from ScheduleAppointment where patientid='{0} ' "+ str +" appointmentdate = '{1}' ;", pid,  date);
            cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@appointmentdate", date);
           
            
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

    }

}