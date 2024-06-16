using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Saal.API.DTO.Response;
using System.Text;
using Saal.API.DTO.Request;
using Saal.API.ViewModel;

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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var restaurantResponse = await _httpClient.GetAsync("https://localhost:5001/Restaurant");
            var cityResponse = await _httpClient.GetAsync("https://localhost:5001/City");

            restaurantResponse.EnsureSuccessStatusCode();
            cityResponse.EnsureSuccessStatusCode();


            var restaurantResponseString = await restaurantResponse.Content.ReadAsStringAsync();
            var cityResponseString = await cityResponse.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            };

            var restaurants = JsonSerializer.Deserialize<List<RestaurantResponse>>(restaurantResponseString, options);
            var cities = JsonSerializer.Deserialize<List<CityResponse>>(cityResponseString, options);

            var viewModel = new RestaurantViewModel
            {
                Restaurants = restaurants,
                Cities = cities
            };


            return View(viewModel);
        }

        /// <summary>
        /// Simple method to add new data.
        /// </summary>
        /// <returns>View restaurant.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(RestaurantRequest restaurant)
        {
            var jsonString = JsonSerializer.Serialize(restaurant);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:5001/Restaurant", content);
            response.EnsureSuccessStatusCode();

            // Optionally: You can check the response to see if the post was successful and handle accordingly

            return RedirectToAction(nameof(Index));
        }
    }
}