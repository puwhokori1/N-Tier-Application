using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using PluralSightBook.Core.Interfaces;
using PluralSightBookWebsite.Code;
using StructureMap;

namespace PluralSightBookWebsite
{
    public partial class Friends : BasePage
    {
        public IFriendsService FriendsService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGridView();
            }
        }

        protected void Delete_LinkButton_Click(object sender, EventArgs e)
        {
            int friendId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            this.FriendsService.DeleteFriend(friendId);
            this.BindGridView();
        }

        private void BindGridView()
        {
            Guid currentUserId = (Guid)Membership.GetUser().ProviderUserKey;

            this.GridView1.DataSource = this.FriendsService.ListFriendsOf(currentUserId);
            this.GridView1.DataBind();
        }

        public string ListTypes()
        {
            string types = "IFriendRepository ==> {0},<br />IQueryUsersByEmail ==> {1}";

            return String.Format(types, ObjectFactory.GetInstance<IFriendRepository>().ToString(), ObjectFactory.GetInstance<IQueryUsersByEmail>().ToString());
        }
    }
}