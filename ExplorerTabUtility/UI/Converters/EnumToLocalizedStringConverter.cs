using System;
using System.Globalization;
using System.Windows.Data;
using ExplorerTabUtility.Resources;

namespace ExplorerTabUtility.UI.Converters
{
    public class EnumToLocalizedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Enum enumValue)
                return value;

            var enumType = enumValue.GetType();
            var resourceKey = $"Enum_{enumType.Name}_{enumValue}";
            
            var localizedString = Strings.ResourceManager.GetString(resourceKey, Strings.Culture);

            return !string.IsNullOrEmpty(localizedString) ? localizedString : enumValue.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 