using System;
using System.Collections.Generic;
using System.Linq;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Model;

namespace PluralSightBook.Core.Services
{
    public class FriendsService : IFriendsService
    {
        private readonly IFriendRepository _friendRepository;
        private readonly INotificationService _notificationService;

        public FriendsService(IFriendRepository friendRepository,
            INotificationService notificationService)
        {
            _friendRepository = friendRepository;
            _notificationService = notificationService;
        }

        public void AddFriend(Guid currentUserId,
            string currentUserEmail,
            string currentUserName,
            string friendEmail)
        {
            _friendRepository.Create(currentUserId, friendEmail);

            _notificationService.SendNotification(currentUserEmail, currentUserEmail, friendEmail);
        }

        public void DeleteFriend(int friendId)
        {
            _friendRepository.Delete(friendId);
        }

        public IEnumerable<Friend> ListFriendsOf(Guid userId)
        {
            return _friendRepository.ListFriendsOfUser(userId);
        }
    }

}