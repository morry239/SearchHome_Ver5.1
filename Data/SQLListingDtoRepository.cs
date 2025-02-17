using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class SQLListinDtoRepository : IListingProjectsDtoRepository
{
    private readonly ApplicationDbContext context;
    private IListingProjectsDtoRepository _listingProjectsDtoRepositoryImplementation;

    public SQLListinDtoRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public ListingProjectsDTO Add(ListingProjectsDTO employee)
    {
        context.ListingDTO_DBTable.Add(employee);
        context.SaveChanges();
        return employee;
    }

    public ListingProjectsDTO Delete(int Id)
    {
        ListingProjectsDTO employee = context.ListingDTO_DBTable.Find(Id);
        if (employee != null)
        {
            context.ListingDTO_DBTable.Remove(employee);
            context.SaveChanges();
        }
        return employee;
    }

    public ListingProjectsDTO getListingProjectsDto(int? Id)
    {
        return context.ListingDTO_DBTable.Find(Id);
    }

    public ListingProjectsDTO GetListingProjectsDto(int? Id)
    {
        return context.ListingDTO_DBTable.Find(Id);
    }

    IEnumerable<ListingProjectsDTO> IListingProjectsDtoRepository.GetAllEmployee()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ListingProjectsDTO> GetAllEmployee()
    {
        return context.ListingDTO_DBTable;
    }

    public ListingProjectsDTO GetEmployee(int Id)
    {
        return context.ListingDTO_DBTable.Find(Id);
    }

    public ListingProjectsDTO Update(ListingProjectsDTO employeeChanges)
    {
        var employee = context.ListingDTO_DBTable.Attach(employeeChanges);
        employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        context.SaveChanges();
        return employeeChanges;
    }
}