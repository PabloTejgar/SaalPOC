using NuGet.Protocol.Core.Types;
using Saal.API.DTO.Response;
using System.Net.Http.Formatting;
using System.Net;
using AutoMapper;
using Saal.API.Models;
using Saal.API.Repository;

namespace Saal.API.Services
{
    public class CityService
    {
        /// <summary>
        /// Repository for city.
        /// </summary>
        private readonly IGenericRepository<City> _repository;

        /// <summary>
        /// Automapper.
        /// </summary>
        private readonly IMapper _automapper;

        /// <summary>
        /// City service constructor.
        /// </summary>
        /// <param name="repository">Generic repository of restaurant.</param>
        public CityService(IGenericRepository<City> repository, IMapper autoMapper)
        {
            _repository = repository;
            _automapper = autoMapper;
        }

        /// <summary>
        /// Get service method to validate entity before calling repository.
        /// </summary>
        /// <param name="id">Entity id to get.</param>
        public async Task<HttpResponseMessage> Get(int id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Entity not found."),
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            var cityResponse = _automapper.Map<CityResponse>(entity);

            return new HttpResponseMessage()
            {
                Content = new ObjectContent<CityResponse>(cityResponse, new JsonMediaTypeFormatter()),
                StatusCode = HttpStatusCode.OK,
            };
        }

        /// <summary>
        /// Get service method to validate entity before calling repository.
        /// </summary>
        public async Task<HttpResponseMessage> GetAll()
        {
            var listOfEntity = await _repository.GetAll();
            if (listOfEntity == null)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Sets not found."),
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            var citylistResponse = _automapper.Map<IEnumerable<CityResponse>>(listOfEntity);

            return new HttpResponseMessage()
            {
                Content = new ObjectContent<IEnumerable<CityResponse>>(citylistResponse, new JsonMediaTypeFormatter()),
                StatusCode = HttpStatusCode.OK,
            };

        }
    }
}
