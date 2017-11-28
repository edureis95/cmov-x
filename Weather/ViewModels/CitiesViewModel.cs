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

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var _city = item as Item;
                //Cities.Add(_city);
                await DataStore.AddCityAsync(_city);

            });
        }

        public Command<City> RemoveCommand
        {
            get
            {
                return new Command<City>((City) =>
                {
                    Cities.Remove(City);
                    DataStore.removeItemById(City.Location.Name);
                });
            }
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
           

                foreach (var city in cities)
                {
                 
                    Cities.Add(city);
                }
                
                
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
