namespace TravelData.Models;

public class Guide
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Languages { get; set; } = string.Empty;

    public ICollection<AdventurePackage> AdventurePackages { get; set; } = new List<AdventurePackage>();
}