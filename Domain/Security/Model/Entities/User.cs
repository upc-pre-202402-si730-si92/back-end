using Domain.Shared.Model.Entities;

namespace Domain.Security.Model.Entities;

public class User : ModelBase
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
}