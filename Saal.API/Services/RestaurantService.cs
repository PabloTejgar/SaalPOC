using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Saal.API.Controllers.API;
using Saal.API.DTO.Request;
using Saal.API.DTO.Response;
using Saal.API.Models;
using Saal.API.Repository;
using Saal.API.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace Saal.API.Services
{
    /// <summary>
    /// Service for Restaurant Operations.
    /// </summary>
    public class RestaurantService : IRestaurantService
    {
        /// <summary>
        /// Repository for restaurant.
        /// </summary>
        private readonly IGenericRepository<Restaurant> _repository;

        /// <summary>
        /// City service for city operations.
        /// </summary>
        private readonly IGenericRepository<City> _cityRepository;

        /// <summary>
        /// Automapper.
        /// </summary>
        private readonly IMapper _automapper;

        /// <summary>
        /// Restaurant service constructor.
        /// </summary>
        /// <param name="repository">Generic repository of restaurant.</param>
        /// <param name="cityService">City service.</param>
        /// <param name="autoMapper">Automapper.</param>
        public RestaurantService(IGenericRepository<Restaurant> repository, IGenericRepository<City> cityRepo, IMapper autoMapper)
        {
            _repository = repository;
            _cityRepository = cityRepo;
            _automapper = autoMapper;
        }

        /// <summary>
        /// Add service method to validate entity before calling repository.
        /// </summary>
        /// <param name="entity"></param>
        public async Task<HttpResponseMessage> Add(RestaurantRequest entity)
        {
            var validation = ValidateEntity(entity);
            if(validation.StatusCode != HttpStatusCode.OK)
            {
                return validation;
            }

            var entityToAdd = _automapper.Map<Restaurant>(entity);
            var entityAdded = await _repository.Add(entityToAdd);
            var response = _automapper.Map<RestaurantResponse>(entityAdded);
            var city = await _cityRepository.GetById(entityAdded.CityId);
            response.City = city.Name;

            return new HttpResponseMessage()
            {
                Content = new ObjectContent<RestaurantResponse>(response, new JsonMediaTypeFormatter()),
                StatusCode = HttpStatusCode.OK,
            };
        }

        /// <summary>
        /// Update service method to validate entity before calling repository.
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        public async Task<HttpResponseMessage> Update(RestaurantRequest entity)
        {
            if(entity.Id == null)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Entity ID cannot be null for update method."),
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            var validation = ValidateEntity(entity);

            if (validation.StatusCode != HttpStatusCode.OK)
            {
                return validation;
            }

            var entityToAdd = _automapper.Map<Restaurant>(entity);
            var entityAdded = await _repository.Update(entityToAdd);
            var restaurantResponse = _automapper.Map<RestaurantResponse>(entityAdded);
            var city = await _cityRepository.GetById(entityAdded.CityId);
            restaurantResponse.City = city.Name;

            return new HttpResponseMessage()
            {
                Content = new ObjectContent<RestaurantResponse>(restaurantResponse, new JsonMediaTypeFormatter()),
                StatusCode = HttpStatusCode.OK,
            };
        }

        /// <summary>
        /// Delete service method to validate entity before calling repository.
        /// </summary>
        /// <param name="id">Entity id to delete.</param>
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var entityToDelete = await _repository.GetById(id);
            if(entityToDelete == null)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Entity not found"),
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            await _repository.Delete(entityToDelete);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Get service method to validate entity before calling repository.
        /// </summary>
        /// <param name="id">Entity id to get.</param>
        public async Task<HttpResponseMessage> Get(int id)
        {
            var entity = await _repository.GetById(id);
            if(entity == null)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Entity not found."),
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            var restaurantResponse = _automapper.Map<RestaurantResponse>(entity);
            var city = await _cityRepository.GetById(entity.CityId);
            restaurantResponse.City = city.Name;

            return new HttpResponseMessage()
            {
                Content = new ObjectContent<RestaurantResponse>(restaurantResponse, new JsonMediaTypeFormatter()),
                StatusCode = HttpStatusCode.OK,
            };
        }

        /// <summary>
        /// Get service method to validate entity before calling repository.
        /// </summary>
        public async Task<HttpResponseMessage> GetAll()
        {
            var listOfEntity = await _repository.GetAll();
            var cities = await _cityRepository.GetAll();

            if (listOfEntity == null)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Sets not found."),
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            List<RestaurantResponse> restaurantlistResponse = new List<RestaurantResponse>();
            foreach (var restaurant in listOfEntity)
            {
                var restaurantResponse = _automapper.Map<RestaurantResponse>(restaurant);
                var city = cities.FirstOrDefault(c => c.Id == restaurant.CityId);
                restaurantResponse.City = city.Name;
                restaurantlistResponse.Add(restaurantResponse);
            }

            return new HttpResponseMessage()
            {
                Content = new ObjectContent<IEnumerable<RestaurantResponse>>(restaurantlistResponse, new JsonMediaTypeFormatter()),
                StatusCode = HttpStatusCode.OK,
            };
        }

        /// <summary>
        /// Validate entity method.
        /// </summary>
        /// <param name="entity">Restaurant request entity.</param>
        /// <returns>HttpResponseMessage</returns>
        private HttpResponseMessage ValidateEntity(RestaurantRequest entity)
        {
            if (entity == null)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Entity cannot be null"),
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
            if (entity.Name.IsNullOrEmpty())
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Entity name cannot be null"),
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            if (entity.Address.IsNullOrEmpty())
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Entity address cannot be null"),
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            if (entity.Phone.IsNullOrEmpty())
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Entity phone cannot be null"),
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            if (!int.TryParse(entity.Phone, out int aux))
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Entity phone needs to be a number"),
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
