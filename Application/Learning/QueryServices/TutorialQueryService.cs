using Domain.Learning.Model.Entities;
using Domain.Learning.Model.Queries;
using Domain.Learning.Repositories;
using Domain.Learning.Services;

namespace Application.Learning.QueryServices;

public class TutorialQueryService : ITutorialQueryService
{
    private readonly ITutorialRepository _repository;

    public TutorialQueryService(ITutorialRepository repository)
    {
        _repository = repository;
    }

    //overload
    public async Task<IEnumerable<Tutorial>?> Handle(GetAllTutorialsQuery query)
    {
        return await _repository.ListAsync();
    }

    public async Task<Tutorial?> Handle(GetTutorialByIdQuery query)
    {
        return await _repository.FindByIdAsync(query.Id);
    }
}