using CanariaApi.Models;
using System.Linq.Expressions;

namespace CanariaApi.Repository.Irepository
{
    public interface IApartmentRepository : IRepository<Apartment>
    {
        Task<Apartment> UpdateAsync(Apartment entity);
    }
}
