using System;
using System.Linq;

namespace PluralSightBook.Core.Model
{
    public class Friend
    {
        public virtual int Id { get; set; }
        public virtual string EmailAddress { get; set; }

        public virtual User User { get; set; }

        public override string ToString()
        {
            return String.Format("[{0}] {1}", Id, EmailAddress);
        }
    }
}
