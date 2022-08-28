using System;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using FrontOfficeManagement;
using DataFetcher;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace ClinicManagementTest
{
    public class Tests
    {

        private static Login login;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]

        public void LoginTest()
        {
            login = new Login("user01", "check@01");
            bool check = login.ValidateCredentials();
            Console.WriteLine(check);
            if (check)
            {
                Assert.IsTrue(check);
            }
            else
            {
                Assert.IsFalse(check);
            }
        }
    }
}