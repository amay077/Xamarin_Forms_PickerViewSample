using System;
using System.Collections;
using Xamarin.Forms;

namespace XamForms.PickerView
{
	public class PickerView : View
	{
		#region ItemsSource
		public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource),
			typeof(IEnumerable), typeof(PickerView), null);

		public IEnumerable ItemsSource
		{
			get { return (IEnumerable)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}
		#endregion

		#region SelectedIndex
		public static readonly BindableProperty SelectedIndexProperty =
			BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(PickerView), -1, BindingMode.TwoWay,
				coerceValue: CoerceSelectedIndex);


		public int SelectedIndex
		{
			get { return (int)GetValue(SelectedIndexProperty); }
			set { SetValue(SelectedIndexProperty, value); }
		}

		private static object CoerceSelectedIndex(BindableObject bindable, object value)
		{
			if (value == null)
			{
				return 0;
			}
			return value;
		}
		#endregion

		#region FontSize

		public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(double), typeof(PickerView), -1.0,
       		defaultValueCreator: bindable => Device.GetNamedSize(NamedSize.Default, (PickerView)bindable), 
           	coerceValue:CoerceFontSize);

		public double FontSize
		{
			get { return (double)GetValue(FontSizeProperty); }
			set { SetValue(FontSizeProperty, value); }
		}

		private static object CoerceFontSize(BindableObject bindable, object value)
		{
			if (value == null)
			{
				return Device.GetNamedSize(NamedSize.Default, (PickerView)bindable);
			}
			return value;
		}
		#endregion

		#region FontFamily

		public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create("FontFamily", typeof(string), typeof(PickerView), default(string));

		public string FontFamily
		{
			get { return (string)GetValue(FontFamilyProperty); }
			set { SetValue(FontFamilyProperty, value); }
		}

		#endregion

	}

}
