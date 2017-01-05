using System;
using System.Collections.Generic;
using System.Linq;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Model;

namespace PluralSightBook.Data
{
    public class EfCodeFirstFriendRepository : IFriendRepository
    {
        private readonly PluralSightBookContext _context;

        public EfCodeFirstFriendRepository(PluralSightBookContext context)
        {
            this._context = context;
        }

        public void Create(Guid userId, string emailAddress)
        {
            var newFriend = new PluralSightBook.Data.Models.Friend();

            newFriend.UserId = userId;
            newFriend.EmailAddress = emailAddress;
            this._context.Friends.Add(newFriend);
            this._context.SaveChanges();
        }

        public void Delete(int friendId)
        {
            var friendToDelete = this._context.Friends.FirstOrDefault(f => f.Id == friendId);
            this._context.Friends.Remove(friendToDelete);
            this._context.SaveChanges();
        }

        public IEnumerable<Friend> ListFriendsOfUser(Guid userId)
        {
            return this._context.Friends
                       .Where(f => f.UserId == userId)
                       .Select(f => new Friend()
                              {
                                  Id = f.Id,
                                  EmailAddress = f.EmailAddress
                              })
                              .ToList();
        }
    }
}