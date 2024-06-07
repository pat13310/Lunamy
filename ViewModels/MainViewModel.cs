﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lunamy.Views;
using System.Diagnostics;
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

        public MainViewModel()
        {
            CurrentPage = new Home(); // Initialiser currentPage
            NavigateCommand = new RelayCommand<string>(OnNavigate); // Initialiser la commande de navigation
            OnNavigate("Home");
        }

        public RelayCommand<string> NavigateCommand { get; }

        private void OnNavigate(string? pageName)
        {
            Debug.WriteLine($"Navigating to {pageName}");
            switch (pageName)
            {
                case "Home":
                    CurrentPage = new Home();
                    UpdateSelections(true, false, false, false);
                    break;
                case "Tips":
                    CurrentPage = new Tips();
                    UpdateSelections(false, true, false, false);
                    break;
                case "About":
                    CurrentPage = new About();
                    UpdateSelections(false, false, true, false);
                    break;
                case "Contact":
                    CurrentPage = new Contact();
                    UpdateSelections(false, false, false, true);
                    break;
                default:
                    CurrentPage = new Home();
                    UpdateSelections(true, false, false, false);
                    break;
            }

            Debug.WriteLine($"IsHomeSelected: {IsHomeSelected}, IsTipsSelected: {IsTipsSelected}, IsAboutSelected: {IsAboutSelected}, IsContactSelected: {IsContactSelected}");
        }

        private void UpdateSelections(bool home, bool tips, bool about, bool contact)
        {
            IsHomeSelected = home;
            IsTipsSelected = tips;
            IsAboutSelected = about;
            IsContactSelected = contact;
        }
    }
}