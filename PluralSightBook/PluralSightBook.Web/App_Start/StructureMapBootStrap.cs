using System;
using System.Data.Entity;
using System.Linq;
using PluralSightBook.Data;
using PluralSightBook.Infrastructure.Data;
using StructureMap;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Infrastructure.NHibernate;
using NHibernate;
using PluralSightBook.Infrastructure.Services;

namespace PluralSightBook.Web.App_Start
{
    public class StructureMapBootStrap
    {
        public static void Configure()
        {
            ObjectFactory.Configure(c =>
            {
                c.Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                    x.AssemblyContainingType<IFriendsService>(); // Core
                    x.AssemblyContainingType<EfFriendRepository>(); // Infrastructure
                    x.AssemblyContainingType<PluralSightBookContext>(); // Data
                });

                // Configure EF
                c.For<DbContext>().HybridHttpOrThreadLocalScoped().Use<PluralSightBookContext>();
                
                // Configure NH
                c.For<ISessionFactory>().Singleton().Use(() => DatabaseConfiguration.CreateSessionFactory());

                // Configure Implementations
                c.For<ISendEmail>().Use<DebugEmailSender>();
                
                // Configure using NH
                //c.For<IQueryUsersByEmail>().Use<NHQueryUsersByEmail>();
                //c.For<IFriendRepository>().Use<NHFriendRepository>();

                // Configure using EF Code First
                c.For<IQueryUsersByEmail>().Use<EfCodeFirstQueryUsersByEmail>();
                c.For<IFriendRepository>().Use<EfCodeFirstFriendRepository>();
                
                // important to set properties on web forms
                c.SetAllProperties(prop =>
                    prop.OfType<IFriendsService>()
                );
            });
        }
    }
}