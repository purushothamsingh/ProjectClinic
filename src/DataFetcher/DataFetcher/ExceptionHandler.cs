using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataFetcher
{
      public class ConnectionErrorExceptionHandler : Exception
    {

        //public ConnectionErrorExceptionHandler(string name)
        //{
        //return "invalid connection";
        //}
    }
    public class InvalidFormatException : Exception { 

        public InvalidFormatException() { }
        public InvalidFormatException(string message) : base(message) {
            //return message;
        }
    }


}
