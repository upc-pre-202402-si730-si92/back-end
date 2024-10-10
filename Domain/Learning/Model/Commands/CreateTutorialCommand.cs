namespace Domain.Learning.Model.Commands;

public record CreateTutorialCommand(string Title, string Summary, int CategoryId);