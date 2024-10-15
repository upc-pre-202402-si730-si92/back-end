using System.ComponentModel.DataAnnotations;
using Domain.Shared.Model.Entities;

namespace Domain.Learning.Model.Entities;

public class Tutorial : ModelBase
{
    [MaxLength(25)] //Data Annotations
    [Required]
    public string Title { get; set; }
    public string Summary { get; set; }
}