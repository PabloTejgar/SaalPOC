using System.ComponentModel.DataAnnotations;

namespace Saal.API.Models
{
    public class Base
    {
        /// <summary>
        /// Id field.
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
