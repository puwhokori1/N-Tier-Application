using NHibernate;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Model;
using System;
using System.Linq;

namespace PluralSightBook.Infrastructure.NHibernate
{
    public class NHQueryUsersByEmail : IQueryUsersByEmail
    {
        private readonly ISessionFactory _sessionFactory;

        public NHQueryUsersByEmail(ISessionFactory sessionFactory)
        {
            this._sessionFactory = sessionFactory;
        }

        public bool UserWithEmailExists(string email)
        {
            return GetUserByEmail(email) != null;
        }

        public Core.Model.User GetUserByEmail(string email)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var users = session.CreateCriteria(typeof(User))
                    .List<User>()
                    .Where(u => u.EmailAddress == email);
                return users.FirstOrDefault();
            }
        }

        public bool IsUserWithEmailFriendOfUser(Guid userId, string emailAddressOfPotentialFriend)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var users = session.CreateCriteria(typeof(Friend))
                    .List<Friend>()
                    .Where(f => f.User.UserId == userId &&
                        f.EmailAddress == emailAddressOfPotentialFriend);
                return users.Any();
            }
        }
    }
}
