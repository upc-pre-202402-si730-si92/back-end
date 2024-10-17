using Domain.Learning.Model.Commands;
using Domain.Learning.Model.Entities;
using Domain.Learning.Repositories;
using Domain.Learning.Services;
using Domain.Shared;

namespace Application.Learning.CommandServices;

public class TutorialCommandService : ITutorialCommandService
{
    private readonly ITutorialRepository _tutorialRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TutorialCommandService(ITutorialRepository tutorialRepository, IUnitOfWork unitOfWork)
    {
        _tutorialRepository = tutorialRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<int> Handle(CreateTutorialCommand command)
    {
        var tutorial = new Tutorial()
        {
            Title = command.Title,
            Summary = command.Summary
        };
        //if (tutorial.Quantity > 10) throw new Exception("Quantity must be less tha 10");
        await _tutorialRepository.AddAsync(tutorial);
        await _unitOfWork.CompleteAsync();
        return tutorial.Id;
    }
}