using Domain.Shared.Model.Entities;

namespace Domain.Learning.Model.Entities;

public class Section : ModelBase
{
    public Tutorial Tutorial { get; set; }
    public int TutorialId { get; set; }
}