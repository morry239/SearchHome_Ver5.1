using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Data;

public class DataSeed
{
    private static ApplicationDbContext _context;

    public DataSeed(ApplicationDbContext context)
    {
        _context = context;
    }

    public void SeedModels()
    {
        SeedListings();
        SeedUsers();
    }

    public static void SeedListings()
    {
        if (!_context.ListingDBTable.Any())
        {
            IEnumerable<ListingProjects> newListings = new List<ListingProjects>()
            {
                new ListingProjects()
                {
                    ListingName = "Potato Head Rooftop",
                    ImageUrl = "someurl",
                    Category = new Category()
                    {
                        propertyName = "rooftop1",
                        propertyType = "bars"
                    }, 
                    Location = new Location()
                    {
                        City = "Singapore",
                        State = "Singapore",
                        PLZ = "1293890"
                    } //also here too simple
                },
                
            };

            _context.ListingDBTable.AddRange(newListings);
            _context.SaveChanges();
        }
    }

    public static void SeedUsers()
    {
        if (!_context.UsersDBTable.Any())
        {
            IEnumerable<PortalUsers> arzte = new List<PortalUsers>()
            {
                new PortalUsers()
                {
                    Name = "Heo Yeon Woo",
                    Age = 13,
                    Location = "The hidden moon palace"
                },
                new PortalUsers()
                {
                    Name = "Lee Hwon",
                    Age = 15,
                    Location = "The eastern palace, crown prince's residence"
                }
            };

            _context.UsersDBTable.AddRange(arzte);
            _context.SaveChanges();
        }
    }

}