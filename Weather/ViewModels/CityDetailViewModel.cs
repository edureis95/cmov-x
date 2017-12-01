using System;

namespace Weather
{
    public class CityDetailViewModel : BaseViewModel
    {
        public City city { get; set; }
        public CityDetailViewModel(City city = null)
        {
            //Title = city.Location.;
            this.city = city;
        }
    }
}
