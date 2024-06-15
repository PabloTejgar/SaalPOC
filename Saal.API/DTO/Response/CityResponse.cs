using Saal.API.Models;

namespace Saal.API.DTO.Response
{
    /// <summary>
    /// City response dto.
    /// </summary>
    public class CityResponse
    {
        /// <summary>
        /// Id field.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Restaurants field.
        /// </summary>
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
