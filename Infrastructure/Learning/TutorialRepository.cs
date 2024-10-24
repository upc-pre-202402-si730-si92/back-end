using Domain.Learning.Model.Entities;
using Domain.Learning.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Learning;

public class TutorialRepository(AppDbContext context) : BaseRepository<Tutorial>(context), ITutorialRepository
{
    public async Task<Tutorial?> FindByTitleAsync(string title)
    {
        return await context.Tutorials.Where(t => t.Title == title).FirstOrDefaultAsync();
    }
}