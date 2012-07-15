using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using atomicf1.persistence.Mappings;
using NHibernate.Tool.hbm2ddl;

namespace atomicf1.persistence.Tests
{
    public abstract class InMemoryDatabase : IDisposable
    {
        private static Configuration _confiugation;
        private static ISessionFactory _sessionFactory;

        protected ISession Session { get; set; }

        protected InMemoryDatabase()
        {
            _sessionFactory = CreateSessionFactory();
            Session = _sessionFactory.OpenSession();
            BuildSchema(Session);
        }

        private static ISessionFactory CreateSessionFactory()
        {
           
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())         
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CircuitMap>())
                .ExposeConfiguration(cfg => _confiugation = cfg)
                .BuildSessionFactory();
            
        }

        private static void BuildSchema(ISession session)
        {
            SchemaExport export = new SchemaExport(_confiugation);
            export.Execute(true, true, false, session.Connection, null);
        }

        public void Dispose()
        {
            Session.Dispose();
        }
    }
}
