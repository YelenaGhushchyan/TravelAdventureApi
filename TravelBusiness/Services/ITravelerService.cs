namespace TravelBusiness.Services;
using TravelData.Models;

public interface ITravelerService
{
    Task<IEnumerable<Traveler>> GetAllAsync();
    Task<Traveler?> GetAsync(int id);
    Task<Traveler> CreateAsync(Traveler t);
    Task<bool> UpdateAsync(int id, Traveler t);
    Task<bool> DeleteAsync(int id);
}