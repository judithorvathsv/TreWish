namespace TreWishApi.Models.Dtos
{
    public class WishResponse
    {  
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? WebPageLink { get; set; }
    }
}