namespace Saal.API.DTO.Request
{
    /// <summary>
    /// Restaurant request dto.
    /// </summary>
    public class RestaurantRequest
    {
        /// <summary>
        /// Nullable id
        /// </summary>
        public int? Id { get; set; }

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
        /// City field.
        /// </summary>
        public int CityId { get; set; }
    }
}
