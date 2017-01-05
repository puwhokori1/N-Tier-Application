using System.Data.Entity;
using PluralSightBook.Data.Models.Mapping;

namespace PluralSightBook.Data.Models
{
    public class PluralSightBookContext : DbContext
    {
        public PluralSightBookContext() : base("Name=PluralSightBookContext")
        {
        }

        static PluralSightBookContext()
        {
            Database.SetInitializer<PluralSightBookContext>(null);
        }

        public DbSet<aspnet_Applications> aspnet_Applications { get; set; }
        public DbSet<aspnet_Membership> aspnet_Membership { get; set; }
        public DbSet<aspnet_Users> aspnet_Users { get; set; }
        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new aspnet_ApplicationsMap());
            modelBuilder.Configurations.Add(new aspnet_MembershipMap());
            modelBuilder.Configurations.Add(new aspnet_UsersMap());
            modelBuilder.Configurations.Add(new FriendMap());
        }
    }
}