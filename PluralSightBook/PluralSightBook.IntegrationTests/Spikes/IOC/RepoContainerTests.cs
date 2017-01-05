using System;
using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluralSightBook.Data.Models;
using PluralSightBook.IntegrationTests.Spikes.CodeFirst;
using StructureMap;
using PluralSightBook.Infrastructure.Data;
using System.Data.Entity;
using PluralSightBook.Data;

namespace PluralSightBook.IntegrationTests.Spikes.IOC
{
    [TestClass]
    public class RepoContainerTests : BaseTransactionalTestClass
    {
        [ClassInitialize]
        public static void TestRunInitialize(TestContext context)
        {
            ObjectFactory.Configure(c =>
            {
                c.Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                    x.AssemblyContainingType<EfFriendRepository>();
                });
                c.For<DbContext>().HybridHttpOrThreadLocalScoped()
                    .Use<PluralSightBookContext>();
            });
        }

        [TestMethod]
        public void DeleteFriendUsingGenericRepoAndIoC()
        {
            var context = ObjectFactory.TryGetInstance<DbContext>() as PluralSightBookContext;
            var initializer = new TestDbInitializer();
            initializer.Reseed(context);

            int friendCount = context.Friends.Count();
            var testUserId = context.aspnet_Users
                .FirstOrDefault(u => u.UserName == TestDbInitializer.TEST_USERNAME)
                .UserId;

            var repo = new Repositories.Repository<Friend>(context);
            var friend = new Friend()
            {
                UserId = testUserId,
                EmailAddress = "somebody@somewhere.com"
            };
            repo.Add(friend);
            repo.Save();

            var anotherContext = ObjectFactory.TryGetInstance<DbContext>() as PluralSightBookContext;
            var repo2 = new Repositories.Repository<Friend>(anotherContext);
            repo2.Remove(friend);
            repo2.Save();

            Assert.AreEqual(friendCount, context.Friends.Count());
        }
    }
}