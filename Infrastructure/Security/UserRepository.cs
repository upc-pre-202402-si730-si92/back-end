using Domain.Learning.Model.Entities;
using Domain.Learning.Repositories;
using Domain.Security.Model.Entities;
using Domain.Security.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Security;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public  async Task<User?> FindByusername(string username)
    {
        return await context.Users.FirstOrDefaultAsync(u=> u.Username == username);
    }
}