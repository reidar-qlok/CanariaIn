using Canaria_Utility;
using CanariaWeb.Models.DTO;
using CanariWeb.Models;
using CanariWeb.Services.IServices;
using Newtonsoft.Json.Linq;

namespace CanariWeb.Services
{
    public class ApartmentService : BaseService, IApartmentService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string apartmentUrl = "";

        public ApartmentService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            apartmentUrl = configuration.GetValue<string>("ServiceUrls:CanariaApi");

        }
        public Task<T> CreateAsync<T>(ApartmentCreateDto dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST, // static details
                Data = dto,
                Url = apartmentUrl + "/api/canariaApi" //controller namn i apiet
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = apartmentUrl + "/api/canariaApi/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = apartmentUrl + "/api/canariaApi"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = apartmentUrl + "/api/canariaApi/" + id
            });
        }

        public Task<T> UpdateAsync<T>(ApartmentUpdateDto dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = apartmentUrl + "/api/canariaApi/" + dto.ApartmentId
            });
        }
    }
}
