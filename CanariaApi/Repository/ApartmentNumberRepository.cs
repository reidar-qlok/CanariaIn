using CanariaApi.Data;
using CanariaApi.Models;
using CanariaApi.Repository.Irepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CanariaApi.Repository
{
    public class ApartmentNumberRepository : Repository<ApartmentNumber>, IApartmentNumberRepository
    {
        private readonly ApplicationDbContext _Db;
        public ApartmentNumberRepository(ApplicationDbContext context):base(context)
        {
            _Db = context;
        }
        public async Task<ApartmentNumber> UpdateAsync(ApartmentNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _Db.ApartmentNumbers.Update(entity);
            await _Db.SaveChangesAsync();
            return entity;
        }
    }
}
