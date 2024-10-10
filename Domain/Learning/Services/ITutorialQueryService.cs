using Domain.Learning.Model.Entities;
using Domain.Learning.Model.Queries;

namespace Domain.Learning.Services;

public interface ITutorialQueryService
{
    Task<List<Tutorial>?> Handle(GetAllTutorialsQuery query);
}