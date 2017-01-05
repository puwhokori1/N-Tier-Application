using System;
using System.Linq;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Model;

namespace PluralSightBook.Data
{
    public class EfCodeFirstQueryUsersByEmail : IQueryUsersByEmail
    {
        private readonly PluralSightBookContext _context;

        public EfCodeFirstQueryUsersByEmail(PluralSightBookContext context)
        {
            this._context = context;
        }

        public bool UserWithEmailExists(string email)
        {
            return _context.aspnet_Membership.Any(m => m.Email == email);
        }

        public User GetUserByEmail(string email)
        {
            return _context.aspnet_Membership
                          .Where(m => m.Email == email)
                          .Select(m => new User()
                          {
                              UserId = m.UserId,
                              EmailAddress = m.Email
                          })
                          .FirstOrDefault();
        }

        public bool IsUserWithEmailFriendOfUser(Guid userId, string emailAddressOfPotentialFriend)
        {
            return _context.Friends
                          .Any(f => f.UserId == userId &&
                                    f.EmailAddress == emailAddressOfPotentialFriend);
        }
    }
}