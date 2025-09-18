using TravelData.Models;
using TravelData.Repositories;

namespace TravelBusiness.Services
{
    public class TravelerService : ITravelerService
    {
        private readonly IRepository _repo;
        public TravelerService(IRepository repo) => _repo = repo;

        public async Task<Traveler> CreateAsync(Traveler t)
        {
            if(string.IsNullOrWhiteSpace(t.Email)) throw new ArgumentException("Email required");
            await _repo.AddAsync(t);
            await _repo.SaveChangesAsync();
            return t;
        }

        public async Task<IEnumerable<Traveler>> GetAllAsync() => await _repo.GetAllAsync();
        public async Task<Traveler?> GetAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task<bool> UpdateAsync(int id, Traveler t)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            existing.FullName = t.FullName;
            existing.Email = t.Email;
            existing.PassportNumber = t.PassportNumber;

            await _repo.UpdateAsync(existing);
            await _repo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}