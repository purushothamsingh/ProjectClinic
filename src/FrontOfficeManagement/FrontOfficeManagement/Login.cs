using DataFetcher;
namespace FrontOfficeManagement
{
    public class Login
       {

        public static AdoDataBase adoData = new AdoDataBase();
        private string Username { get; }
        private string Password { get; } 
        public Login() {}
        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public bool ValidateCredentials()
        {

           bool check=  adoData.UserLoginCheck(Username, Password);
            if (check)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }



    }
}