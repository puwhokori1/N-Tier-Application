using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Model;

namespace PluralSightBook.Web.Api
{
    public class FriendsController : ApiController
    {
        private readonly IFriendsService _friendsService;

        public FriendsController(IFriendsService friendsService)
        {
            this._friendsService = friendsService;
        }

        // GET api/friends?userId=dfd368dd-b5bf-4177-98d1-a4a9369dd72e
        public IEnumerable<Friend> GetFriendsOfUser(Guid userId)
        {
            return _friendsService.ListFriendsOf(userId);
        }
    }
}