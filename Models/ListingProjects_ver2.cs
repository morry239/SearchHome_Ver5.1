using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace WebApplication1.Models;

public class ListingProjects_ver2
{
    
    [System.ComponentModel.DataAnnotations.Key]
    [Required]
    public int? Id { get; set; } // Primary key for DTO
    
    [Required]
    public string? ListingName { get; set; } // Mapped from ListingName in ListingProjects

    [Required]
    [NotMapped]
    public IFormFile? ListingImage { get; set; }
}


