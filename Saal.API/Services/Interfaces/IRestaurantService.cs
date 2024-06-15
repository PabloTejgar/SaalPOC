using Saal.API.DTO.Request;

namespace Saal.API.Services.Interfaces
{
    public interface IRestaurantService
    {
        public Task<HttpResponseMessage> Get(int id);
        public Task<HttpResponseMessage> GetAll();
        public Task<HttpResponseMessage> Add(RestaurantRequest entity);
        public Task<HttpResponseMessage> Update(RestaurantRequest entity);
        public Task<HttpResponseMessage> Delete(int id);
    }
}
