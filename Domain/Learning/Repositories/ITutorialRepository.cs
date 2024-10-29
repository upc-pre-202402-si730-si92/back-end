using Domain.Learning.Model.Entities;
using Domain.Shared;

namespace Domain.Learning.Repositories;

public interface ITutorialRepository : IBaseRepository<Tutorial>
{
    public Task<Tutorial?> FindByTitleAsync(string title);
}