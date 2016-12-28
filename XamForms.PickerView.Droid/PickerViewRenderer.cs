using System.Collections.Generic;
using System.ComponentModel;
using Android.Graphics;
using Android.Util;
using Android.Widget;
using Java.Lang.Reflect;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamForms.PickerView;
using XamForms.PickerView.Droid;

[assembly: ExportRenderer(typeof(PickerView), typeof(PickerViewRenderer))]
namespace XamForms.PickerView.Droid
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
                UpdateFont();
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
            else if (e.PropertyName == PickerView.FontFamilyProperty.PropertyName)
            {
                UpdateFont();
            }
            else if (e.PropertyName == PickerView.FontSizeProperty.PropertyName)
            {
                UpdateFont();
            }
        }

        private void UpdateItemsSource()
        {
            var arr = new List<string>();
			if (Element.ItemsSource != null)
			{
				foreach (var item in Element.ItemsSource)
				{
					arr.Add(item.ToString());
				}

			}

			if (arr.Count > 0)
			{
				int newMax = arr.Count - 1;
				if (newMax < Control.Value)
				{
					Element.SelectedIndex = newMax;
				}

				var extend = Control.MaxValue <= newMax;

				if (extend)
				{
					Control.SetDisplayedValues(arr.ToArray());
				}

				Control.MaxValue = newMax;
				Control.MinValue = 0;

				if (!extend)
				{
					Control.SetDisplayedValues(arr.ToArray());
				}
			}
        }

        private void UpdateSelectedIndex()
        {
            if (Element.SelectedIndex < Control.MinValue || Element.SelectedIndex >= Control.MaxValue)
            {
                return;
            }

            Control.Value = Element.SelectedIndex;
        }

        void UpdateFont()
        {
            var font = string.IsNullOrEmpty(Element.FontFamily) ?
                Font.SystemFontOfSize(Element.FontSize) :
                Font.OfSize(Element.FontFamily, Element.FontSize);

            SetTextSize(Control, font.ToTypeface(), (float)(Element.FontSize * Context.Resources.DisplayMetrics.Density));
        }

        void Control_ValueChanged(object sender, NumberPicker.ValueChangeEventArgs e)
        {
            Element.SelectedIndex = e.NewVal;
        }

        /// <summary>
        /// NumberPicker の文字サイズを変更するハック
        /// </summary>
        /// <see cref="http://stackoverflow.com/questions/22962075/change-the-text-color-of-numberpicker"/>
        /// <param name="numberPicker">Number picker.</param>
        /// <param name="textSizeInSp">Text size in pixel.</param>
        private static void SetTextSize(NumberPicker numberPicker, Typeface fontFamily, float textSizeInSp)
        {
            int count = numberPicker.ChildCount;
            for (int i = 0; i < count; i++)
            {
                var child = numberPicker.GetChildAt(i);
                var editText = child as EditText;

                if (editText != null)
                {
                    try
                    {
                        Field selectorWheelPaintField = numberPicker.Class
                            .GetDeclaredField("mSelectorWheelPaint");
                        selectorWheelPaintField.Accessible = true;
                        ((Paint)selectorWheelPaintField.Get(numberPicker)).TextSize = textSizeInSp;
                        editText.Typeface = fontFamily;
                        editText.SetTextSize(ComplexUnitType.Px, textSizeInSp);
                        numberPicker.Invalidate();
                    }
                    catch (System.Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("SetNumberPickerTextColor failed.", e);
                    }
                }
            }
        }
    }
}