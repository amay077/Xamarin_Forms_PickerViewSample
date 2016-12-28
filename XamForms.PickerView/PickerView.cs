using System;
using System.Collections;
using Xamarin.Forms;

namespace XamForms.PickerView
{
	public class PickerView : View
	{
		#region ItemsSource
		public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource),
			typeof(IEnumerable), typeof(PickerView), null, propertyChanged: OnItemsSourceChanged);

		public IEnumerable ItemsSource
		{
			get { return (IEnumerable)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		private static void OnItemsSourceChanged(BindableObject bindable, object oldvalue, object newvalue)
		{
		}
		#endregion

		#region SelectedIndex
		public static readonly BindableProperty SelectedIndexProperty =
			BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(PickerView), -1, BindingMode.TwoWay,
				propertyChanged: OnSelectedIndexChanged, coerceValue: CoerceSelectedIndex);


		public int SelectedIndex
		{
			get { return (int)GetValue(SelectedIndexProperty); }
			set { SetValue(SelectedIndexProperty, value); }
		}

		private static object CoerceSelectedIndex(BindableObject bindable, object value)
		{
			return value;
		}

		private static void OnSelectedIndexChanged(BindableObject bindable, object oldvalue, object newvalue)
		{
		}
		#endregion

		#region FontSize

		public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(double), typeof(PickerView), -1.0,
			defaultValueCreator: bindable => Device.GetNamedSize(NamedSize.Default, (PickerView)bindable));

		public double FontSize
		{
			get { return (double)GetValue(FontSizeProperty); }
			set { SetValue(FontSizeProperty, value); }
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
