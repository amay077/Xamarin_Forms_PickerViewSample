using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Android.Widget;
using PickerViewSample;
using PickerViewSample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PickerView), typeof(PickerViewRenderer))]

namespace PickerViewSample.Droid
{
	public class PickerViewRenderer : ViewRenderer<PickerView, NumberPicker>
	{
	    protected override void OnElementChanged(ElementChangedEventArgs<PickerView> e)
	    {
	        base.OnElementChanged(e);

	        if (Control == null)
	        {
				SetNativeControl(new NumberPicker(Context));
	        }
			else
			{
				Control.ValueChanged -= Control_ValueChanged;
			}

	        if (e.NewElement != null)
	        {
				Control.ValueChanged += Control_ValueChanged;

	            UpdateItemsSource();
	            UpdateSelectedIndex();
	        }
	    }

	    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
	    {
	        base.OnElementPropertyChanged(sender, e);

	        if (e.PropertyName == PickerView.ItemsSourceProperty.PropertyName)
	        {
	            UpdateItemsSource();
	        }
	        else if (e.PropertyName == PickerView.SelectedIndexProperty.PropertyName)
	        {
	            UpdateSelectedIndex();
	        }
	    }

	    private void UpdateItemsSource()
	    {
			var arr = new List<string>();
			foreach (var item in Element.ItemsSource)
			{
				arr.Add(item.ToString());
			}

			Control.SetDisplayedValues(arr.ToArray());
			Control.MinValue = 0;
			Control.MaxValue = arr.Count - 1;
	    }

	    private void UpdateSelectedIndex()
	    {
			if (Element.SelectedIndex < Control.MinValue || Element.SelectedIndex >= Control.MaxValue)
			{
				return;
			}

			Control.Value = Element.SelectedIndex;
	    }

		void Control_ValueChanged(object sender, NumberPicker.ValueChangeEventArgs e)
		{
			Element.SelectedIndex = e.NewVal;
		}
	}
}
