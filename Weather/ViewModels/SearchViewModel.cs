using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Weather
{
    public class SearchViewModel : BaseViewModel
    {
        public ObservableCollection<SearchModel> Results { get; set; }
        public Command LoadItemsCommand { get; set; }

     
      
        public SearchViewModel(Item item)
        {
            Title = "Past Day";
            Results = new ObservableCollection<SearchModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(item));
            
            
        }
 

        async Task ExecuteLoadItemsCommand(Item item)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Results.Clear();
                var cities = await DataStore.Search(item.Description);
                foreach (var city in cities)
                {

                    Results.Add(city);
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
