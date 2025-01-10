namespace TreWishApi.Tests;

public class UserTests:IClassFixture<OurApiWebFactory>
{
     private OurApiWebFactory _webFactory;

     public UserTests(OurApiWebFactory ourApiWebFactory)
     {
        _webFactory = ourApiWebFactory;
     }
    [Fact]
    public void UserTest()
    {

        

    }
}