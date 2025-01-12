namespace TreWishApi.Models
{
    public class Wish
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required double Price { get; set; }

        public string? WebPageLink { get; set; }


        public required int WisherId { get; set; }
        public int? PurchaserId { get; set; }

        public virtual User Wisher { get; set; }
        public virtual User Purchaser { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
    }
}

public enum PaymentStatus
{
    Pending,
    Paid,
    Failed
}