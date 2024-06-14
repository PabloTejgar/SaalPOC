using System.ComponentModel.DataAnnotations;

namespace Saal.API.Models
{
    /// <summary>
    /// Model class restaurant.
    /// </summary>
    public class Restaurant
    {
        /// <summary>
        /// Id key.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name field.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// City field.
        /// </summary>
        [Required]
        public string City { get; set; }


    }
}
