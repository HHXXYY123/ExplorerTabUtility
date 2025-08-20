using System;
using System.Globalization;
using System.Windows.Data;

namespace ExplorerTabUtility.UI.Converters
{
    public class ProfileNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string profileName)
            {
                return value;
            }

            var resourceKey = $"DefaultProfile_{profileName}";
            var localizedString = Resources.Strings.ResourceManager.GetString(resourceKey, Resources.Strings.Culture);

            return !string.IsNullOrEmpty(localizedString) ? localizedString : profileName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 