using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lunamy.Views;
using System.Collections.ObjectModel;
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

        Home home_page = new();

        public WizardViewModel WizardViewModel { get; } = new WizardViewModel();

        /* partie navigation générale */
        readonly Tips tips_page = new();
        readonly About about_page = new();
        readonly Contact contact_page = new();
        readonly Partner partner_page = new();
        readonly Login login_page = new();


        /* partie wizard */
        /*private UserControl _currentStep;
        private  int _currentIndex;
        public ObservableCollection<UserControl> Steps { get; }
        public RelayCommand StartWizardCommand { get; }
        public RelayCommand NextCommand { get; }
        public RelayCommand PreviousCommand { get; }
        */


        [ObservableProperty]
        private UserControl currentStep;

        public MainViewModel()
        {
            login_page.LoginSuccessful += LoginPage_LoginSuccessful;
            CurrentPage = home_page; // Initialiser currentPage
            NavigateCommand = new RelayCommand<string>(OnNavigate); // Initialiser la commande de navigation
            OnNavigate("Home");
            CurrentStep = WizardViewModel.CurrentStep;
        }

       
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
        //public UserControl CurrentStep
        //{
        //    get => _currentStep;
        //    set => SetProperty(ref _currentStep, value);
        //}
        //private void StartWizard()
        //{
        //    _currentIndex = 0;
        //    CurrentStep = Steps[_currentIndex];
        //    UpdateCommandStates();
        //}

        //private void OnNext()
        //{
        //    if (_currentIndex < Steps.Count - 1)
        //    {
        //        _currentIndex++;
        //        CurrentStep = Steps[_currentIndex];
        //        UpdateCommandStates();
        //    }
        //}

        //private void OnPrevious()
        //{
        //    if (_currentIndex > 0)
        //    {
        //        _currentIndex--;
        //        CurrentStep = Steps[_currentIndex];
        //        UpdateCommandStates();
        //    }
        //}

        //private bool CanMoveNext() => _currentIndex < Steps.Count - 1;
        //private bool CanMovePrevious() => _currentIndex > 0;

        //private void UpdateCommandStates()
        //{
        //    NextCommand.NotifyCanExecuteChanged();
        //    PreviousCommand.NotifyCanExecuteChanged();
        //}


    }
}
