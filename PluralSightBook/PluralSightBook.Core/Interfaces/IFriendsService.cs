using PluralSightBook.Core.Model;
using System;

namespace PluralSightBook.Core.Interfaces
{
    public interface IFriendsService
    {
        void AddFriend(Guid currentUserId, string currentUserEmail, string currentUserName, string friendEmail);
        void DeleteFriend(int friendId);
        System.Collections.Generic.IEnumerable<PluralSightBook.Core.Model.Friend> ListFriendsOf(Guid userId);
    }
}
