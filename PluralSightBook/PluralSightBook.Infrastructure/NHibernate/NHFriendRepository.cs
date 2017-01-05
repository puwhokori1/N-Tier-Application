using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluralSightBook.Core.Interfaces;
using NHibernate;
using PluralSightBook.Core.Model;

namespace PluralSightBook.Infrastructure.NHibernate
{
    public class NHFriendRepository : IFriendRepository
    {
        private readonly ISessionFactory _sessionFactory;

        public NHFriendRepository(ISessionFactory sessionFactory)
        {
            this._sessionFactory = sessionFactory;
        }

        public void Create(Guid userId, string emailAddress)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var user = session.Get<User>(userId);
                
                var newFriend = new Friend() { EmailAddress = emailAddress};
                user.AddFriend(newFriend);
                session.Save(newFriend);
                transaction.Commit();
            }
        }

        public void Delete(int friendId)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var friend = session.Get<Friend>(friendId);
                session.Delete(friend);

                transaction.Commit();
            }
        }

        public IEnumerable<Core.Model.Friend> ListFriendsOfUser(Guid userId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var friends = session.CreateCriteria(typeof(Friend))
                    .List<Friend>()
                    .Where(f => f.User.UserId == userId);
                return friends;
            }
        }
    }
}
