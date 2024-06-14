using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Saal.API.Data;
using Saal.API.Models;
using Saal.API.Repository;

namespace Saal.API.Controllers
{
    /// <summary>
    /// Restaurant controller.
    /// </summary>
    public class RestaurantController : Controller
    {
        /// <summary>
        /// Repository for restaurant.
        /// </summary>
        private readonly GenericRepository<Restaurant> _repository;

        /// <summary>
        /// Logger instance.
        /// </summary>
        private readonly ILogger<RestaurantController> _logger;

        /// <summary>
        /// Restaurant controller constructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger">Logger instance.</param>
        public RestaurantController(GenericRepository<Restaurant> repository, ILogger<RestaurantController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Get restaurant by the id.
        /// </summary>
        /// <param name="id">Restaurant id to get.</param>
        /// <response code="200">OK. Returns a restaurant.</response>        
        /// <response code="404">Not Found. That restaurant doesn't exist.</response>              
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Restaurant), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var restaurant = await _repository.GetById(id);
            if (restaurant == null)
            {
                _logger.LogWarning("Restaurant not found.");
                return NotFound();
            }

            return Ok(restaurant);
        }
    }
}
