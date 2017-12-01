using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Weather
{
    public class ForecastViewModel : BaseViewModel
    {
        public ObservableCollection<ForecastJson> Forecasts { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ForecastJson forecast { get; set; }



        public ForecastViewModel(City city)
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(city));
            IsFah = !App.IsCelsius;
            IsCelsius = App.IsCelsius;
            IsMph = !App.IsKph;
            IsKph = App.IsKph;
        }


        async Task ExecuteLoadItemsCommand(City city)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            IsNotBusy = false;

            try
            {
                forecast = await DataStore.GetForecast(city.Location.Name+","+city.Location.Region+","+city.Location.Country);
                OnPropertyChanged("forecast");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
                IsNotBusy = true;
            }
        }
    }
}