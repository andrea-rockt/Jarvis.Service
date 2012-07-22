using System;
using System.Linq;
using System.Linq.Expressions;

namespace Jarvis.Service.Domain.DomainModel
{
    public interface IReadOnlyRepository<TEntity,in TKey> where TEntity : class
    {
        IQueryable<TEntity> All();
        TEntity FindBy(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);
        TEntity FindBy(TKey id);
    }
}
