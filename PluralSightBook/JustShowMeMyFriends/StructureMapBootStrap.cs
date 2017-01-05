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
using JustShowMeMyFriends.WebApiServices;
using System.Net.Http;

namespace JustShowMeMyFriends
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
                });

                // Configure WebAPI
                c.For<HttpClient>().Singleton().Use(() => ApiConfig.GetClient());

                // Configure Implementations
                c.For<ISendEmail>().Use<DebugEmailSender>();
                c.For<IUserService>().Use<WebApiUserService>();
                c.For<IFriendsService>().Use<WebApiFriendsService>();
            });
        }
    }
}