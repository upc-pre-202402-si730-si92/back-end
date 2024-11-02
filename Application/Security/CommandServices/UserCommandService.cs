using System.Runtime.CompilerServices;
using Domain.Security.Model.Commands;
using Domain.Security.Model.Entities;
using Domain.Security.Repositories;
using Domain.Security.Services;
using Domain.Shared;

namespace Application.Security.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork, IEncryptService encryptService)
    : IUserCommandService
{
    public Task<(User user, string token)> Handle(SignInCommand command)
    {
  throw new NotImplementedException();
    }

    public async Task Handle(SignUpCommand command)
    {
        var user = new User
        {
            Username = command.Username,
            PasswordHash = encryptService.Encrypt(command.Password),
            Role = command.Role
        };

        await userRepository.AddAsync(user);
        await unitOfWork.CompleteAsync();
    }
}