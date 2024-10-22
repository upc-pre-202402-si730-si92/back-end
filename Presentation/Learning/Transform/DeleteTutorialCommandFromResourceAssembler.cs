using Domain.Learning.Model.Commands;
using Presentation.Learning.Resources;

namespace Presentation.Learning.Transform;

public static class DeleteTutorialCommandFromResourceAssembler
{
    public static DeleteTutorialCommand ToCommandFromResource(DeleteTutorialResource resource)
    {
        return new DeleteTutorialCommand(resource.Id);
    }
}