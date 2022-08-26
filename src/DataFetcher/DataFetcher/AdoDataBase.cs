using System;
using System.Data.SqlClient;


namespace DataFetcher
{
    public class AdoDataBase
    {
        public static SqlConnection connect;
        public static SqlCommand cmd;

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


    }

}