using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class ListingDtoEditClass
{
    [Key]
    [Required]
    public int? ListingIdToBeEdited { get; set; }
    [Required]
    [Display(Name = "Edit the listing now!")]
    public string? ListingNameToBeEdited { get; set; }
}

