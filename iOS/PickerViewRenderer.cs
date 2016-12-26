using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using PickerViewSample;
using PickerViewSample.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PickerView), typeof(PickerViewRenderer))]

namespace PickerViewSample.iOS
{
	public class PickerViewRenderer : ViewRenderer<PickerView, UIPickerView>
	{
	    protected override void OnElementChanged(ElementChangedEventArgs<PickerView> e)
	    {
	        base.OnElementChanged(e);

			var pickerView = Control;

			if (Control == null)
			{
				SetNativeControl(pickerView = new UIPickerView(RectangleF.Empty));
			}

			if (e.NewElement != null)
			{
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
	        Control.Model = new MyDataModel(this.Element.ItemsSource, row =>
	        {
	            Element.SelectedIndex = row;
	        });
	    }

	    private void UpdateSelectedIndex()
	    {
	        if (Control.Model == null)
	        {
	            return;
	        }

			if (Element.SelectedIndex < 0 || Element.SelectedIndex >= Control.Model.GetRowsInComponent(Control, 0))
			{
				return;
			}

	        Control.Select(Element.SelectedIndex, 0, true);
	    }
	}

	class MyDataModel : UIPickerViewModel
	{
	    private readonly IList<string> _list = new List<string>();
	    private readonly Action<int> _selectedHandler;

	    public MyDataModel(IEnumerable items, Action<int> selectedHandler)
		{
		    _selectedHandler = selectedHandler;

		    if (items != null)
			{
				foreach (var item in items)
				{
					_list.Add(item.ToString());
				}
			}
		}

		public override System.nint GetComponentCount(UIPickerView pickerView)
		{
			return 1;
		}

		public override System.nint GetRowsInComponent(UIPickerView pickerView, System.nint component)
		{
			return _list.Count;
		}

		public override string GetTitle(UIPickerView pickerView, System.nint row, System.nint component)
		{
			return _list[(int)row];
		}

	    public override void Selected(UIPickerView pickerView, nint row, nint component)
	    {
	        _selectedHandler?.Invoke((int)row);
	    }
	}
}
