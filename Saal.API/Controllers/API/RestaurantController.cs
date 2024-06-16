using Microsoft.AspNetCore.Mvc;
using Saal.API.DTO.Request;
using Saal.API.DTO.Response;
using Saal.API.Models;
using Saal.API.Services.Interfaces;
using System.Net;
using System.Text.Json;

namespace Saal.API.Controllers.API
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
        private readonly IRestaurantService _service;

        /// <summary>
        /// Logger instance.
        /// </summary>
        private readonly ILogger<RestaurantController> _logger;

        /// <summary>
        /// Restaurant controller constructor.
        /// </summary>
        /// <param name="service">uow implementation for restaurant.</param>
        /// <param name="logger">Logger instance.</param>
        public RestaurantController(IRestaurantService service, ILogger<RestaurantController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Get restaurant by the id.
        /// </summary>
        /// <param name="id">Restaurant id to get.</param>
        /// <response code="200">OK. Returns a restaurant.</response>        
        /// <response code="404">Not Found. That restaurant doesn't exist.</response>              
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RestaurantResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.Get(id);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var content = await result.Content.ReadAsStringAsync();
                var restaurant = JsonSerializer.Deserialize<RestaurantResponse>(content);
                return Ok(restaurant);
            }

            return result.StatusCode switch
            {
                HttpStatusCode.NotFound => NotFound(id),
                _ => StatusCode((int)result.StatusCode, result.Content)
            };
        }

        /// <summary>
        /// Get all restaurants.
        /// </summary>
        /// <response code="200">OK. Returns a restaurant.</response>
        /// <response code="404">Not Found. The set seems to be empty.</response>              
        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<RestaurantResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var content = await result.Content.ReadAsStringAsync();
                var restaurantList = JsonSerializer.Deserialize<IEnumerable<RestaurantResponse>>(content);
                return Ok(restaurantList);
            }

            return result.StatusCode switch
            {
                HttpStatusCode.NotFound => NotFound(result.Content),
                _ => StatusCode((int)result.StatusCode, result.Content)
            };
        }

        /// <summary>
        /// Add a new restaurant.
        /// </summary>
        /// <param name="request">Restaurant request to add.</param>
        /// <response code="200">OK. Returns a restaurant.</response>
        /// <response code="400">Bad Request.</response>        
        /// <response code="404">Not Found.</response>        
        [HttpPost("")]
        [ProducesResponseType(typeof(RestaurantResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(RestaurantRequest request)
        {
            var result = await _service.Add(request);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var content = await result.Content.ReadAsStringAsync();
                var restaurant = JsonSerializer.Deserialize<RestaurantResponse>(content);
                return Ok(restaurant);
            }

            return result.StatusCode switch
            {
                HttpStatusCode.BadRequest => BadRequest(result.Content),
                _ => StatusCode((int)result.StatusCode, result.Content)
            };
        }

        /// <summary>
        /// Update an existant restaurant.
        /// </summary>
        /// <response code="200">OK. Returns a restaurant.</response>
        /// <response code="400">Bad Request.</response>        
        /// <response code="404">Not Found.</response>        
        [HttpPut()]
        [ProducesResponseType(typeof(RestaurantResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(RestaurantRequest request)
        {
            var result = await _service.Update(request);

            if(result.StatusCode == HttpStatusCode.OK)
            {
                var content = await result.Content.ReadAsStringAsync();
                var restaurant = JsonSerializer.Deserialize<RestaurantResponse>(content);
                return Ok(restaurant);
            }

            return result.StatusCode switch
            {
                HttpStatusCode.BadRequest => BadRequest(result.Content),
                HttpStatusCode.NotFound => NotFound(),
                _ => StatusCode((int)result.StatusCode, result.Content)
            };
        }

        /// <summary>
        /// Delete a restaurant.
        /// </summary>
        /// <response code="200">OK. Returns a restaurant.</response>        
        [HttpDelete("")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            return result.StatusCode switch
            {
                HttpStatusCode.NoContent => NoContent(),
                HttpStatusCode.NotFound => NotFound(),
                _ => StatusCode((int)result.StatusCode, result.Content)
            };
        }
    }
}
