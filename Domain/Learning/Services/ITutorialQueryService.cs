using Domain.Learning.Model.Entities;
using Domain.Learning.Model.Queries;

namespace Domain.Learning.Services;

public interface ITutorialQueryService
{
    Task<IEnumerable<Tutorial>?> Handle(GetAllTutorialsQuery query); //signature
}