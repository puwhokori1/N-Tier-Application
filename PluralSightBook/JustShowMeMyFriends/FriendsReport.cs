using System;
using System.Text;
using PluralSightBook.Core.Interfaces;

namespace JustShowMeMyFriends
{
    public class FriendsReport
    {
        private readonly IFriendsService _friendsService;
        private readonly IUserService _userService;

        public FriendsReport(IFriendsService friendsService,
            IUserService userService)
        {
            this._friendsService = friendsService;
            this._userService = userService;
        }

        public string ShowFriendsReport(string userEmail)
        {
            Console.WriteLine("All Friends of {0}:", userEmail);
            var user = _userService.GetUserByEmail(userEmail);

            var friends = _friendsService.ListFriendsOf(user.UserId);
            StringBuilder sb = new StringBuilder();
            foreach (var friend in friends)
            {
                sb.Append(friend);
                sb.Append(System.Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}