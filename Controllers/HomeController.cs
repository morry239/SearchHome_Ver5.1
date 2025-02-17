using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Data;  
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace WebApplication1.Controllers;

public interface IListingProjectsDtoRepository
{
    ListingProjectsDTO GetListingProjectsDto(int? Id);
    IEnumerable<ListingProjectsDTO> GetAllEmployee();
    //Employee Add(Employee employee);
    ListingProjectsDTO Update(ListingProjectsDTO listingProjectsDtoChanges);
    //Employee Delete(int Id);
}


public class HomeController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly ApplicationDbContext _context;  
    private ListingProjectsDTO _listingProjectsDto;
    private readonly IListingProjectsDtoRepository _listingProjectsDtoRepository;
    
    public HomeController(HttpClient httpClient, ApplicationDbContext context, IListingProjectsDtoRepository listingProjectsDtoRepository)
    {
        _httpClient = httpClient; 
        _context = context;
        _listingProjectsDtoRepository = listingProjectsDtoRepository;
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

    [HttpGet]  
    public JsonResult EditListingJ(int? Id)    //For getting details of the selected User  
    {
        try
        {
            
            ListingProjectsDTO StartEditListing = _context.ListingDTO_DBTable.Find(Id);
            Console.WriteLine("GET success");
            return Json(StartEditListing);
        }
        catch (Exception e)
        {
            return null;
        }
        
    }  
    
    [HttpPost]
    public async Task<JsonResult> EditListingJpost([FromForm] int? Id, [FromForm] string ListingName)
    {
        // Ensure Id is valid and not null
        if (Id == null)
        {
            return Json(new { success = false, message = "Id is required." });
        }

        // Retrieve the listing based on the Id
        var listingToUpdate = await _context.ListingDTO_DBTable.FirstOrDefaultAsync(s => s.Id == Id);
   
        if (listingToUpdate == null)
        {
            return Json(new { success = false, message = "Listing not found." });
        }

        // Update the listing's name
        listingToUpdate.ListingName = ListingName;

        try
        {
            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the updated listing as a JSON response
            return Json(new { success = true, updatedListing = listingToUpdate });
        }
        catch (DbUpdateException)
        {
            // In case of an error, return an error message
            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, contact the system administrator.");
            return Json(new { success = false, message = "Unable to save changes. Please try again later." });
        }
    }
    
    [HttpPost]  
    public JsonResult CreateUser()         //objUser is object which should be same as in javascript function  
    {  
        try  
        {  
             
            _context.ListingDTO_DBTable.Add(_listingProjectsDto);  
            _context.SaveChanges();  
            return Json(_listingProjectsDto);        //returning user to javacript  
              
        }  
        catch (Exception ex)  
        {  
            return null;  
        }  
    }  
   
    public IActionResult Privacy()
    {
        return View();
    }
   
    
    [HttpPost]  
    public JsonResult DeleteUserJ(int Id)  
    {  
        try  
        {  
            var ListingDTO_DBTable = _context.ListingDTO_DBTable.Find(Id);         //fetching the user with Id   
            if (ListingDTO_DBTable != null)  
            {  
                _context.ListingDTO_DBTable.Remove(ListingDTO_DBTable);              //deleting from db  
                _context.SaveChanges();  
                return Json(ListingDTO_DBTable);  
            }  
            return Json(null);  
        }  
  
        catch (Exception ex)  
        {  
            return null;  
        }  
    }  
    
    [AllowAnonymous]

    public async Task<IActionResult> TestDashboard1()
    {
        var datasource = _context.ListingDTO_DBTable.AsQueryable();
        var query = datasource
            .Select(x => new ListingProjectsDTO() {
                Id = x.Id,
                ListingName = x.ListingName,
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