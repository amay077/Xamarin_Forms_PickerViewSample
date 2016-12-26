using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PickerViewSample
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

    }
}