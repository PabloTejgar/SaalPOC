using Saal.API.DTO.Response;

namespace Saal.API.ViewModel
{
    public class RestaurantViewModel
    {
        /// <summary>
        /// Restaurants property for view model.
        /// </summary>
        public IEnumerable<RestaurantResponse> Restaurants { get; set; }

        /// <summary>
        /// Cities property for view model.
        /// </summary>
        public IEnumerable<CityResponse> Cities { get; set; }
    }
}
