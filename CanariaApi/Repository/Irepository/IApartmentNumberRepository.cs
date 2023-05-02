using CanariaApi.Models;
using System.Linq.Expressions;

namespace CanariaApi.Repository.Irepository
{
    public interface IApartmentNumberRepository : IRepository<ApartmentNumber>
    {
        Task<ApartmentNumber> UpdateAsync(ApartmentNumber entity);
    }
}
