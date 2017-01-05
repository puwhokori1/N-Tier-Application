using System;
using System.Linq;
using System.Web.Security;
using PluralSightBook.Core.Services;
using PluralSightBook.Infrastructure.NHibernate;
using PluralSightBook.Infrastructure.Services;
using PluralSightBookWebsite.Code;
using PluralSightBook.Core.Interfaces;

namespace PluralSightBookWebsite
{
    public partial class AddFriend : BasePage
    {
        public IFriendsService FriendsService { get; set; }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string currentUserName = ""; // MyProfile.CurrentUser.Name;
            string currentUserEmail = Membership.GetUser().Email;
            Guid currentUserId = (Guid)Membership.GetUser().ProviderUserKey;
            string friendEmail = this.EmailTextBox.Text;

           //var friendsService = new FriendsService(
           //     new NHFriendRepository(Global.SessionFactory.Value),
           //     new NotificationService(new NHQueryUsersByEmail(Global.SessionFactory.Value), new DebugEmailSender()));

            FriendsService.AddFriend(currentUserId, currentUserEmail, currentUserName, friendEmail);

            this.Response.Redirect("~/Friends.aspx", true);
        }
    }
}