namespace TreWishApi.Interfaces
{
    public interface IUserService
    {
        string GetUserId();
        void SetUserId(string id);
    }
}