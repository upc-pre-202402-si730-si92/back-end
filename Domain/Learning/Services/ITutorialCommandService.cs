using Domain.Learning.Model.Commands;

namespace Domain.Learning.Services;

public interface ITutorialCommandService
{
    Task<int> Handle(CreateTutorialCommand command);
}