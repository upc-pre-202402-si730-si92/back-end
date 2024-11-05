using System.Data;
using System.Runtime.CompilerServices;
using Domain.Security.Model.Commands;
using Domain.Security.Model.Entities;
using Domain.Security.Repositories;
using Domain.Security.Services;
using Domain.Shared;

namespace Application.Security.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork, IEncryptService encryptService,ITokenService tokenService)
    : IUserCommandService
{
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var existinguser = await userRepository.FindByusername(command.Username);
    
        if (existinguser == null) 
            throw new DataException("Invalid password or username");
    
        var isValidPassword = encryptService.Verify(command.Password, existinguser.PasswordHash);
    
        if (!isValidPassword) 
            throw new DataException("Invalid password or username");
    
        var token = tokenService.GenerateToken(existinguser);

        return (existinguser, token);
        
        
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