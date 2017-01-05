using System;
using System.Collections.Generic;
using System.Linq;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Model;

namespace PluralSightBook.Infrastructure.Data
{
    public class EfFriendRepository : IFriendRepository
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
            var context = new aspnetdbEntities();
            var friendToDelete = context.Friends.FirstOrDefault(f => f.Id == friendId);
            context.Friends.DeleteObject(friendToDelete);
            context.SaveChanges();
        }

        public IEnumerable<Friend> ListFriendsOfUser(Guid userId)
        {
            var context = new aspnetdbEntities();
            return context.Friends
                .Where(f => f.UserId == userId)
                .Select(f => new Friend()
                {
                    Id = f.Id,
                    EmailAddress = f.EmailAddress
                });
        }
    }
}
