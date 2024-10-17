using Domain.Learning.Model.Entities;
using Domain.Learning.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Learning;

public class TutorialRepository(AppDbContext context) : BaseRepository<Tutorial>(context), ITutorialRepository
{


    public Task<Tutorial?> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Tutorial entity)
    {
        throw new NotImplementedException();
    }

    public void Remove(Tutorial entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Tutorial>> ListAsync()
    {
        return await context.Tutorials.ToListAsync();
        // ORM
        //Select * from Tutorial
    }
}