namespace Saal.API.Services.Interfaces
{
    public interface ICityService
    {
        public Task<HttpResponseMessage> Get(int id);
        public Task<HttpResponseMessage> GetAll();
    }
}
