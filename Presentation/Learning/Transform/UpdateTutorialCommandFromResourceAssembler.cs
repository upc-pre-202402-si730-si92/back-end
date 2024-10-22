using Domain.Learning.Model.Commands;
using Presentation.Learning.Resources;

namespace Presentation.Learning.Transform;

public static class UpdateTutorialCommandFromResourceAssembler
{
    public static UpdateTutorialCommand ToCommandFromResource(int id, UpdateTutorialResource resource)
    {
        return new UpdateTutorialCommand(id, resource.Title, resource.Summary);
    }
}