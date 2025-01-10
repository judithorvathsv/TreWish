namespace TreWishApi.Models
{
    public class User
    {
        public int Id {get; set;}

        public required string Name {get; set;} 

        public virtual List<Wish>? WishedWishes {get; set;}

        public virtual List<Wish>? PurchasedWishes  {get; set;}    
    }
}