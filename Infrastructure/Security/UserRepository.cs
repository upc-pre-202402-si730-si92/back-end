using Domain.Learning.Model.Entities;
using Domain.Learning.Repositories;
using Domain.Security.Model.Entities;
using Domain.Security.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.Security;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
}