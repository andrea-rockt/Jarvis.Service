using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace Jarvis.Service.Domain.DomainModel
{
    public class NhRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly ISession _session;
        public NhRepository(ISession session)
        {
            _session = session;
        }

        public bool Add(TEntity entity)
        {
            _session.Save(entity);
            _session.Flush();
            return true;
        }

        public bool Add(System.Collections.Generic.IEnumerable<TEntity> items)
        {
            foreach (TEntity item in items)
            {
                _session.Save(item);
            }
            return true;
        }

        public bool Update(TEntity entity)
        {
            _session.Update(entity);
            _session.Flush();
            return true;
        }

        public bool AddOrUpdate(TEntity entity)
        {
            _session.SaveOrUpdate(entity);
            _session.Flush();
            return true;
        }

        public bool Delete(TEntity entity)
        {
            _session.Delete(entity);
            _session.Flush();
            return true;
        }

        public bool Delete(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                _session.Delete(entity);
            }
            return true;
        }

        public bool Merge(TEntity entity)
        {
            _session.Merge(entity);
            _session.Flush();
            return true;
        }

        public IQueryable<TEntity> All()
        {
            return _session.Query<TEntity>();
        }

        public TEntity FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression)
        {
            return FilterBy(expression).SingleOrDefault();
        }

        public IQueryable<TEntity> FilterBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression)
        {
            return All().Where(expression).AsQueryable();
        }

        public TEntity FindBy(TKey id)
        {
            return _session.Get<TEntity>(id);
        }



    }
}