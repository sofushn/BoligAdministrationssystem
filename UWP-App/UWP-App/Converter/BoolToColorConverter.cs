using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace UWP_App.Converter
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool boolVal)
            {
                if (boolVal)
                    return new SolidColorBrush(Colors.Green);
                else
                    return new SolidColorBrush(Colors.Red);
            }
            else
                throw new ArgumentException("value not of type bool");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}