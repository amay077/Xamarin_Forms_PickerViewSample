using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PickerViewSample
{
	public partial class StartPage : ContentPage
	{
		public StartPage()
		{
			InitializeComponent();
		}

	    private void BasicOnClick(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new PickerViewSamplePage());
	    }

	    private void MultiOnClick(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new MultiPickerViewSamplePage());
	    }
	}
}
