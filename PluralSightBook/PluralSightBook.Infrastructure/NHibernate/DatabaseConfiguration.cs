using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Diagnostics;
using System.Linq;

namespace PluralSightBook.Infrastructure.NHibernate
{
    public class DatabaseConfiguration
    {
        public static ISessionFactory CreateSessionFactory()
        {
            Debug.Print("CreateSessionFactory()");
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(c => c.FromConnectionStringWithKey("PluralSightBookContext")))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<DatabaseConfiguration>())
                .BuildSessionFactory();
        }
    }
}
