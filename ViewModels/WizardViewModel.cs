using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Lunamy.Views;

namespace Lunamy.ViewModels
{
    public partial class WizardViewModel : ObservableObject
    {
        private readonly ObservableCollection<UserControl> _steps;
        private int _currentStepIndex;

        [ObservableProperty]
        private UserControl _currentStep;

        public WizardViewModel()
        {
            _steps = new ObservableCollection<UserControl>
            {
                new Step1(),
                new Step2(),
                new Step3(),
                new Step4(),
            };

            _currentStepIndex = 0;
            CurrentStep = _steps[_currentStepIndex];
        }

        [RelayCommand]
        private void Next()
        {
            if (_currentStepIndex < _steps.Count - 1)
            {
                _currentStepIndex++;
                CurrentStep = _steps[_currentStepIndex];
            }
        }

        [RelayCommand]
        private void Previous()
        {
            if (_currentStepIndex > 0)
            {
                _currentStepIndex--;
                CurrentStep = _steps[_currentStepIndex];
            }
        }

        [RelayCommand]
        private static void Finish()
        {
            // Logique de finalisation (on verra en dernier )
        }
    }
}
