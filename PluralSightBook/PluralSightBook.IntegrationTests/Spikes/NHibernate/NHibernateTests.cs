using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluralSightBook.Infrastructure.NHibernate;
using NHibernate;
using PluralSightBook.Core.Model;
using PluralSightBook.Data;
using PluralSightBook.IntegrationTests.Spikes.CodeFirst;

namespace PluralSightBook.IntegrationTests.Spikes.NHibernate
{
    [TestClass]
    public class NHibernateTests
    {
        private static ISessionFactory _sessionFactory;

        [ClassInitialize]
        public static void TestRunInitialize(TestContext context)
        {
            _sessionFactory = DatabaseConfiguration.CreateSessionFactory();
        }

        [TestMethod]
        public void ListAllFriendsFromDb()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var friends = session.CreateCriteria(typeof(Friend))
                    .List<Friend>();

                foreach (var friend in friends)
                {
                    Console.WriteLine(friend);
                }
            }
        }

        [TestMethod]
        public void ListAllUsersFromDb()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var users = session.CreateCriteria(typeof(User))
                    .List<User>();

                foreach (var user in users)
                {
                    Console.WriteLine(user);
                }

            }
        }

        [TestMethod]
        public void CreateAndDeleteFriendWithNHRepo()
        {
            var repo = new NHFriendRepository(_sessionFactory);
            string testFriendEmailAddress = Guid.NewGuid().ToString();
            using (var context = new PluralSightBookContext())
            {
                var initializer = new TestDbInitializer();
                initializer.Reseed(context);
                Guid testUserId = context.aspnet_Users
                    .FirstOrDefault(u => u.UserName == TestDbInitializer.TEST_USERNAME)
                    .UserId;

                int initialFriendCount = context.Friends
                    .Count(f => f.UserId == testUserId);

                repo.Create(testUserId, testFriendEmailAddress);
                
                Assert.AreEqual(initialFriendCount + 1,
                    context.Friends.Count(f => f.UserId == testUserId));

                var friends = repo.ListFriendsOfUser(testUserId);
                Assert.AreEqual(friends.Count(), initialFriendCount + 1);

                var friend = _sessionFactory.OpenSession()
                    .QueryOver<Friend>()
                    .Where(f => f.EmailAddress == testFriendEmailAddress)
                    .List()
                    .FirstOrDefault();

                repo.Delete(friend.Id);

                Assert.AreEqual(initialFriendCount, context.Friends.Count());

            }
        }
    }
}