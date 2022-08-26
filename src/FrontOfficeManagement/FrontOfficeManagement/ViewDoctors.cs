using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFetcher;
using FrontOfficeManagement;
using System.Data.SqlClient;

namespace FrontOfficeManagement
{
    public class ViewDoctors
    {
        public static AdoDataBase adoData = new AdoDataBase();
        public static SqlDataReader drr;
        public SqlDataReader ShowDoctorAvailability()
        {

          drr =   adoData.ViewDoctorsData();


          return drr;
        }




    }
}
