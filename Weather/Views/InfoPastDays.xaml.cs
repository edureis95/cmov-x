using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InfoPastDays : ContentPage
	{

        PastDayViewModel viewModel;
        Boolean isBusy;

    
        public InfoPastDays ()
		{
			InitializeComponent ();
		}

        public InfoPastDays(City city)
        {
            InitializeComponent();
            isBusy = false;
            BindingContext = viewModel = new PastDayViewModel(city);
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();


            viewModel.LoadItemsCommand.Execute(null);
       
        }


        async public void click_view_details(){
            await Navigation.PushAsync(new ChartPage(viewModel));
        }


    }
}