using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Models;
public class ListingProjects
{
    [Key]
    public int? Id { get; set; } // Primary key

    [Required]
    public string? ListingName { get; set; }

    //[Required]
    //public string? ImageUrl { get; set; }

    [Required]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    [Required]
    public int? LocationId { get; set; }
    public Location? Location { get; set; }

    //public ListingProjects_ver2? ListingProjectsDTO { get; set; } // Navigation property
}