using System;

using Xamarin.Forms;

namespace Weather
{
    public partial class CityDetailPage : ContentPage
    {
        City city;
        CityDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public CityDetailPage()
        {
            InitializeComponent();

            city = new City();
            BindingContext = city;
        }

        public CityDetailPage(City city)
        {
            InitializeComponent();
            this.city = city;
            BindingContext = viewModel = new CityDetailViewModel(city);
        }

        async void CheckPast_Days(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PastDays(city));
        }
        async void Forecast(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForecastPage(city));
        }


    }
}
