using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluralSightBook.Infrastructure.Data;
using PluralSightBook.Core.Model;
using PluralSightBook.IntegrationTests.Spikes.CodeFirst;
using PluralSightBook.Data;

namespace PluralSightBook.IntegrationTests.Spikes.ActiveRecord
{
    [TestClass]
    public class ActiveRecordTests : BaseTransactionalTestClass
    {
        [TestInitialize]
        public void SetUp()
        {
            using (var context = new PluralSightBookContext())
            {
                var initializer = new TestDbInitializer();
                initializer.Reseed(context);
            }
        }

        [TestMethod]
        public void CanCreateNewFriend()
        {
            Guid testUserId;
            using (var context = new aspnetdbEntities())
            {
                testUserId = context.aspnet_Membership.FirstOrDefault().UserId;
            }
            //var friend = ActiveRecordFriend.CreateNew("steve@foo.com", Guid.Empty); FK violation
            var friend = ActiveRecordFriend.CreateNew("steve@foo.com", testUserId);

            Assert.IsNotNull(friend);
        }

        [TestMethod]
        public void CanCreateExistingFriend()
        {
            Guid testUserId;
            using (var context = new aspnetdbEntities())
            {

                testUserId = context.aspnet_Membership.FirstOrDefault().UserId;
            }
            var friend = ActiveRecordFriend.CreateNew("steve@foo.com", testUserId);

            var secondFriend = new ActiveRecordFriend(friend.Id);

            Assert.IsNotNull(secondFriend);
        }

        [TestMethod]
        public void CanSaveChangesToFriend()
        {
            Guid testUserId;
            using (var context = new aspnetdbEntities())
            {
                testUserId = context.aspnet_Membership.FirstOrDefault().UserId;
            }
            var friend = ActiveRecordFriend.CreateNew("steve@foo.com", testUserId);

            var secondFriend = new ActiveRecordFriend(friend.Id);
            secondFriend.EmailAddress = "updated";
            secondFriend.Save();

            var thirdFriend = new ActiveRecordFriend(friend.Id);

            Assert.AreEqual(secondFriend.EmailAddress, thirdFriend.EmailAddress);
        }

        /// <summary>
        /// This is needlessly difficult to set up and slower than it need be
        /// </summary>
        [TestMethod]
        public void EmailDomainReturnedCorrectly()
        {
            Guid testUserId;
            using (var context = new aspnetdbEntities())
            {
                testUserId = context.aspnet_Membership.FirstOrDefault().UserId;
            }
            var friend = ActiveRecordFriend.CreateNew("steve@foo.com", testUserId);

            var domain = friend.EmailDomain;

            Assert.AreEqual("foo.com", domain);
        }

        public class PIFriend : Friend
        {
            public string EmailDomain
            {
                get
                {
                    return base.EmailAddress.Substring(base.EmailAddress.LastIndexOf('@') + 1);
                }
            }
        }

        [TestMethod]
        public void EmailDomainReturnedCorrectlyWithPIFriend()
        {
            var friend = new PIFriend() { EmailAddress = "steve@foo.com" };
            var domain = friend.EmailDomain;

            Assert.AreEqual("foo.com", domain);
        }

    }
}