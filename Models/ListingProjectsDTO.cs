using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace WebApplication1.Models;

public class ListingProjectsDTO
{
    [System.ComponentModel.DataAnnotations.Key]
    public int? ListingId { get; set; }
    public string? ListingName_DTO { get; set; }
    
    [ForeignKey("ListingProjectsFKId")]
    public int? ListingProjectsFKId { get; set; } 
    
    public ListingProjects? ListingProjectsFK { get; set; }
}