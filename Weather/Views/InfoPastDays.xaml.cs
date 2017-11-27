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

    
        public InfoPastDays ()
		{
			InitializeComponent ();
		}

        public InfoPastDays(City city)
        {
            InitializeComponent();
 
            BindingContext = viewModel = new PastDayViewModel(city);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadItemsCommand.Execute(null);

        }


    }
}