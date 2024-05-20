namespace DVar.PList.Domain.Persistence;

public interface IUnitOfWork
{
    Task<bool> CompleteAsync();
    bool HasChanges();
}