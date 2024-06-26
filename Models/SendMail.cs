using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lunamy.Models
{
    class SendMail
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly static string apiUrl = "http://localhost:5000//common/api/v1"; // Remplacez avec l'URL de votre API
        private static string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJmcmVzaCI6ZmFsc2UsImlhdCI6MTcxODcxMDgxOSwianRpIjoiZGI3OTY0MzktMjhiNi00ODMzLTk4MGYtZTI0ODFjM2RmMDJhIiwidHlwZSI6ImFjY2VzcyIsInN1YiI6eyJ1c2VybmFtZSI6InhlbiJ9LCJuYmYiOjE3MTg3MTA4MTksImNzcmYiOiJmYmI0NTE2OC03YzEzLTQyMDQtOTVmMS1lM2ZlYWYxNTQ4OGIiLCJleHAiOjE3MjY0ODY4MTl9.IGTcPlFMVyRmLc_AjPRA6bCrxDDODkUVaifLK5Zn3sk";

        public static async Task<bool> Login(string username, string password)
        {
            var loginData = new
            {
                username = username,
                password = password
            };

            var json = JsonConvert.SerializeObject(loginData);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync($"{apiUrl}/login", data);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var tokenData = JsonConvert.DeserializeObject<dynamic>(responseContent);
                    token = tokenData.token;
                    return true;
                }
                else
                {
                    // Gérer les erreurs ici
                    return false;
                }
            }
            catch (HttpRequestException)
            {
                // Gérer les exceptions de connexion ici
                return false;
            }
        }

        public static async Task SendMessage(string nom, string email, string sujet, string message)
        {
            if (string.IsNullOrEmpty(token))
            {
                // Connectez-vous d'abord pour obtenir le token
                return;
            }

            var mailData = new
            {
                recipient = email,
                subject = sujet,
                body = message
            };

            var json = JsonConvert.SerializeObject(mailData);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            try
            {
                var response = await client.PostAsync($"{apiUrl}/send-mail", data);
                if (response.IsSuccessStatusCode)
                {
                    // Informer l'utilisateur que l'e-mail a été envoyé
                }
                else
                {
                    // Gérer les erreurs ici
                }
            }
            catch (HttpRequestException )
            {
                // Gérer les exceptions de connexion ici
            }
        }
    }
}
