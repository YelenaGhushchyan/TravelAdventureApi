using System.Linq.Expressions;
using TravelData.Models;

namespace TravelData.Repositories
{
    public interface IRepository
    {
        Task<IEnumerable<Traveler>> GetAllAsync();
        Task<Traveler?> GetByIdAsync(int id);
        Task AddAsync(Traveler traveler);
        Task UpdateAsync(Traveler traveler);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}