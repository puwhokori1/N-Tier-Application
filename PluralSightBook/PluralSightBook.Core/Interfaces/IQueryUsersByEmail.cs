using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluralSightBook.Core.Model;

namespace PluralSightBook.Core.Interfaces
{
    public interface IQueryUsersByEmail
    {
        bool UserWithEmailExists(string email);
        User GetUserByEmail(string email);
        bool IsUserWithEmailFriendOfUser(Guid userId, string emailAddressOfPotentialFriend);
    }
}
