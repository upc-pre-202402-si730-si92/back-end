using System.ComponentModel.DataAnnotations;

namespace Presentation.Learning.Resources;

public record CreateTutorialResource(
    [Required]
    [MinLength(3)]
    [MaxLength(10)]
    string Title,
    [Required]
    [MinLength(10)]
    [MaxLength(25)]
    string Summary);

/*{
    public string Title { get; set; }
    public string Summary { get; set; }
}*/