namespace WebApplication1.Models;

public class ListingProjects
{
    public int? Id { get; set; }
    public string? ListingName { get; set; }
    public string? ImageUrl { get; set; }
    
    //Navigation properties to child model classes
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    public int? LocationId { get; set; }
    public Location? Location { get; set; }
}