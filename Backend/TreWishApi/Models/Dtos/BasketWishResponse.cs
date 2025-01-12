namespace TreWishApi.Models.Dtos
{
    public class BasketWishResponse
    {       
        public required string Name { get; set; }

        public required double Price { get; set; }

        public required string WisherName { get; set; }
    }
}