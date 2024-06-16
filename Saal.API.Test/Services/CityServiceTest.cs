using AutoMapper;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Saal.API.Models;
using Saal.API.Repository;
using Saal.API.Services;
using System.Net;
namespace Saal.API.Test.Services
{
    public class CityServiceTest
    {
        private CityService _service;
        private IGenericRepository<City> repository;

        [SetUp]
        public void Init()
        {
            repository = Substitute.For<IGenericRepository<City>>();
            var mapper = Substitute.For<IMapper>();
            _service = new CityService(repository, mapper);
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
