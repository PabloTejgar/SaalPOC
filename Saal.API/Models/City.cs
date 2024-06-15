using System.ComponentModel.DataAnnotations;

namespace Saal.API.Models
{
    public class City: Base
    { 

    /// <summary>
    /// Name field.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Restaurants field.
    /// </summary>
    public ICollection<City> Restaurants { get; set; }

    }
}
