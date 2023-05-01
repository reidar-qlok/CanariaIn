using CanariaApi.Data;
using CanariaApi.Models;
using CanariaApi.Repository.Irepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CanariaApi.Repository
{
    public class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {
        private readonly ApplicationDbContext _Db;
        public ApartmentRepository(ApplicationDbContext context):base(context)
        {
            _Db = context;
        }
        public async Task<Apartment> UpdateAsync(Apartment entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _Db.Apartments.Update(entity);
            await _Db.SaveChangesAsync();
            return entity;
        }
    }
}
