using Microsoft.AspNetCore.Mvc;
using Saal.API.DTO.Response;
using Saal.API.Models;
using Saal.API.Services.Interfaces;
using System.Net;
using System.Text.Json;

namespace Saal.API.Controllers.API
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : Controller
    {
        /// <summary>
        /// Service for city.
        /// </summary>
        private readonly ICityService _service;

        /// <summary>
        /// Logger instance.
        /// </summary>
        private readonly ILogger<CityController> _logger;

        /// <summary>
        /// City controller constructor.
        /// </summary>
        /// <param name="service">City service.</param>
        /// <param name="logger">Logger instance.</param>
        public CityController(ICityService service, ILogger<CityController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Get city by the id.
        /// </summary>
        /// <param name="id">City id to get.</param>
        /// <response code="200">OK. Returns a city.</response>        
        /// <response code="404">Not Found. That city doesn't exist.</response>              
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.Get(id);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var content = await result.Content.ReadAsStringAsync();
                var city = JsonSerializer.Deserialize<CityResponse>(content);
                return Ok(city);
            }

            return result.StatusCode switch
            {
                HttpStatusCode.NotFound => NotFound(id),
                _ => StatusCode((int)result.StatusCode, result.Content)
            };
        }

        /// <summary>
        /// Get all cities.
        /// </summary>
        /// <response code="200">OK. Returns a list of cities.</response>        
        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<CityResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();

            if (result.StatusCode == HttpStatusCode.OK)
            {
                var content = await result.Content.ReadAsStringAsync();
                var cityList = JsonSerializer.Deserialize<IEnumerable<CityResponse>>(content);
                return Ok(cityList);
            }

            return result.StatusCode switch
            {
                HttpStatusCode.NotFound => NotFound(),
                _ => StatusCode((int)result.StatusCode, result.Content)
            };
        }
    }
}
