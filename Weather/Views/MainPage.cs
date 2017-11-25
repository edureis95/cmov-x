using System;

using Xamarin.Forms;

namespace Weather
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page citiesPage, aboutPage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    citiesPage = new NavigationPage(new CitiesPage())
                    {
                        Title = "Cities"
                    };

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    citiesPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    break;
                default:
                    citiesPage = new CitiesPage()
                    {
                        Title = "Cities"
                    };

                    aboutPage = new AboutPage()
                    {
                        Title = "About"
                    };
                    break;
            }

            Children.Add(citiesPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
