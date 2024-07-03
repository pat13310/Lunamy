using Lunamy.ViewModels;
using System.Windows.Controls;

namespace Lunamy.Views
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            DataContext = new WizardViewModel();
        }


    }
}
