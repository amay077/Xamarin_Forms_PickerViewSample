using System;
using System.Globalization;
using Xamarin.Forms;

namespace PickerViewSample
{
    public class DigitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var num = (decimal)value;
            var digit = System.Convert.ToInt32(parameter);
            var numStr = num.ToString("00");
            var digitStr = numStr.Substring(numStr.Length - 2, 1);

            return int.Parse(digitStr);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
			throw new NotImplementedException();
        }
    }
}