using TravelData.Models;

namespace TravelData;


public class TravelerProfile
{
    public int TravelerId { get; set; } 
    public DateTime? BirthDate { get; set; }
    public string MedicalNotes { get; set; } = string.Empty;
    public string Preferences { get; set; } = string.Empty;

    public Traveler? Traveler { get; set; }

}
