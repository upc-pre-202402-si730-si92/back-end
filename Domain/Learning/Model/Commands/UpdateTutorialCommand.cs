namespace Domain.Learning.Model.Commands;

public record UpdateTutorialCommand(int Id, string Title, string Summary);