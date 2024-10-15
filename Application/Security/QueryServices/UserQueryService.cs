using System.Collections;
using Domain.Learning.Model.Entities;
using Domain.Learning.Model.Queries;
using Domain.Learning.Services;

namespace Application.Security.QueryServices;

public class UserQueryService : ITutorialQueryService
{
    public Task<IEnumerable<Tutorial?>> Handle(GetAllTutorialsQuery query)
    {
        throw new NotImplementedException();
    }
}