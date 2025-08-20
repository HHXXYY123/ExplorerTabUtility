using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace ExplorerTabUtility.UI.Converters
{
    public class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Enum enumValue) 
                return value;

            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (field is null)
                return value;

            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : enumValue.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}