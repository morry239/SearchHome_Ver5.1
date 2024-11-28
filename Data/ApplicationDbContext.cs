using System.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class ApplicationDbContext : IdentityDbContext<PortalUsers>
{
    public ApplicationDbContext(){}
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public Microsoft.EntityFrameworkCore.DbSet<PortalUsers> UsersDBTable { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Category> CategoriesDBTable { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<ListingProjects> ListingDBTable { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Location> LocationDBTable { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<ListingProjectsDTO> ListingDTO_DBTable { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ListingProjectsDTO>()
            .HasOne(dto => dto.ListingProjectsFK)
            .WithMany() // Assuming no reverse navigation from ListingProjects
            .HasForeignKey(dto => dto.ListingProjectsFKId);
    }

    
}