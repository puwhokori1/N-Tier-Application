using System;
using System.Collections.Generic;
using System.Linq;

namespace PluralSightBook.Core.Model
{
    public class User
    {
        public virtual Guid UserId { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual IList<Friend> Friends { get; set; }

        public User()
        {
            Friends = new List<Friend>();
        }

        public virtual void AddFriend(Friend friend)
        {
            friend.User = this;
            Friends.Add(friend);
        }

        public override string ToString()
        {
            return String.Format("[{0}] {1}", UserId, EmailAddress);
        }

    }
}
