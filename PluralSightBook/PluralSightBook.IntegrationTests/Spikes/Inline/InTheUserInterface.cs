using System;
using System.Linq;
using PluralSightBook.Infrastructure.Data;

namespace PluralSightBook.IntegrationTests.Spikes.Inline
{
    public class InTheUserInterface
    {
        public void Button_Click()
        {
            // read some values from UI elements
            Guid currentUserId = Guid.NewGuid(); // (Guid)Membership.GetUser().ProviderUserKey;
            string friendEmail = ""; // EmailTextBox.Text;

            // maybe do some validation

            // save stuff to the database
            using (var context = new aspnetdbEntities())
            {
                var friend = context.Friends.CreateObject();
                friend.EmailAddress = friendEmail;
                friend.UserId = currentUserId;
                context.Friends.AddObject(friend);
                context.SaveChanges();
            }

            // maybe update a label or redirect
        }
    }
}