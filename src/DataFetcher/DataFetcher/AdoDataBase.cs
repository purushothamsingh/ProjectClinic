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



    }

}