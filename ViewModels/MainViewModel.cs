using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lunamy.Views;
using System.Windows.Controls;

namespace Lunamy.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private Page currentPage;

        [ObservableProperty]
        private bool isHomeSelected;

        [ObservableProperty]
        private bool isTipsSelected;

        [ObservableProperty]
        private bool isAboutSelected;

        [ObservableProperty]
        private bool isContactSelected;

        [ObservableProperty]
        private bool isPartnerSelected;

        [ObservableProperty]
        private bool isConnected; // Ajout de la propriété pour l'état de connexion

        public RelayCommand<string> NavigateCommand { get; }

        Home home_page = new ();
        readonly Tips tips_page = new ();
        readonly About about_page = new ();
        readonly Contact contact_page = new ();
        readonly Partner partner_page = new ();
        readonly Login login_page = new ();
        public RelayCommand StartWizardCommand { get; }
        public MainViewModel()
        {
            login_page.LoginSuccessful += LoginPage_LoginSuccessful;
            CurrentPage = home_page; // Initialiser currentPage
            NavigateCommand = new RelayCommand<string>(OnNavigate); // Initialiser la commande de navigation
            //StartWizardCommand = new RelayCommand(OnStartWizard);
            OnNavigate("Home");
        }

        //private void OnStartWizard()
        //{
        //    CurrentPage = new WizardPage();
        //}
        private void OnNavigate(string? pageName)
        {
            switch (pageName)
            {
                case "Home":
                    CurrentPage = home_page;
                    UpdateSelections(true);
                    break;
                case "Tips":
                    CurrentPage = tips_page;
                    UpdateSelections(false, true);
                    break;
                case "About":
                    CurrentPage = about_page;
                    UpdateSelections(false, false, true);
                    break;
                case "Contact":
                    CurrentPage = contact_page;
                    UpdateSelections(false, false, false, true);
                    break;
                case "Partner":
                    CurrentPage = partner_page;
                    UpdateSelections(false, false, false, false, true);
                    break;
                case "Login":
                    CurrentPage = login_page;
                    UpdateSelections();
                    break;
                case "Logout":
                    IsConnected = false; // Met à jour l'état de connexion
                    CurrentPage = login_page;
                    UpdateSelections();
                    break;
                default:
                    CurrentPage = home_page;
                    UpdateSelections(true);
                    break;
            }

            //Debug.WriteLine($"IsHomeSelected: {IsHomeSelected}, IsTipsSelected: {IsTipsSelected}, IsAboutSelected: {IsAboutSelected}, IsContactSelected: {IsContactSelected}");
        }

        private void LoginPage_LoginSuccessful()
        {
            IsConnected = true;
            OnNavigate("Home");
        }

        private void UpdateSelections(bool home = false, bool tips = false, bool about = false, bool contact = false, bool partner = false)
        {
            IsHomeSelected = home;
            IsTipsSelected = tips;
            IsAboutSelected = about;
            IsContactSelected = contact;
            IsPartnerSelected = partner;
        }

        
    }
}
