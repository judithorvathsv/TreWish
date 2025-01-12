namespace TreWishApi.Models.Dtos
{
    public class TotalBasketResponse
    {
        public required List<BasketWishResponse> BasketWishes {get; set;}

        public double TotalPrice {get; set;}
    }
}