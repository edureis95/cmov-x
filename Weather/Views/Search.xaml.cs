
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchView : ContentPage
	{

        SearchViewModel viewModel;
        public SearchView ()
		{
			InitializeComponent ();
		}


        public SearchView(Item item)
        {
            InitializeComponent();

            BindingContext = viewModel = new SearchViewModel(item);
        }
    

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var city = args.SelectedItem as SearchModel;
            if (city == null)
                return;

            Item item = new Item();
            item.Description = city.Name;

             MessagingCenter.Send(this, "AddItem", item);
             await Navigation.PopToRootAsync();
      
        }




        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadItemsCommand.Execute(null);
        }
    }
}