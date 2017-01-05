using FluentNHibernate.Mapping;
using PluralSightBook.Core.Model;
using System;
using System.Linq;

namespace PluralSightBook.Infrastructure.NHibernate.Mappings
{
    public class FriendMapping : ClassMap<Friend>
    {
        public FriendMapping()
        {
            Id(x => x.Id);
            Map(x => x.EmailAddress);
            References(x => x.User).Column("UserId");
            Table("Friends");
        }
    }
}
