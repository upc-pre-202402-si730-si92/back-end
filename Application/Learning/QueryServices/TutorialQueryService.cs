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
        // new TutorialRepository().ListAsync();
        // new TutorialOracleRepository().ListAsync();
        //return    _repository.ListAsync();
        return await _repository.ListAsync();
    }

    public Task<List<Tutorial>?> Handle(GetTutorialByIdQuery query)
    {
        // new TutorialRepository().ListAsync();
        // new TutorialOracleRepository().ListAsync();
        //return    _repository.ListAsync();

        throw new NotImplementedException();
    }
}