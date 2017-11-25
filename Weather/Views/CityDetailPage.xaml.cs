using System;

using Xamarin.Forms;

namespace Weather
{
    public partial class CityDetailPage : ContentPage
    {
        CityDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public CityDetailPage()
        {
            InitializeComponent();

            var city = new City
            {
                Location = "Cidade"
            };

            viewModel = new CityDetailViewModel(city);
            BindingContext = viewModel;
        }

        public CityDetailPage(CityDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
