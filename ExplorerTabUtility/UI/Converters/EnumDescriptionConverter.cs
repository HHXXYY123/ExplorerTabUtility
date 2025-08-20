using System;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using System.ComponentModel;

namespace ExplorerTabUtility.UI.Converters;

public class EnumDescriptionConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null) return DependencyProperty.UnsetValue;

        var valueStr = value.ToString()!;
        var fieldInfo = value.GetType().GetField(valueStr);
        if (fieldInfo == null) return valueStr;

        var descriptionAttribute = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
            .FirstOrDefault() as DescriptionAttribute;

        return descriptionAttribute?.Description ?? valueStr;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}

public class EnumToLocalizedStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not Enum enumValue)
        {
            return value;
        }

        var enumType = enumValue.GetType();
        var resourceKey = $"Enum_{enumType.Name}_{enumValue}";
        
        var localizedString = Resources.Strings.ResourceManager.GetString(resourceKey, Resources.Strings.Culture);

        return !string.IsNullOrEmpty(localizedString) ? localizedString : enumValue.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

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