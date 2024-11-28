using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class ListingProjects
{
    [Key] // Explicitly define the primary key
    public int? Id { get; set; }

    [Microsoft.Build.Framework.Required]
    public string? ListingName { get; set; }

    [Microsoft.Build.Framework.Required]
    public string? ImageUrl { get; set; }

    // Navigation properties to child model classes
    [Microsoft.Build.Framework.Required]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    [Microsoft.Build.Framework.Required]
    public int? LocationId { get; set; }
    public Location? Location { get; set; }
}
