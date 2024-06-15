using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saal.API.Models;
using Saal.API.Repository;

namespace Saal.API.Controllers.API
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : Controller
    {
        /// <summary>
        /// Repository for city.
        /// </summary>
        private readonly IGenericRepository<City> _repository;

        /// <summary>
        /// Logger instance.
        /// </summary>
        private readonly ILogger<CityController> _logger;

        /// <summary>
        /// City controller constructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger">Logger instance.</param>
        public CityController(IGenericRepository<City> repository, ILogger<CityController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Get city by the id.
        /// </summary>
        /// <param name="id">City id to get.</param>
        /// <response code="200">OK. Returns a city.</response>        
        /// <response code="404">Not Found. That city doesn't exist.</response>              
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(City), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var city = await _repository.GetById(id);
            if (city == null)
            {
                _logger.LogWarning("City not found.");
                return NotFound();
            }

            return Ok(city);
        }

        /// <summary>
        /// Get all restaurants.
        /// </summary>
        /// <response code="200">OK. Returns a restaurant.</response>        
        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<City>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _repository.GetAll();

            return Ok(cities);
        }
    }
}
