using CanariaWeb.Models.DTO;

namespace CanariWeb.Services.IServices
{
    public interface IApartmentService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(ApartmentCreateDto dto);
        Task<T> UpdateAsync<T>(ApartmentUpdateDto dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
