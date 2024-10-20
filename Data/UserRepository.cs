namespace WebApplication1.Data;
using Models;

public class UserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<PortalUsers> GetAllUsers()
    {
        return _dbContext.Users.ToList();
    }

    // Add other methods like CreateUser, UpdateUser, DeleteUser, etc.
}