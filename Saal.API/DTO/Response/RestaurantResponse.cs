using System.Text.Json.Serialization;

namespace Saal.API.DTO.Response
{
    /// <summary>
    /// Restaurant response dto.
    /// </summary>
    public class RestaurantResponse
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
        public string City { get; set; }
    }
}
