using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForecastPage : ContentPage
	{
        ForecastViewModel viewModel;

		public ForecastPage ()
		{
			InitializeComponent ();
		}

        public ForecastPage(City city)
        {
            InitializeComponent();

            BindingContext = viewModel = new ForecastViewModel(city);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadItemsCommand.Execute(null);

        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var city = args.SelectedItem as Forecastday;
            if (city == null)
                return;

            await Navigation.PushAsync(new ChartPage((city)));

            // Manually deselect item
            CitiesListView.SelectedItem = null;
        }
    }
}