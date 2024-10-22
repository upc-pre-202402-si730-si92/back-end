namespace Domain.Learning.Model.Commands;

public record UpdateTutorialCommand(int id, string Title, string Summary);