﻿using System;
using System.Data.SqlClient;


namespace DataFetcher
{
    public class AdoDataBase
    {
        public static SqlConnection connect;
        public static SqlCommand cmd;
        public static List<SqlDataReader> listdr =  new List<SqlDataReader>();

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

        public string FindDoctor(int id)
        {
            connect = GetConnection();
            string query = "select firstname from DoctorDetails where docID =@id ";
            cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
              return  dr[0].ToString();
            }
            return "";
            
        }

    }

}