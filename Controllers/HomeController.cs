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

    public IActionResult Privacy()
    {
        return View();
    }
    
    [AllowAnonymous]
    public IActionResult JumpToDashboard()
    {
        var listingUp = _context.ListingDBTable
            .Select(u => new WebApplication1.Models.ListingProjects()
            {
                ListingName = "Keong Saik Road 8",
                ImageUrl = "someurl",
                CategoryId = 1,
                LocationId = 1
            }).ToList();
        //JSON can refer this 
        var listingProject = new ListingProjects
        {
            ListingName = "Keong Saik Road 8",
            ImageUrl = "someurl",
            CategoryId = 1,
            LocationId = 1

        };
        
        //Access category and location information
        var categoryName = new Category
        {
            propertyName = "Holiday Suites",
            propertyType = "hotel establishment"
        };

        var city = new Location
        {
              City = "Venezia",
              State = "Venezia",
              PLZ = "2349890"
        };
        ViewData["PropertyListings"] = listingProject;
        ViewData["ListingCategories"] = categoryName;
        ViewData["Cities"] = city;
        
        //add try catch 
        return View(listingUp);
    }
    
    [AllowAnonymous]
    public async Task<IActionResult> TestDashboard1()
    {
        var datasource= _context.ListingDBTable.AsQueryable();
        var query = datasource.Include(x => x.Location);
        var listings= await query.ToListAsync();

        return View(listings);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}