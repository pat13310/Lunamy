using Lunamy.Models;
using System.Windows.Controls;

namespace Lunamy.Views
{
    /// <summary>
    /// Logique d'interaction pour Contact.xaml
    /// </summary>
    public partial class Contact : Page
    {
        private SendMail sendMail = new();
        public Contact()
        {
            InitializeComponent();

        }

        private void OnSendMessage(object sender, System.Windows.RoutedEventArgs e)
        {
            string to = "webmaster@xendev.fr";
            string msg = "Message de " + nom.Text + " [" + email.Text + "]" + "\n" + message.Text;
            string subject = sujet.Text  ;
            Task task = SendMail.SendMessage(nom.Text, to, subject,msg);
        }
    }
}
