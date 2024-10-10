using Domain.Learning.Model.Commands;
using Domain.Learning.Services;

namespace Application.Security.CommandServices;

public class TutorialCommandService : ITutorialCommandService
{
    public Task<int> Handle(CreateTutorialCommand command)
    {
        throw new NotImplementedException();
    }
}