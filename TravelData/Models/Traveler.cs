using System.ComponentModel.DataAnnotations;

namespace TravelData.Models
{
    public class Traveler
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PassportNumber { get; set; } = null!;
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
        
        public TravelerProfile? Profile { get; set; }
        
        public ICollection<TravelerAdventure> TravelerAdventures { get; set; } = new List<TravelerAdventure>();
    }
    
}
