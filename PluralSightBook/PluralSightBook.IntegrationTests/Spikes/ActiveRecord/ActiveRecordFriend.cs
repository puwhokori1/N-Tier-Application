using System;
using System.Linq;
using PluralSightBook.Infrastructure.Data;

namespace PluralSightBook.IntegrationTests.Spikes.ActiveRecord
{
    public class ActiveRecordFriend
    {
        private Friends friendEntity;

        public ActiveRecordFriend(int id)
        {
            using (var context = new aspnetdbEntities())
            {
                friendEntity = context.Friends.FirstOrDefault(f => f.Id == id);
            }
            if (friendEntity == null)
            {
                throw new ApplicationException("Specified friend does not exist: " + id);
            }
            this.Id = friendEntity.Id;
            this.EmailAddress = friendEntity.EmailAddress;
        }

        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public void Save()
        {
            using (var context = new aspnetdbEntities())
            {
                context.Attach(friendEntity);
                friendEntity.EmailAddress = this.EmailAddress;
                context.SaveChanges();
            }
        }

        public static ActiveRecordFriend CreateNew(string emailAddress, Guid userId)
        {
            using (var context = new aspnetdbEntities())
            {
                var friend = context.Friends.CreateObject();
                friend.EmailAddress = emailAddress;
                friend.UserId = userId;
                context.Friends.AddObject(friend);
                context.SaveChanges();
                return new ActiveRecordFriend(friend.Id);
            }
        }

        public string EmailDomain
        {
            get
            {
                return EmailAddress.Substring(EmailAddress.LastIndexOf('@')+1);
            }
        }
    }
}