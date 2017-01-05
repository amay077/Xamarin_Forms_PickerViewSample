using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace XamForms.PickerView
{
	public partial class NumbersPickerView : ContentView
	{
	    #region FontSize

	    public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(NumbersPickerView), -1.0,
	        defaultValueCreator: bindable => Device.GetNamedSize(NamedSize.Default, (NumbersPickerView)bindable),
	        propertyChanged:OnFontSizeChanged);

	    public double FontSize
	    {
	        get { return (double)GetValue(FontSizeProperty); }
	        set { SetValue(FontSizeProperty, value); }
	    }

	    private static void OnFontSizeChanged(BindableObject bindable, object oldvalue, object newvalue)
	    {
	        var view = (NumbersPickerView) bindable;
	        var vm = view.grid.BindingContext as NumbersPickerViewModel;
	        vm.FontSize = (double)(newvalue ?? Device.GetNamedSize(NamedSize.Default, (NumbersPickerView)bindable));
	    }

	    #endregion

	    #region ColumnWidth

	    public static readonly BindableProperty ColumnWidthProperty = BindableProperty.Create(nameof(ColumnWidth), typeof(double), typeof(NumbersPickerView), 17d,
	        propertyChanged:OnColumnWidthChanged);

	    public double ColumnWidth
	    {
	        get { return (double)GetValue(ColumnWidthProperty); }
	        set { SetValue(ColumnWidthProperty, value); }
	    }

	    private static void OnColumnWidthChanged(BindableObject bindable, object oldvalue, object newvalue)
	    {
			if (newvalue == null)
			{
				return;
			}

	        var view = (NumbersPickerView) bindable;
	        var vm = view.grid.BindingContext as NumbersPickerViewModel;
	        vm.ColumnWidth = (double)newvalue;
	    }

	    #endregion

	    #region Value

	    public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(decimal), typeof(NumbersPickerView), 0M, propertyChanged:OnValueChanged);

	    public decimal Value
	    {
	        get { return (decimal)GetValue(ValueProperty); }
	        set { SetValue(ValueProperty, value); }
	    }

	    private static void OnValueChanged(BindableObject bindable, object oldvalue, object newvalue)
	    {
	        var view = (NumbersPickerView) bindable;
	        var vm = view.grid.BindingContext as NumbersPickerViewModel;
	        vm.Value = (decimal)(newvalue ?? ValueProperty.DefaultValue);
	    }

	    #endregion

	    #region IntegerDigitLength

	    public static readonly BindableProperty IntegerDigitLengthProperty = BindableProperty.Create(nameof(IntegerDigitLength), typeof(int), typeof(NumbersPickerView), 3,
	        propertyChanged: OnIntegerDigitLengthChanged);

		public int IntegerDigitLength
	    {
	        get { return (int)GetValue(IntegerDigitLengthProperty); }
	        set { SetValue(IntegerDigitLengthProperty, value); }
	    }

	    private static void OnIntegerDigitLengthChanged(BindableObject bindable, object oldvalue, object newvalue)
	    {

	        var view = (NumbersPickerView)bindable;
	        var vm = view.grid.BindingContext as NumbersPickerViewModel;
	        vm.IntegerDigitLength = (int)(newvalue ?? IntegerDigitLengthProperty.DefaultValue);
	    }

		#endregion

	    #region DecimalDigitLength

	    public static readonly BindableProperty DecimalDigitLengthProperty = BindableProperty.Create(nameof(DecimalDigitLength), typeof(int), typeof(NumbersPickerView), 0,
	        propertyChanged: OnDecimalDigitLengthChanged);

	    public int DecimalDigitLength
	    {
	        get { return (int)GetValue(DecimalDigitLengthProperty); }
	        set { SetValue(DecimalDigitLengthProperty, value); }
	    }

	    private static void OnDecimalDigitLengthChanged(BindableObject bindable, object oldvalue, object newvalue)
	    {

	        var view = (NumbersPickerView)bindable;
	        var vm = view.grid.BindingContext as NumbersPickerViewModel;
	        vm.DecimalDigitLength = (int)(newvalue ?? DecimalDigitLengthProperty.DefaultValue);
	    }

	    #endregion

		public NumbersPickerView()
		{
			InitializeComponent();

		    var vm = grid.BindingContext as NumbersPickerViewModel;
		    vm.PropertyChanged += ViewModel_OnPropertyChanged;

			// View の既定値を ViewModel に伝搬
			vm.IntegerDigitLength = IntegerDigitLength;
			vm.DecimalDigitLength = DecimalDigitLength;
			vm.Value = Value;
		    vm.ColumnWidth = ColumnWidth;
		}

	    private void ViewModel_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
	    {
			var vm = sender as NumbersPickerViewModel;
	        if (e.PropertyName == "Value")
	        {
	            Value = vm.Value;
	        }
	    }
	}
}