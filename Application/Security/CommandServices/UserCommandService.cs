using System.Runtime.CompilerServices;
using Domain.Security.Model.Commands;
using Domain.Security.Model.Entities;
using Domain.Security.Repositories;
using Domain.Security.Services;
using Domain.Shared;

namespace Application.Security.CommandServices;

public class UserCommandService : IUserCommandService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEncryptService _encryptService;

    public UserCommandService(IUserRepository userRepository,IUnitOfWork unitOfWork,IEncryptService encryptService)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _encryptService = encryptService;
    }
    
    public Task<(User user, string token)> Handle(SignInCommand command)
    {
        throw new NotImplementedException();
    }

    public async Task Handle(SignUpCommand command)
    {
        try
        {
            var user = new User
            {
                Username = command.Username,
                PasswordHash = _encryptService.Encrypt(command.Password),
                Role = command.Role
            };

            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            throw ;
        }
    }
}