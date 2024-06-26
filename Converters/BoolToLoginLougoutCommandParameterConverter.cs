using System;
using System.Globalization;
using System.Windows.Data;

namespace Lunamy.Converters
{
    public class BoolToLoginLogoutCommandParameterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isConnected = (bool)value;
            return isConnected ? "Logout" : "Login";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
