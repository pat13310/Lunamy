using System.Windows;
using System.Windows.Controls;

namespace Lunamy.Views
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public event Action LoginSuccessful;
        public Login()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.Username.Text!="" || this.Password.Password != "")
            {
                //string ?token = await App.Platform.AuthenticateAsync(Username.Text, Password.Password);
                string ?token = await App.Platform.AuthenticateAsync("reaa@lunamy.com", "password");
                

                if (token != null)
                {
                    // Store the token for future use and navigate to the page Home
                    App.SetToken(token);
                    LoginSuccessful?.Invoke();                    
                }
                else
                {
                    MessageBox.Show("Impossible de se connecter.Veuillez vérifier vos identifiants!");
                }
            }
            else
            {
                MessageBox.Show("Il manque le nom de l'utilisateur ou le mot de passe!");
            }

        }
    }
}
