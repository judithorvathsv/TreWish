
using TreWishApi.Interfaces;

namespace TreWishApi.Services
{
    public class UserService : IUserService
    {
        private string _userId;

        public string GetUserId() => _userId;

        public void SetUserId(string id) => _userId = id;
    }
}