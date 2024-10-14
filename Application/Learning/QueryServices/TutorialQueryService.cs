using Domain.Learning.Model.Entities;
using Domain.Learning.Model.Queries;
using Domain.Learning.Services;

namespace Application.Learning.QueryServices;

public class TutorialQueryService : ITutorialQueryService
{
    public Task<List<Tutorial>?> Handle(GetAllTutorialsQuery query)
    {
        throw new NotImplementedException();
    }
}