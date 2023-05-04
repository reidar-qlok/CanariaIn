using CanariaWeb.Models;
using CanariWeb.Models;

namespace CanariWeb.Services.IServices
{
    public interface IBaseService
    {
        ApiResponse responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
