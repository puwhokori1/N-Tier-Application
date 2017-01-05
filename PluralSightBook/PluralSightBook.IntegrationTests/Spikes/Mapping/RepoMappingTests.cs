using System;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.IntegrationTests.Spikes.CodeFirst;
using PluralSightBook.Infrastructure.Data;
using System.Collections.Generic;

namespace PluralSightBook.IntegrationTests.Spikes.Mapping
{
    [TestClass]
    public class RepoMappingTests
    {
        [ClassInitialize]
        public static void TestRunInitialize(TestContext context)
        {
            Mapper.CreateMap<Friends, PluralSightBook.Core.Model.Friend>();
        }

        [TestMethod]
        public void ListFriendsUsingMapper()
        {
            var friendRepository = new MappingFriendRepository();

            var context =new PluralSightBook.Data.PluralSightBookContext();
            var initializer = new TestDbInitializer();
            initializer.Reseed(context);

            var testUserId = context.aspnet_Users.FirstOrDefault().UserId;
            friendRepository.Create(testUserId, "foo@bar.com");
            var result = friendRepository.ListFriendsOfUser(testUserId);

            Assert.IsInstanceOfType(result.FirstOrDefault(), typeof(PluralSightBook.Core.Model.Friend)); 
        }
    }

    public class MappingFriendRepository : IFriendRepository
    {
        public void Create(Guid userId, string emailAddress)
        {
            var context = new aspnetdbEntities();
            var newFriend = context.Friends.CreateObject();
            newFriend.UserId = userId;
            newFriend.EmailAddress = emailAddress;
            context.Friends.AddObject(newFriend);
            context.SaveChanges();
        }

        public void Delete(int friendId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Model.Friend> ListFriendsOfUser(Guid userId)
        {
            var context = new aspnetdbEntities();
            return context.Friends
                .Where(f => f.UserId == userId)
                .ToList()
                .Select(f => Mapper.Map<Friends, PluralSightBook.Core.Model.Friend>(f));
                //.Select(f => new PluralSightBook.Core.Model.Friend()
                //{
                //    Id = f.Id,
                //    EmailAddress = f.EmailAddress
                //});
        }
    }
}