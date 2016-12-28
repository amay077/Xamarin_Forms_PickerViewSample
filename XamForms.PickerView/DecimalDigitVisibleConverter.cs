using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamForms.PickerView
{
	internal class DecimalDigitVisibleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var decDigitLength = (int)value;
			var digitIndex = System.Convert.ToInt32(parameter);

			return digitIndex < decDigitLength;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

}
