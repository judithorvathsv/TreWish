
namespace TreWishApi.Models
{
    public class WishRequest
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public required double Price { get; set; }

        public string? WebPageLink { get; set; }

        public int? WisherId { get; set; }

        public int? PurchaserId { get; set; }
    }
}