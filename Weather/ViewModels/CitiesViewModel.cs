using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Weather
{
    public class CitiesViewModel : BaseViewModel
    {
        public ObservableCollection<City> Cities { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CitiesViewModel()
        {
            Title = "Cities";
            Cities = new ObservableCollection<City>();

            //CARREGA DOS ITEMS PARA A LISTA
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, City>(this, "AddItem", async (obj, city) =>
            {
                var _city = city as City;
                Cities.Add(_city);
                await DataStore.AddCityAsync(_city);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Cities.Clear();
                var cities = await DataStore.GetCityAsync(true);
                /*foreach (var city in cities)
                {
                    Cities.Add(city);
                }*/
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
