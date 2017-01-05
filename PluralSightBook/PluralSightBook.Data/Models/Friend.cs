using System;

namespace PluralSightBook.Data.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public System.Guid UserId { get; set; }
        public virtual aspnet_Membership aspnet_Membership { get; set; }
    }
}
