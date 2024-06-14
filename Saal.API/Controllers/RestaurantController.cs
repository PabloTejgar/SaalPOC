using Microsoft.AspNetCore.Mvc;
using Saal.API.Models;

namespace Saal.API.Controllers
{
    public class RestaurantController : Controller
    {
        /// <summary>
        /// Logger instance.
        /// </summary>
        private readonly ILogger<RestaurantController> _logger;

        /// <summary>
        /// Restaurant controller constructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger">Logger instance.</param>
        public RestaurantController(ILogger<RestaurantController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get restaurant by the id.
        /// </summary>
        /// <param name="code">Restaurant code to get.</param>
        /// <response code="200">OK. Returns a restaurant.</response>        
        /// <response code="404">Not Found. That restaurant doesn't exist.</response>              
        [HttpGet("{code}")]
        [ProducesResponseType(typeof(Restaurant), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
