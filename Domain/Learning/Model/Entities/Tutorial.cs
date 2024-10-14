using Domain.Shared.Model.Entities;

namespace Domain.Learning.Model.Entities;

public class Tutorial : ModelBase
{
    public string Title { get; set; }
    public string Summary { get; set; }
}