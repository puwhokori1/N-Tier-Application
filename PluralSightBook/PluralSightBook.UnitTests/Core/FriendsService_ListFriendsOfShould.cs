using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Services;
using Telerik.JustMock;
using PluralSightBook.Core.Model;
using System.Collections.Generic;

namespace PluralSightBook.UnitTests.Core
{
    [TestClass]
    public class FriendsService_ListFriendsOfShould
    {
        [TestMethod]
        public void ReturnListFromRepository()
        {
            var mockFriendRepository = Mock.Create<IFriendRepository>();
            var mockNotificationService = Mock.Create<INotificationService>();

            var myFriendsService = new FriendsService(mockFriendRepository, mockNotificationService);

            var result = myFriendsService.ListFriendsOf(Guid.NewGuid());

            Mock.Assert(() => mockFriendRepository.ListFriendsOfUser(Arg.IsAny<Guid>()), Occurs.Once());
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Friend>));
        }
    }
}