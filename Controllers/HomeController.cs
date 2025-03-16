using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using JsonException = Newtonsoft.Json.JsonException;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    
    private readonly ApplicationDbContext _context;
    private ListingProjects_ver2 _listingProjectsDto;
    
    private readonly string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//searchHomeMisc");

    public HomeController(ApplicationDbContext context)
    {
        
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

    [HttpGet]
    public JsonResult EditListingJ(int? Id)    //For getting details of the selected User  
    {
        try
        {

            ListingProjects_ver2 StartEditListing = _context.ListingVer2_DBTable.Find(Id);
            Console.WriteLine("GET success");
            return Json(StartEditListing);
        }
        catch (Exception e)
        {
            return null;
        }

    }

    [HttpPost]
    public async Task<JsonResult> EditListingJpost([FromForm] int Id, [FromForm] string ListingName, [FromForm] IFormFile ListingImage)
    {
        Console.WriteLine($"Received Id: {Id}, ListingName: {ListingName}");

        var listingToUpdate = await _context.ListingVer2_DBTable.FirstOrDefaultAsync(s => s.Id == Id);

        if (listingToUpdate == null)
        {
            return Json(new { success = false, message = "Listing not found." });
        }

        if (await TryUpdateModelAsync<ListingProjects_ver2>(listingToUpdate, "", s => s.ListingName))
        {
            try
            {
                
                await _context.SaveChangesAsync();
                return Json(new { success = true, updatedListing = listingToUpdate });
            }
            catch (DbUpdateException)
            {
                return Json(new { success = false, message = "Unable to save changes." });
            }
        }

        return Json(listingToUpdate);
    }

    [HttpPost]
    public async Task <JsonResult> CreateUser([Bind("ListingName")]ListingProjects_ver2 obModel, IFormFile file) 
    {
        try
        {
            if (obModel.Id == null)
            {
                if (obModel.ListingName == null)
                {
                    Console.WriteLine("nullcheck");
                    return Json(obModel,  new JsonException());
                }
                
                //assign each listing a photo
                if (file != null)
                {
                    var path =  Path.Combine(rootPath, Guid.NewGuid() + Path.GetExtension(file.FileName));
                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(fs);
                    }
                }
                _context.ListingVer2_DBTable.Add(obModel);
                Console.WriteLine($"if name is null {obModel.ListingName}");
                _context.SaveChanges();
                
                return Json(obModel);
            }
            else
            {
                _context.ListingVer2_DBTable.Update(_listingProjectsDto);
            }
            return Json(obModel);
            
        }catch (Exception ex)
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
            var ListingDTO_DBTable = _context.ListingVer2_DBTable.Find(Id);         //fetching the user with Id   
            if (ListingDTO_DBTable != null)
            {
                _context.ListingVer2_DBTable.Remove(ListingDTO_DBTable);              //deleting from db  
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
        var datasource = _context.ListingVer2_DBTable.AsQueryable();
        var query = datasource
            .Select(x => new ListingProjects_ver2()
            {
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

    [HttpGet]
    public async Task<IActionResult> TestDatabaseConnection()
    {
        try
        {
            // Attempt to retrieve all records from the ListingDTO_DBTable
            var listings = await _context.ListingVer2_DBTable.ToListAsync();

            if (listings != null && listings.Any())
            {
                return Json(new { success = true, message = "Connection successful.", data = listings });
            }
            else
            {
                return Json(new { success = true, message = "Connection successful, but no data found." });
            }
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = $"Connection failed: {ex.Message}" });
        }
    }
}