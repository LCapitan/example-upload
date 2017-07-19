using System;
using System.Globalization;
using Xamarin.Forms;

namespace MeemicMobileApp.Converters
{
    public class SelectedItemEventArgsToSelectedItemConverter : IValueConverter
    {
        /// <summary>
        /// Convert the specified value, targetType, parameter and culture.
        /// </summary>
        /// <returns>The converted object</returns>
        /// <param name="value">Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">Culture.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as SelectedItemChangedEventArgs;
            return eventArgs?.SelectedItem;
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
