using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : DomainObject<TKey>
    {
        TEntity GetById(TKey id);

        IEnumerable<TEntity> GetAll();

        void Save(TEntity entity);

        void SaveAll(IEnumerable<TEntity> entityBatch);

        void Delete(TEntity entity);
    }    
}
