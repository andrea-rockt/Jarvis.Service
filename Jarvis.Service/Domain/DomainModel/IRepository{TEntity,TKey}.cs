namespace Jarvis.Service.Domain.DomainModel
{
    public interface IRepository<TEntity, in TKey> : IPersistRepository<TEntity>, IReadOnlyRepository<TEntity,TKey> where TEntity : class
    {
    }
}
