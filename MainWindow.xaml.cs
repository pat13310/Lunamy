using System.Windows;
using Lunamy.ViewModels;

namespace Lunamy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Lunamy.ViewModels.MainViewModel();
        }
    }
}