using Domain.Security.Model.Commands;
using Presentation.Security.Resources;

namespace Presentation.Security.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password, resource.Role);
    }
}