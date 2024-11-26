using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Data;  
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers;


public class HomeController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly ApplicationDbContext _context;  
    private readonly ListingProjects _listingProjects;
    
    public HomeController(HttpClient httpClient, ApplicationDbContext context)
    {
        _httpClient = httpClient; 
        _context = context;
    }

    [Authorize]
    public IActionResult Index()
    {
        var portalUserModelRef = _context.UsersDBTable
            .Select(u => new WebApplication1.Models.PortalUsers
            {
                Name = u.Name,
                Age = u.Age,
                Location = u.Location
            }).ToList();

        return View(portalUserModelRef);
    }

    public IActionResult Edit(int? Id)
    {
        var editedUserModelRef = _context.ListingDTO_DBTable.FirstOrDefault(e => e.ListingProjectsFKId == Id);
        if (editedUserModelRef == null)
        {
            // Handle the case where no record is found (e.g., redirect to an error page)
            return NotFound(); // Or implement custom error handling
        }
        ListingProjectsDTO editModel = _context.ListingDTO_DBTable.Find(Id);
        return View(editModel);
    }

    public IActionResult Update(ListingProjectsDTO updatedUserModelRef)
    {
        var oldListingProjects = _context.ListingDTO_DBTable.FirstOrDefault(e => e.ListingProjectsFKId == updatedUserModelRef.ListingProjectsFKId);
        _context.Entry(oldListingProjects).CurrentValues.SetValues(updatedUserModelRef);
        _context.SaveChanges();
        return RedirectToAction("TestDashboard1",updatedUserModelRef);
    }
   
   [HttpGet]
   public IActionResult InsertListings()
   {
       // Create a list with a single new ListingProjectsDTO to initialize the form
       var listings = new List<ListingProjectsDTO>
       {
           new ListingProjectsDTO() // Add an empty DTO for user input
       };

       // Pass the list to the view
       return View(listings);
   }

   [HttpPost]
   [ValidateAntiForgeryToken]
   public async Task<IActionResult> InsertListings(ListingProjectsDTO listingProjectsDto)
   {
       if (ModelState.IsValid)
       {
           try
           {
               // Map the incoming DTO to your entity model
               var addListings = new ListingProjects
               {
                   Id = listingProjectsDto.ListingId,
                   ListingName = listingProjectsDto.ListingName_DTO,
                   // Map other properties as needed
               };

               // Save the entity to the database
               _context.ListingDBTable.Add(addListings);
               await _context.SaveChangesAsync();

               // Retrieve the updated list of listings (including the newly created one)
               var listings = await _context.ListingDBTable
                   .Select(listing => new ListingProjectsDTO
                   {
                       ListingId = listing.Id,
                       ListingName_DTO = listing.ListingName,
                       // Map other properties back to DTO
                   })
                   .ToListAsync();

               // Pass the updated list to the view
               return View("TestDashboard1", listings);
           }
           catch (DbUpdateException ex)
           {
               // Handle database update exception
               ModelState.AddModelError("", "An error occurred while saving the listing.");
           }
       }

       // If we get here, something went wrong; pass the current DTO back to the view
       var fallbackList = new List<ListingProjectsDTO> { listingProjectsDto };
       return View(fallbackList);
   }


    public IActionResult Privacy()
    {
        return View();
    }
   
    
    public async Task<IActionResult> DeleteDetails(int? id, bool? saveChangesError = false)
    {
        if (id == null)
        {
            return NotFound();
        }

        var listingToBeDeleted = await _context.ListingDBTable
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);
        if (listingToBeDeleted == null)
        {
            return NotFound();
        }

        if (saveChangesError.GetValueOrDefault())
        {
            ViewData["ErrorMessage"] =
                "Delete failed. Try again, and if the problem persists " +
                "see your system administrator.";
        }
        ViewData["OKMessage"] =
            "confirm deletion";

        return View(listingToBeDeleted);
    }
    
    [HttpPost, ActionName("DeleteDetails")]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            // Find the listing to be deleted
            var listingToBeDeleted = await _context.ListingDBTable.FindAsync(id);
            if (listingToBeDeleted == null)
            {
                return Json("Not found at all");
            }

            // Delete related entries from ListingDTO_DBTable
            var relatedEntries = await _context.ListingDTO_DBTable
                .Where(dto => dto.ListingProjectsFKId == id) // Compare with the foreign key ID
                .ToListAsync();
            _context.ListingDTO_DBTable.RemoveRange(relatedEntries);

            // Now delete the listing
            _context.ListingDBTable.Remove(listingToBeDeleted);
            await _context.SaveChangesAsync();

            return Json("success!");
        }
        catch (Exception ex)
        {
            return Json("An error occurred: " + ex.Message);
        }
    }
    
    
    
    [AllowAnonymous]

    public async Task<IActionResult> TestDashboard1()
    {
        var datasource = _context.ListingDBTable.AsQueryable();
        var query = datasource
            .Select(x => new ListingProjectsDTO {
                ListingId = x.Id,
                ListingName_DTO = x.ListingName,
            });
        var listings = await query.ToListAsync();

        return View(listings);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
 
}