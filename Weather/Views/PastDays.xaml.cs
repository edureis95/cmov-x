using System;
using Xamarin.Forms;

namespace Weather
{

	public partial class PastDays : ContentPage
	{
        City city;

        public PastDays ()
		{
			InitializeComponent ();
            city = new City();
            this.city.date = DateTime.Now.ToString("yyyy-MM-dd");
            this.city.mindate = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            BindingContext = this.city; 
        }

        public PastDays(City city)
        {
            InitializeComponent();
            this.city = city;
            this.city.date = DateTime.Now.ToString("yyyy-MM-dd");
            this.city.mindate = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            BindingContext = this.city;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoPastDays(city));
        }
    
      
    }
}