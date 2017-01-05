using System;
using System.Collections.Generic;
using System.Net.Http;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Model;

namespace JustShowMeMyFriends.WebApiServices
{
    public class WebApiFriendsService : IFriendsService
    {
        private readonly HttpClient _client;

        public WebApiFriendsService(HttpClient client)
        {
            this._client = client;
        }

        public void AddFriend(Guid currentUserId, string currentUserEmail, string currentUserName, string friendEmail)
        {
            throw new NotImplementedException();
        }

        public void DeleteFriend(int friendId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Friend> ListFriendsOf(Guid userId)
        {
            string request = String.Format("api/friends?userId={0}", userId);
            HttpResponseMessage response = _client.GetAsync(request).Result; // blocking call

            if (response.IsSuccessStatusCode)
            {
                var friends = response.Content.ReadAsAsync<IEnumerable<Friend>>().Result;
                return friends;
            }
            return null;
        }
    }
}