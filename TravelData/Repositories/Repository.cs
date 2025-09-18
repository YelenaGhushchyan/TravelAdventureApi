using Microsoft.EntityFrameworkCore;
using TravelData.Data;
using TravelData.Models;

using System.Linq.Expressions;

namespace TravelData.Repositories
{
    public class Repository : IRepository
    {
        private readonly TravelDbContext _db;
        public Repository(TravelDbContext db) => _db = db;

        public async Task<IEnumerable<Traveler>> GetAllAsync() =>
            await _db.Travelers.Include(t => t.Profile).ToListAsync();

        public async Task<Traveler?> GetByIdAsync(int id) =>
            await _db.Travelers.Include(t => t.Profile).FirstOrDefaultAsync(t => t.Id == id);

        public async Task AddAsync(Traveler traveler) => await _db.Travelers.AddAsync(traveler);
        public async Task UpdateAsync(Traveler traveler) => _db.Travelers.Update(traveler);
        public async Task DeleteAsync(int id)
        {
            var traveler = await _db.Travelers.FindAsync(id);
            if (traveler != null) _db.Travelers.Remove(traveler);
        }
        public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
    }
}