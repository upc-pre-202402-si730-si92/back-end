namespace Domain.Security.Model.Commands;

public record SignUpCommand(string Username, string Password, string Role);