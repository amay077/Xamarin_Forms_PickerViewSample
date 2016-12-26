using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PickerViewSample
{
	public partial class PickerViewSamplePage : ContentPage
	{
		public PickerViewSamplePage()
		{
			InitializeComponent();

		    //picker1.ItemsSource = new[] { 0, 1, 2 };
		}

	    protected override async void OnAppearing()
	    {
	        base.OnAppearing();

	        await Task.Delay(3000);

			//picker1.ItemsSource = new[] { "xxx", "yyy", "aaa", "vvv", "eee" };

	    }
	}
}
