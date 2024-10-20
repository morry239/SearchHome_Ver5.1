using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models;

public class PortalUsers : IdentityUser
{
    public String? Name { get; set; }
    public int? Age { get; set; }
    public String? Location { get; set; }
    

    public String? DisplayInfo => "Name: " + Name + " Age: " + Age + " Location: " + Location;
}