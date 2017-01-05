using PluralSightBook.Core.Interfaces;
using PluralSightBook.Core.Model;

namespace PluralSightBook.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IQueryUsersByEmail _userRepository;

        public UserService(IQueryUsersByEmail userRepository)
        {
            this._userRepository = userRepository;
        }

        public User GetUserByEmail(string emailAddress)
        {
            return _userRepository.GetUserByEmail(emailAddress);
        }
    }
}