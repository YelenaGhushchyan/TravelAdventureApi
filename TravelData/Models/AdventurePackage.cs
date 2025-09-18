namespace TravelData.Models;

public class AdventurePackage
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Destination { get; set; } = null!;
    public decimal Price { get; set; }
    public int DurationInDays { get; set; }

    
    public int GuideId { get; set; }
    public Guide? Guide { get; set; }
    
    public ICollection<TravelerAdventure> TravelerAdventures { get; set; } = new List<TravelerAdventure>();
}