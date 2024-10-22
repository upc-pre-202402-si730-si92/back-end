using Domain.Learning.Model.Commands;
using Presentation.Learning.Resources;

namespace Presentation.Learning.Transform;

public static class CreateTutorialCommandFromResourceAssembler
{
    public static CreateTutorialCommand ToCommandFromResource(CreateTutorialResource resource)
    {
        return new CreateTutorialCommand(resource.Title, resource.Summary);
    }
}