
namespace TreWishApi.Models.Dtos
{
    public class UserStatisticsResponse
    {
        public string Name { get; set; }

        public int? WishedWishes { get; set; }

        public int? PurchasedWishes { get; set; } 
    }
}