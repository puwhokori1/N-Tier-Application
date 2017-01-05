using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Services;
using Telerik.JustMock;

namespace PluralSightBook.UnitTests.Core
{
    [TestClass]
    public class FriendsService_CreateFriendShould
    {
        [TestMethod]
        public void CreateFriendAndSendNotification()
        {
            var mockFriendRepository = Mock.Create<IFriendRepository>();
            var mockNotificationService = Mock.Create<INotificationService>();

            var myFriendsService = new FriendsService(mockFriendRepository, mockNotificationService);

            myFriendsService.AddFriend(Guid.NewGuid(), "", "", "");

            Mock.Assert(() => mockFriendRepository.Create(Arg.IsAny<Guid>(), Arg.IsAny<string>()), Occurs.Once());
            Mock.Assert(() => mockNotificationService.SendNotification(Arg.IsAny<string>(), Arg.IsAny<string>(), Arg.IsAny<string>()), Occurs.Once());
        }
    }
}