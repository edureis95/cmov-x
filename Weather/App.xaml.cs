using System;

using Xamarin.Forms;

namespace Weather
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = false;
        public static string BackendUrl = "https://api.apixu.com";
        public static bool IsCelsius = true;
        public static bool IsKph = true;

        public App()
        {
            SettingsViewModel settingsView = new SettingsViewModel();
            IsCelsius = settingsView.settings.Find(pair => pair.Key == "celcius").Value;
            IsKph = settingsView.settings.Find(pair => pair.Key == "kph").Value;
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else{
                DependencyService.Register<CloudDataStore>();
            }
                

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());
        }
    }
}
