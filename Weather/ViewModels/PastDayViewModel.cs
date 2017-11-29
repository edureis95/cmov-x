using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Weather
{
    public class PastDayViewModel : BaseViewModel
    {
        public ObservableCollection<PastDay> PastDay { get; set; }
        public Command LoadItemsCommand { get; set; }

        public City city;
        public PastDay pastday { get; set; }



        public PastDayViewModel(City city)
        {
            Title = "Past Day";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(city));

        }


        async Task ExecuteLoadItemsCommand(City city)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            IsNotBusy = false;

            try
            {
                DateTime enteredDate = DateTime.ParseExact(city.date, "MM/dd/yyyy HH:mm:ss", null);   
                pastday = await DataStore.GetCityAsync(city.Location.Name, enteredDate.ToString("yyyy-MM-dd"));
                OnPropertyChanged("pastday");
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