namespace TreWishApi.Models.Dtos
{
    public class WishResponseList
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public string? Description { get; set; }

        public required double Price { get; set; }

        public string? WebPageLink { get; set; }

        public int? PurchaserId { get; set; }
    }
}