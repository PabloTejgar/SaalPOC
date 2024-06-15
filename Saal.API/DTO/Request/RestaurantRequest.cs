namespace Saal.API.DTO.Request
{
    /// <summary>
    /// Restaurant request dto.
    /// </summary>
    public class RestaurantRequest
    {
        /// <summary>
        /// Name field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Address field.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Phone field.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// CityId field.
        /// </summary>
        public int CityId { get; set; }
    }
}
