using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Weather
{
    public partial class CitiesPage : ContentPage
    {
        CitiesViewModel viewModel;

        public CitiesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CitiesViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var city = args.SelectedItem as City;
            if (city == null)
                return;

            await Navigation.PushAsync(new CityDetailPage((city)));

            // Manually deselect item
            CitiesListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        async void Settings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

 
       
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void RemoveItem_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            var city = button?.BindingContext as City;

            var vm = BindingContext as CitiesViewModel;

            vm?.RemoveCommand.Execute(city);
        }

      
        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var city = mi?.BindingContext as City;
            var vm = BindingContext as CitiesViewModel;

            vm?.RemoveCommand.Execute(city);
            
        }
    }
}
