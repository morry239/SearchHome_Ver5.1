using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace WebApplication1.Models;

public class ListingProjectsDTO
{
    [System.ComponentModel.DataAnnotations.Key]
    public int? ListingId { get; set; } // Primary key for DTO

    public string? ListingName_DTO { get; set; } // Mapped from ListingName in ListingProjects

    [ForeignKey(nameof(ListingProjectsFK))] // Reference to ListingProjects' primary key
    public int? ListingProjectsFKId { get; set; } // Foreign key

    public ListingProjects? ListingProjectsFK { get; set; } // Navigation property
}
