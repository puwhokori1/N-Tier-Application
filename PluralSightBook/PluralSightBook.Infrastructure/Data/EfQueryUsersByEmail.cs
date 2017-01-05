using System;
using System.Linq;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Model;

namespace PluralSightBook.Infrastructure.Data
{
    public class EfQueryUsersByEmail : IQueryUsersByEmail
    {
        public bool UserWithEmailExists(string email)
        {
            var context = new aspnetdbEntities();
            return context.aspnet_Membership.Any(m => m.Email == email);
        }

        public User GetUserByEmail(string email)
        {
            var context = new aspnetdbEntities();
            return context.aspnet_Membership
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
            var context = new aspnetdbEntities();
            return context.Friends
                          .Any(f => f.UserId == userId &&
                                    f.EmailAddress == emailAddressOfPotentialFriend);
        }
    }
}