using AutoMapper;
using Azure.Core;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Saal.API.DTO.Request;
using Saal.API.Models;
using Saal.API.Repository;
using Saal.API.Services;
using System.Net;

namespace Saal.API.Test.Services
{
    [TestFixture]
    public class RestaurantServiceTest
    {
        private RestaurantService _service;
        private IGenericRepository<Restaurant> repository;
        private IGenericRepository<City> cityRepo;

        [SetUp]
        public void Init()
        {
            repository = Substitute.For<IGenericRepository<Restaurant>>();
            cityRepo = Substitute.For<IGenericRepository<City>>();
            var mapper = Substitute.For<IMapper>();
            _service = new RestaurantService(repository, cityRepo, mapper);
        }

        [TestCase("", "", "", 0,ExpectedResult = HttpStatusCode.BadRequest)]
        [TestCase("test", "", "", 0, ExpectedResult = HttpStatusCode.BadRequest)]
        [TestCase("test", "test", "", 0, ExpectedResult = HttpStatusCode.BadRequest)]
        [TestCase("test", "test", "test", 0, ExpectedResult = HttpStatusCode.BadRequest)]
        public HttpStatusCode WhenAnIncorrectRequestIsUsedWithAddThenWeGetABadRequest(string name, string address, string phone, int cityId)
        {
            var request = new RestaurantRequest()
            {
                Name = name,
                Address = address,
                Phone = phone,
                CityId = cityId
            };

            var response = _service.Add(request);
            return response.Result.StatusCode; 
        }

        [TestCase(null, "", "", "", 0, ExpectedResult = HttpStatusCode.BadRequest)]
        [TestCase(1, "test", "", "", 0, ExpectedResult = HttpStatusCode.BadRequest)]
        [TestCase(1, "test", "test", "", 0, ExpectedResult = HttpStatusCode.BadRequest)]
        [TestCase(1, "test", "test", "test", 0, ExpectedResult = HttpStatusCode.BadRequest)]
        public HttpStatusCode WhenAnIncorrectRequestIsUsedWithUpdateThenWeGetABadRequest(int? id, string name, string address, string phone, int cityId)
        {
            var request = new RestaurantRequest()
            {
                Name = name,
                Address = address,
                Phone = phone,
                CityId = cityId
            };

            var response = _service.Update(request);
            return response.Result.StatusCode;
        }

        [Test]
        public void WhenTheIdIsNotFoundInGetMethodThenWeGetANotFound()
        {
            repository.GetById(1).ReturnsNull();
            var response = _service.Get(1);
            Assert.That(response.Result.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void WhenTheSetIsEmptyInGetAllMethodThenWeGetANotFound()
        {
            repository.GetAll().ReturnsNull();
            var response = _service.GetAll();
            Assert.That(response.Result.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}
