namespace Domain.Shared.Model.Entities;

public class ModelBase
{
    public int Id { get; set; }

    public int CreatedUser { get; set; }

    public int? UpdatedUser { get; set; }

    public DateTime CreatedDate { get; set; }

    // public DateTime? UpdatedDate { get; set; }

    public bool IsActive { get; set; }
}