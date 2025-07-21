
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using MessagePack;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;


public class ListingProjects_ver2
{

    [System.ComponentModel.DataAnnotations.Key] [Required] public int? Id { get; set; } // Primary key for DTO

    [Required] public string? ListingName { get; set; } // Mapped from ListingName in ListingProjects

    public byte[]? ListingImgName { get; set; }
    
    [NotMapped]
    public IFormFile? ListingImgNameRichtig { get; set; }

    public string? ListingReview { get; set; }
}


