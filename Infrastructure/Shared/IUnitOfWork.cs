namespace Infrastructure.Shared;

public interface IUnitOfWork
{
    Task CompleteAsync();
}