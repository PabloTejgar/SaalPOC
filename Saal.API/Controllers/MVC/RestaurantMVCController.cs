using Microsoft.AspNetCore.Mvc;
using Saal.API.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Saal.API.Controllers.Mvc
{
    public class RestaurantMvcController : Controller
    {
        /// <summary>
        /// Http Client.
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Restaurant MVC Controller constructor.
        /// </summary>
        /// <param name="httpClient">http client instance.</param>
        public RestaurantMvcController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Simple method to retrieve data.
        /// </summary>
        /// <returns>View restaurant.</returns>
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:5001/Restaurant");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var restaurants = JsonSerializer.Deserialize<IEnumerable<Restaurant>>(responseString);

            return View(restaurants);
        }
    }
}