using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluralSightBook.Infrastructure.Data;
using System.Transactions;

namespace PluralSightBook.IntegrationTests.Infrastructure.Data
{
    [TestClass]
    public class EfFriendRepository_CreateShould
    {
        [TestMethod]
        public void AddRecord()
        {
            Guid testUserId;
            using (var context = new aspnetdbEntities())
            {
                testUserId = context.aspnet_Membership.First().UserId;
            }

            var friendRepository = new EfFriendRepository();
            var testEmail = Guid.NewGuid().ToString();

            friendRepository.Create(testUserId, testEmail);

            using (var context = new aspnetdbEntities())
            {
                bool friendExists = context.Friends.Any(f => f.UserId == testUserId && f.EmailAddress == testEmail);
                Assert.IsTrue(friendExists);

                context.DeleteObject(context.Friends.FirstOrDefault(f => f.UserId == testUserId && f.EmailAddress == testEmail));
                context.SaveChanges();
            }
        }
    }
    [TestClass]
    public class EfFriendRepositoryWithTransaction_CreateShould
    {
        private TransactionScope scope = null;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            scope = new TransactionScope(TransactionScopeOption.RequiresNew,
                new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted
                });
        }

        [TestCleanup]
        public virtual void TestCleanup()
        {
            if (scope != null)
            {
                scope.Dispose();
                scope = null;
            }
        }

        [TestMethod]
        public void AddRecordTx()
        {
            Guid testUserId;
            using (var context = new aspnetdbEntities())
            {
                testUserId = context.aspnet_Membership.First().UserId;
            }

            var friendRepository = new EfFriendRepository();
            var testEmail = Guid.NewGuid().ToString();

            friendRepository.Create(testUserId, testEmail);

            using (var context = new aspnetdbEntities())
            {
                bool friendExists = context.Friends.Any(f => f.UserId == testUserId && f.EmailAddress == testEmail);
                Assert.IsTrue(friendExists);

                //context.DeleteObject(context.Friends.FirstOrDefault(f => f.UserId == testUserId && f.EmailAddress == testEmail));
                //context.SaveChanges();
            }
        }
    }
}
