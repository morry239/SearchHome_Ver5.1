using System.Collections;
using Microsoft.Build.Framework;

namespace WebApplication1.Models;

public class ListingProjects : IEnumerable
{
    //public string? inputsToDB { get; set; }
    public int? Id { get; set; }
    
    [Required]
    public string? ListingName { get; set; }
    [Required]
    public string? ImageUrl { get; set; }
    
    //Navigation properties to child model classes
    [Required]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    [Required]
    public int? LocationId { get; set; }
    public Location? Location { get; set; }
    // Implement IEnumerable correctly
    public IEnumerator<ListingProjects> GetEnumerator()
    {
        yield return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}