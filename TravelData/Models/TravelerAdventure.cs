namespace TravelData.Models;

public class TravelerAdventure
{
    public int TravelerId { get; set; }
    public Traveler? Traveler { get; set; }

    public int AdventurePackageId { get; set; }
    public AdventurePackage? AdventurePackage { get; set; }

    public DateTime BookingDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Booked";
}