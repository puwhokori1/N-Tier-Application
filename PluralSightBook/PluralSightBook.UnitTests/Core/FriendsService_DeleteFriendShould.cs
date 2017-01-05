using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Services;
using Telerik.JustMock;

namespace PluralSightBook.UnitTests.Core
{
    [TestClass]
    public class FriendsService_DeleteFriendShould
    {
        [TestMethod]
        public void DeleteFriendViaRepository()
        {
            var mockFriendRepository = Mock.Create<IFriendRepository>();
            var mockNotificationService = Mock.Create<INotificationService>();

            var myFriendsService = new FriendsService(mockFriendRepository, mockNotificationService);

            myFriendsService.DeleteFriend(0);

            Mock.Assert(() => mockFriendRepository.Delete(Arg.IsAny<int>()), Occurs.Once());
        }
    }
}