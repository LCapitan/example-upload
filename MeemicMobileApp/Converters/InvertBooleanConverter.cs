using System;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;

namespace MeemicMobileApp.Converters
{
    /// <summary>
    /// Invert Boolean Converter
    /// 
    /// This converter will flip a bool
    /// </summary>
    public class InvertBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.WriteLine("Called!");

            if(value is bool)
                return !(bool)value;


            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
