using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluralSightBook.Core.Model;

namespace PluralSightBook.Core.Interfaces
{
    public interface IFriendRepository
    {
        void Create(Guid userId, string emailAddress);
        void Delete(int friendId);
        IEnumerable<Friend> ListFriendsOfUser(Guid userId);
    }
}
