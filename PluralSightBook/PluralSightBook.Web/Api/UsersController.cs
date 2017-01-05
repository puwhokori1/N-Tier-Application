using System;
using System.Linq;
using System.Web.Http;
using PluralSightBook.Core.Model;
using PluralSightBook.Core.Interfaces;

namespace PluralSightBook.Web.Api
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        // GET api/users?emailAddress=ssmith@foo.com
        public User GetUserByEmail(string emailAddress)
        {
            var user = _userService.GetUserByEmail(emailAddress);
            return user;
        }
    }
}