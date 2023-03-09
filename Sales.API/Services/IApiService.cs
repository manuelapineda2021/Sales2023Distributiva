//service to consume external APIS

using Sales.shared.Responses;

namespace Sales.API.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string servicePrefix, string controller);
    }

}
