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

		private async void BasicOnClick(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new PickerViewSamplePage());
	    }

		private async void MultiOnClick(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new MultiPickerViewSamplePage());
	    }
	}
}
