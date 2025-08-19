using ExplorerTabUtility.Models;
using ExplorerTabUtility.Resources;
using System;
using System.Globalization;
using System.Windows.Data;

namespace ExplorerTabUtility.UI.Converters
{
    public class ProfileNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string name)
                return value;

            var resourceKey = $"DefaultProfile_{name}";
            var localizedString = Strings.ResourceManager.GetString(resourceKey, Strings.Culture);

            return !string.IsNullOrEmpty(localizedString) ? localizedString : name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string localizedName)
                return value;
            
            // This is a simplified reverse lookup. It assumes default profile names are unique in translation.
            // A more robust implementation might require iterating through resource keys.
            if (localizedName == Strings.DefaultProfile_Home)
                return "Home";
            if (localizedName == Strings.DefaultProfile_Duplicate)
                return "Duplicate";
            if (localizedName == Strings.DefaultProfile_ReopenClosed)
                return "ReopenClosed";

            return localizedName;
        }
    }
} 