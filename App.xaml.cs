using System.Configuration;
using System.Data;
using System.Windows;

using LunamyLibrary;

namespace Lunamy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    { 
   
        private const string API_BASE_AUTH = "https://preprod-auth.lunamy.com/";
        private const string API_BASE_ADMIN = "https://preprod-admin.lunamy.com/";

        public static string? JwtToken { get; private set; }
        public static ApiPlatform Platform { get { return new ApiPlatform(API_BASE_AUTH, API_BASE_ADMIN);  } }

        public static void SetToken(string token)
        {
            JwtToken = token;
        }
       
    }

}
