using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Services;
using Telerik.JustMock;
using PluralSightBook.Core.Model;

namespace PluralSightBook.UnitTests.Core
{
    [TestClass]
    public class NotificationService_SendNotificationShould
    {
        private IQueryUsersByEmail _mockIQueryUsersByEmail;
        private ISendEmail _mockEmailSender;

        [TestInitialize]
        public void SetUp()
        {
            _mockIQueryUsersByEmail = Mock.Create<IQueryUsersByEmail>();
            _mockEmailSender = Mock.Create<ISendEmail>();
        }

        [TestMethod]
        public void SendCorrectEmailWhenAlreadyFriends()
        {
            var myNotificationService = new NotificationService(_mockIQueryUsersByEmail, _mockEmailSender);
            Mock.Arrange(() => _mockIQueryUsersByEmail.UserWithEmailExists(Arg.IsAny<string>()))
                .Returns(true);
            Mock.Arrange(() => _mockIQueryUsersByEmail.GetUserByEmail(Arg.IsAny<string>()))
                .Returns(new User());
            Mock.Arrange(() => _mockIQueryUsersByEmail.IsUserWithEmailFriendOfUser(Arg.IsAny<Guid>(), Arg.IsAny<string>()))
                .Returns(true);

            myNotificationService.SendNotification("", "", "");

            string expectedBody = @"Good News! Your friend  just added you as a friend!";
            Mock.Assert(() => _mockEmailSender.SendEmail(expectedBody), Occurs.Once());
        }

        [TestMethod]
        public void SendCorrectEmailWhenMemberButNotFriend()
        {
            var myNotificationService = new NotificationService(_mockIQueryUsersByEmail, _mockEmailSender);
            Mock.Arrange(() => _mockIQueryUsersByEmail.UserWithEmailExists(Arg.IsAny<string>()))
                .Returns(true);
            Mock.Arrange(() => _mockIQueryUsersByEmail.GetUserByEmail(Arg.IsAny<string>()))
                .Returns(new User());
            Mock.Arrange(() => _mockIQueryUsersByEmail.IsUserWithEmailFriendOfUser(Arg.IsAny<Guid>(), Arg.IsAny<string>()))
                .Returns(false);

            myNotificationService.SendNotification("", "", "");

            string expectedBody = @" added you as a friend on PluralsightBook!  Click here to add them as your friend: http://localhost:4927/QuickAddFriend.aspx?email=";
            Mock.Assert(() => _mockEmailSender.SendEmail(expectedBody), Occurs.Once());
        }

        [TestMethod]
        public void SendCorrectEmailWhenNotMember()
        {
            var myNotificationService = new NotificationService(_mockIQueryUsersByEmail, _mockEmailSender);
            Mock.Arrange(() => _mockIQueryUsersByEmail.UserWithEmailExists(Arg.IsAny<string>()))
                .Returns(false);

            myNotificationService.SendNotification("", "", "");

            string expectedBody = @" added you as a friend on PluralsightBook!  Click here to register your own account and then add them as your friend: http://localhost:4927/QuickAddFriend.aspx?email=";
            Mock.Assert(() => _mockEmailSender.SendEmail(expectedBody), Occurs.Once());
        }
    }
}