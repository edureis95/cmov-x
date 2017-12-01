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
	public partial class SettingsPage : ContentPage
	{
        SettingsViewModel viewModel;
		public SettingsPage ()
		{
			InitializeComponent ();
            viewModel = new SettingsViewModel();
            celcius.On = viewModel.GetSettingsValueByName("celcius");
            fahrenheit.On = viewModel.GetSettingsValueByName("fahrenheit");
            kph.On = viewModel.GetSettingsValueByName("kph");
            mph.On = viewModel.GetSettingsValueByName("mph");
		}

        public void clickedCelcius(object sender, EventArgs e)
        {
            if (celcius.On)
            {
                fahrenheit.On = false;
                viewModel.ChangeSettingsValueByName("celcius", true);
                viewModel.ChangeSettingsValueByName("fahrenheit", false);
                viewModel.SaveSettings();
                App.IsCelsius = true;

            }
            else
            {
                fahrenheit.On = true;
                viewModel.ChangeSettingsValueByName("celcius", false);
                viewModel.ChangeSettingsValueByName("fahrenheit", true);
                viewModel.SaveSettings();
                App.IsCelsius = false;
            }
        }

        public void clickedFahrenheit(object sender, EventArgs e)
        {
            if (fahrenheit.On)
            {
                celcius.On = false;
                viewModel.ChangeSettingsValueByName("celcius", false);
                viewModel.ChangeSettingsValueByName("fahrenheit", true);
                viewModel.SaveSettings();
                App.IsCelsius = false;
            }
            else
            {
                celcius.On = true;
                viewModel.ChangeSettingsValueByName("celcius", true);
                viewModel.ChangeSettingsValueByName("fahrenheit", false);
                viewModel.SaveSettings();
                App.IsCelsius = true;
            }
        }

        public void clickedKph(object sender, EventArgs e)
        {
            if (kph.On)
            {
                mph.On = false;
                viewModel.ChangeSettingsValueByName("mph", false);
                viewModel.ChangeSettingsValueByName("kph", true);
                viewModel.SaveSettings();
                App.IsKph = true;
            }
            else
            {
                mph.On = true;
                viewModel.ChangeSettingsValueByName("mph", true);
                viewModel.ChangeSettingsValueByName("kph", false);
                viewModel.SaveSettings();
                App.IsKph = false;
            }
        }

        public void clickedMph(object sender, EventArgs e)
        {
            if (mph.On)
            {
                kph.On = false;
                viewModel.ChangeSettingsValueByName("mph", true);
                viewModel.ChangeSettingsValueByName("kph", false);
                viewModel.SaveSettings();
                App.IsKph = false;
            }
            else
            {
                kph.On = true;
                viewModel.ChangeSettingsValueByName("mph", false);
                viewModel.ChangeSettingsValueByName("kph", true);
                viewModel.SaveSettings();
                App.IsKph = true;
            }
        }
	}
}