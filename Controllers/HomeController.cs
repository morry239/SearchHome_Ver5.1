using System.Diagnostics;
using System.Text;
using System.Web;
//using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using FileStreamResult = Microsoft.AspNetCore.Mvc.FileStreamResult;
using HtmlHelper = Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper;
using JsonException = Newtonsoft.Json.JsonException;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace WebApplication1.Controllers;

//https://stackoverflow.com/questions/67321945/upload-image-and-show-that-in-asp-net-core-mvc
//https://stackoverflow.com/questions/17952514/asp-net-mvc-how-to-display-a-byte-array-image-from-model
//check this one OUT FIRST https://stackoverflow.com/questions/73877029/image-upload-function-in-crud
//check out https://learn.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-9.0
//https://wordpress.stackexchange.com/questions/367293/image-upload-via-formdata-api-and-ajax-is-not-working-files-always-emptyk

public class HomeController : Controller
{
    
    private readonly ApplicationDbContext _context;
    private ListingProjects_ver2 _listingProjectsDto;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ILogger<HomeController> _logger;
    
    private readonly string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//searchHomeMisc");

    public HomeController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, ILogger<HomeController> logger)
    {
        _logger = logger;
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    [Microsoft.AspNetCore.Authorization.Authorize]
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
    public async Task<JsonResult> EditListingJpost([FromForm] int Id, [FromForm] string ListingName)
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
        
        var validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
            .SelectMany(E => E.Errors)
            .Select(E => E.ErrorMessage)
            .ToList();

        foreach (var validationErrStr in validationErrors)
        {
            Console.WriteLine($"what is the error about {validationErrStr}");
        }
        return Json(listingToUpdate);
    }
    
    /*
     * you have a static string in your html that displays the image,
     * if you want it dynamic you have to upload it store the web path in your table
     * so you can perform the other ops if so desired 
     */

    [HttpPost]
    public async Task <JsonResult> CreateUser([Bind("ListingName","Id","ListingImgName")]ListingProjects_ver2 obModel) 
    {
        try
        {
            //TODO: Mami muss die bedingung nochmal anpassen!!!!!
            if (true)
            {
                
                if (obModel.ListingName == null)
                {
                    return new JsonResult(Problem());
                }

                obModel.Id = null;
                
                _context.ListingVer2_DBTable.Add(obModel);
                byte[] bytesListingImageName = Encoding.ASCII.GetBytes(obModel.ListingImgName);
                Upload(bytesListingImageName);
                //OnPostUploadAsync(files);
                _logger.LogError("log the errors");
                
                _context.SaveChanges();
                
                
                //return Json(obModel, fileName); 
                return Json(obModel);
            }
            else
            {
                _context.ListingVer2_DBTable.Update(_listingProjectsDto);
            }
            
            return Json(obModel);
            
        }catch (Exception ex)
        {
            Console.WriteLine($"you got an exception {ex}");
            return Json(obModel);
        }
    }
    [HttpPost("Upload/{id}"), DisableRequestSizeLimit]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Upload(byte[] imageName)
    {
        try
        {
            //TODO: ImageName in die Datenbank abspeichern
            Console.WriteLine($"ImageName ist {imageName}");
            string imageBase64Data = Convert.ToBase64String(imageName);
            string imageData = string.Format("data:image/jpg;base64, {0}", imageBase64Data);

            _listingProjectsDto.ListingImgName = imageData;
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
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
 

    [Microsoft.AspNetCore.Authorization.AllowAnonymous]
    public async Task<IActionResult> TestDashboard1()
    {
            
            var datasource = _context.ListingVer2_DBTable.AsQueryable();
            var query = datasource
                .Select(x => new ListingProjects_ver2()
                {
                    Id = x.Id,
                    ListingName = x.ListingName,
                    ListingImgName = x.ListingImgName
                   
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
