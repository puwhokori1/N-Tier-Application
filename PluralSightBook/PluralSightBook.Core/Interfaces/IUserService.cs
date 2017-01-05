using PluralSightBook.Core.Model;

namespace PluralSightBook.Core.Interfaces
{
    public interface IUserService
    {
        User GetUserByEmail(string emailAddress);
    }
}