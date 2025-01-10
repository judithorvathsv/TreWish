namespace TreWishApi.Models.Dtos
{
    public class UserResponse
    {
        public string Name { get; set; }

        public List<WishResponse>? WishedWishes { get; set; }

        public List<WishResponse>? PurchasedWishes { get; set; }
    }
}