using System;

namespace Weather
{
    public class CityDetailViewModel : BaseViewModel
    {
        public City Item { get; set; }
        public CityDetailViewModel(City city = null)
        {
            //Title = city.Location.;
            Item = city;
        }
    }
}
