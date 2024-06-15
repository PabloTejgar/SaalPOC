using Microsoft.AspNetCore.Mvc;
using Saal.API.Models;
using Saal.API.Repository;

namespace Saal.API.Controllers
{
    /// <summary>
    /// Restaurant controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : Controller
    {
        /// <summary>
        /// Repository for restaurant.
        /// </summary>
        private readonly IGenericRepository<Restaurant> _repository;

        /// <summary>
        /// Logger instance.
        /// </summary>
        private readonly ILogger<RestaurantController> _logger;

        /// <summary>
        /// Restaurant controller constructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger">Logger instance.</param>
        public RestaurantController(IGenericRepository<Restaurant> repository, ILogger<RestaurantController> logger)
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

        /// <summary>
        /// Get all restaurants.
        /// </summary>
        /// <response code="200">OK. Returns a restaurant.</response>        
        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<Restaurant>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await _repository.GetAll();

            return Ok(restaurants);
        }

        /// <summary>
        /// Add a new restaurant.
        /// </summary>
        /// <response code="200">OK. Returns a restaurant.</response>        
        [HttpPost("")]
        [ProducesResponseType(typeof(Restaurant), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Add(Restaurant restaurant)
        {
            var addedRestaurant = await _repository.Add(restaurant);

            return Ok(addedRestaurant);
        }

        /// <summary>
        /// Update an existant restaurant.
        /// </summary>
        /// <response code="200">OK. Returns a restaurant.</response>        
        [HttpPut("")]
        [ProducesResponseType(typeof(Restaurant), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Restaurant restaurant)
        {
            var updatedRestaurant = await _repository.Update(restaurant);

            return Ok(updatedRestaurant);
        }

        /// <summary>
        /// Delete a restaurant.
        /// </summary>
        /// <response code="200">OK. Returns a restaurant.</response>        
        [HttpDelete("")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Restaurant restaurant)
        {
            await _repository.Delete(restaurant);

            return Ok();
        }
    }
}
