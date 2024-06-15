﻿using System.ComponentModel.DataAnnotations;

namespace Saal.API.Models
{
    /// <summary>
    /// Model class restaurant.
    /// </summary>
    public class Restaurant : Base
    {
        /// <summary>
        /// Name field.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Address field.
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Phone field.
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// City field.
        /// </summary>
        [Required]
        public string City { get; set; }


    }
}
