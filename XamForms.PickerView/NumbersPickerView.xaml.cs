using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace XamForms.PickerView
{
	public partial class NumbersPickerView : ContentView
	{
	    #region FontSize

	    public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(double), typeof(NumbersPickerView), -1.0,
	        defaultValueCreator: bindable => Device.GetNamedSize(NamedSize.Default, (NumbersPickerView)bindable),
	        propertyChanged:OnFontSizeChanged);

	    public double FontSize
	    {
	        get { return (double)GetValue(FontSizeProperty); }
	        set { SetValue(FontSizeProperty, value); }
	    }

	    private static void OnFontSizeChanged(BindableObject bindable, object oldvalue, object newvalue)
	    {
	        if (newvalue == null)
	        {
	            return;
	        }

	        var view = (NumbersPickerView) bindable;
	        var vm = view.grid.BindingContext as NumbersPickerViewModel;
	        vm.FontSize = (double)newvalue;
	    }

	    #endregion

	    #region Value

	    public static readonly BindableProperty ValueProperty = BindableProperty.Create("Value", typeof(decimal), typeof(NumbersPickerView), 0M, propertyChanged:OnValueChanged);

	    public decimal Value
	    {
	        get { return (decimal)GetValue(ValueProperty); }
	        set { SetValue(ValueProperty, value); }
	    }

	    private static void OnValueChanged(BindableObject bindable, object oldvalue, object newvalue)
	    {
	        var view = (NumbersPickerView) bindable;
	        var vm = view.grid.BindingContext as NumbersPickerViewModel;
	        vm.Value = (decimal)newvalue;
	    }

	    #endregion

	    private NumbersPickerViewModel _viewModel;

	    public NumbersPickerView()
		{
			InitializeComponent();
		}

	    protected override void OnBindingContextChanged()
	    {
	        base.OnBindingContextChanged();

	        if (_viewModel != null)
	        {
	            _viewModel.PropertyChanged -= ViewModel_OnPropertyChanged;

	        }

	        if (BindingContext is NumbersPickerViewModel)
	        {
	            _viewModel = BindingContext as NumbersPickerViewModel;
	            _viewModel.PropertyChanged += ViewModel_OnPropertyChanged;
	        }
	    }

	    private void ViewModel_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
	    {
	        if (e.PropertyName == "Value")
	        {
	            Value = _viewModel.Value;
	        }
	    }
	}
}
