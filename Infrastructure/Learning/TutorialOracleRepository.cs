using Domain.Learning.Model.Entities;
using Domain.Learning.Repositories;
using Infrastructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;

namespace Infrastructure.Learning;

public class TutorialOracleRepository :  ITutorialRepository
{
    public Task AddAsync(Tutorial entity)
    {
        throw new NotImplementedException();
    }

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

    public Task<IEnumerable<Tutorial>> ListAsync()
    {
        throw new NotImplementedException();
    }
}