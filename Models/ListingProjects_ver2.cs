
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class ListingProjects_ver2
{
    
    [Key]
    [Required]
    public int? Id { get; set; } // Primary key for DTO
    
    [Required]
    public string? ListingName { get; set; } // Mapped from ListingName in ListingProjects
    
    public string? ListingImgName { get; set; }
}


