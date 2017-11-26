using System;

using Xamarin.Forms;

namespace Weather
{
    public partial class CityDetailPage : ContentPage
    {
        City viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public CityDetailPage()
        {
            InitializeComponent();

            viewModel = new City();
            BindingContext = viewModel;
        }

        public CityDetailPage(City viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
