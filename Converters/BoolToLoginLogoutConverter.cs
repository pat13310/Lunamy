using System.Globalization;
using System.Windows.Data;

namespace Lunamy.Converters
{

    public class BoolToLoginLogoutConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isConnected = (bool)value;
            return isConnected ? "Déconnexion" : "Connexion";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
