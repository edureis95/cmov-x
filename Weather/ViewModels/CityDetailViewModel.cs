using System;

namespace Weather
{
    public class CityDetailViewModel : BaseViewModel
    {
        public City city { get; set; }
        public CityDetailViewModel(City city = null)
        {
            IsFah = !App.IsCelsius;
            IsCelsius = App.IsCelsius;
            IsMph = !App.IsKph;
            IsKph = App.IsKph;
            //Title = city.Location.;
            this.city = city;
        }
    }
}
