using FluentNHibernate.Mapping;
using PluralSightBook.Core.Model;
using System;
using System.Linq;

namespace PluralSightBook.Infrastructure.NHibernate.Mappings
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Id(x => x.UserId);
            Map(x => x.EmailAddress).Column("Email");
            HasMany(x => x.Friends).KeyColumn("UserId");
            Table("aspnet_membership");
        }
    }
}
