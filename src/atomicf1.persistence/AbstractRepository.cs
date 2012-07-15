using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.common;
using atomicf1.domain;
using atomicf1.domain.Repositories;
using NHibernate;

namespace atomicf1.persistence
{
    public abstract class AbstractRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : DomainObject<TKey> 
    {
        protected static ISession GetSession()
        {
            return SessionProvider.SessionFactory.OpenSession();
        }

        #region IRepository<TEntity,TKey> Members
        

        public TEntity GetById(TKey id)
        {
 	        using (var session = GetSession()) {
 	            return session.Get<TEntity>(id);
 	        }
        }

        public IEnumerable<TEntity> GetAll()
        {
 	        using (var session = GetSession()) {
 	            ICriteria criteria = session.CreateCriteria(typeof (TEntity));
 	            return criteria.List<TEntity>();
 	        }
        }

        public void  Save(TEntity entity)
        {
            using (var session = GetSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);

                    trans.Commit();
                    
                    CacheHelper.InvalidateAll();
                }

            }
        }

        public void SaveAll(IEnumerable<TEntity> entityBatch)
        {
            using (var session = GetSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    foreach(var entity in entityBatch)
                        session.SaveOrUpdate(entity);

                    trans.Commit();

                    CacheHelper.InvalidateAll();
                }

            }
        }

        public void  Delete(TEntity entity)
        {
            using (var session = GetSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    session.Delete(entity);

                    trans.Commit();

                    CacheHelper.InvalidateAll();
                }

            }
        }

        #endregion
    }    
}
