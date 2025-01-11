using System.Net.Http.Json;
using FluentAssertions;
using TreWishApi.Models;
using TreWishApi.Models.Dtos;

namespace TreWishApi.Tests
{

    public class WishTests : IClassFixture<OurApiWebFactory>
    {
        private OurApiWebFactory _webFactory;

        public WishTests(OurApiWebFactory ourApiWebFactory)
        {
            _webFactory = ourApiWebFactory;
        }


        [Fact]
        public async Task Create_Should_Create_New_Wish()
        {
            //Arrange
            var userRequest = new UserRequest()
            {
                Name = "User TestName 8",
            };

            var userCreateResponse = await _webFactory.Client.PostAsJsonAsync("/api/users", userRequest);

            var userId = int.Parse(userCreateResponse.Headers.Location.Segments.Last());

            var wishRequest = new WishRequest()
            {
                Name = "Wish Test 1",
                Description = "1th Wish",
                Price = 1.1,
                WisherId = userId
            };

            //Act      
            var createResponse = await _webFactory.Client.PostAsJsonAsync("/api/wishes", wishRequest);

            //Assert
            var response = await _webFactory.Client.GetFromJsonAsync<WishResponse>(createResponse.Headers.Location);
            response.Should().NotBeNull();
        }

        [Fact]
        public async Task GetWishList_Should_Get_All_Wishes()
        {
            //Arrange
            var userRequest = new UserRequest()
            {
                Name = "User TestName 8",
            };

            var userCreateResponse = await _webFactory.Client.PostAsJsonAsync("/api/users", userRequest);

            var userId = int.Parse(userCreateResponse.Headers.Location.Segments.Last());

            var wishRequest1 = new WishRequest()
            {
                Name = "Wish Test 3",
                Description = "3th Wish",
                Price = 3.3,
                WisherId = userId
            };
            var wishRequest2 = new WishRequest()
            {
                Name = "Wish Test 4",
                Description = "4th Wish",
                Price = 4.4,
                WisherId = userId
            };
            await _webFactory.Client.PostAsJsonAsync("/api/wishes", wishRequest1);
            await _webFactory.Client.PostAsJsonAsync("/api/wishes", wishRequest2);

            //Act      
            var responseList = await _webFactory.Client.GetFromJsonAsync<IEnumerable<WishResponseList>>("/api/wishes");

            //Assert          
            responseList.Count().Should().BeGreaterThanOrEqualTo(2);
            responseList.Should().Contain(c => c.Name == "Wish Test 4");
        }


        [Fact]
        public async Task DeleteWish_Should_Delete_Wish_ById()
        {
            // Arrange
            var userRequest = new UserRequest()
            {
                Name = "User TestName 9",
            };

            var userCreateResponse = await _webFactory.Client.PostAsJsonAsync("/api/users", userRequest);
            var userId = int.Parse(userCreateResponse.Headers.Location.Segments.Last());

            var wishRequest1 = new WishRequest()
            {
                Name = "Wish Test 5",
                Description = "5th Wish",
                Price = 3.3,
                WisherId = userId
            };

            var createResponse = await _webFactory.Client.PostAsJsonAsync("/api/wishes", wishRequest1);

            var wishResponse = await createResponse.Content.ReadFromJsonAsync<WishResponseList>();
            var wishId = wishResponse!.Id;

            // Act
            var deleteResponse = await _webFactory.Client.DeleteAsync($"/api/wishes/{wishId}");

            // Assert
            deleteResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }


        [Fact]
        public async Task GetWish_Should_Get_Wish_ById()
        {
            // Arrange
            var userRequest = new UserRequest()
            {
                Name = "User TestName 10",
            };

            var userCreateResponse = await _webFactory.Client.PostAsJsonAsync("/api/users", userRequest);
            var userId = int.Parse(userCreateResponse.Headers.Location.Segments.Last());

            var wishRequest = new WishRequest()
            {
                Name = "Wish Test 6",
                Description = "6th Wish",
                Price = 3.3,
                WisherId = userId
            };

            var createResponse = await _webFactory.Client.PostAsJsonAsync("/api/wishes", wishRequest);

            var wishResponse = await createResponse.Content.ReadFromJsonAsync<WishResponseList>();
            var wishId = wishResponse!.Id;

            // Act
            var getResponse = await _webFactory.Client.GetFromJsonAsync<WishResponseList>($"/api/wishes/{wishId}");

            // Assert
            getResponse.Should().NotBeNull();
            getResponse.Name.Should().Be(wishRequest.Name);
        }

        [Fact]
        public async Task Update_Should_Update_A_Wish()
        {
            // Arrange
            var userRequest = new UserRequest()
            {
                Name = "User TestName 11",
            };

            var userCreateResponse = await _webFactory.Client.PostAsJsonAsync("/api/users", userRequest);
            var userId = int.Parse(userCreateResponse.Headers.Location.Segments.Last());

            var wishRequest = new WishRequest()
            {
                Name = "Wish Test 7",
                Description = "7th Wish",
                Price = 7.7,
                WisherId = userId
            };

            var createResponse = await _webFactory.Client.PostAsJsonAsync("/api/wishes", wishRequest);
            var wishResponse = await createResponse.Content.ReadFromJsonAsync<WishResponseList>();
            var wishId = wishResponse!.Id;

            var updatedWishRequest = new WishResponseList()
            {
                Id = wishId,
                Name = "Updated Wish 7",
                Description = "Updated 7th Wish",
                Price = 8.8,
                WebPageLink = "https://updatedlink.com"
            };

            // Act
            var updateResponse = await _webFactory.Client.PutAsJsonAsync($"/api/wishes/{wishId}", updatedWishRequest);

            //Assert
            updateResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var updatedWishResponse = await updateResponse.Content.ReadFromJsonAsync<WishResponseList>();
            updatedWishResponse!.Name.Should().Be(updatedWishRequest.Name);
            updatedWishResponse!.WebPageLink.Should().Be(updatedWishRequest.WebPageLink);
        }


        [Fact]
        public async Task Update_Should_Update_PurchaserId_After_Purchase()
        {
            // Arrange
            var userRequest = new UserRequest()
            {
                Name = "User TestName 12",
            };

            var userCreateResponse = await _webFactory.Client.PostAsJsonAsync("/api/users", userRequest);
            var userId = int.Parse(userCreateResponse.Headers.Location.Segments.Last());

            var wishRequest = new WishRequest()
            {
                Name = "Wish Test 8",
                Description = "8th Wish",
                Price = 10.10,
                WisherId = userId
            };

            var createWishResponse = await _webFactory.Client.PostAsJsonAsync("/api/wishes", wishRequest);
            var wishResponse = await createWishResponse.Content.ReadFromJsonAsync<WishResponseList>();
            var wishId = wishResponse!.Id;

            // Act
            await _webFactory.Client.PutAsJsonAsync($"/api/wishes/purchase/{wishId}", new { });

            // Assert            
            var updatedWish = await _webFactory.Client.GetFromJsonAsync<WishResponseList>($"/api/wishes/{wishId}");
            updatedWish.PurchaserId.Should().NotBeNull();
        }


        [Fact]
        public async Task GetWishListPurchasedForUser_Should_Get_Purchased_Wishes_For_Logged_In_User()
        {
            // Arrange
            var userRequest = new UserRequest()
            {
                Name = "User TestName 13",
            };

            var userCreateResponse = await _webFactory.Client.PostAsJsonAsync("/api/users", userRequest);
            var userId = int.Parse(userCreateResponse.Headers.Location.Segments.Last());

            var wishRequest1 = new WishRequest()
            {
                Name = "Wish Test 9",
                Description = "9th Wish",
                Price = 9.7,
                WisherId = userId
            };

            var wishRequest2 = new WishRequest()
            {
                Name = "Wish Test 10",
                Description = "10th Wish",
                Price = 10.8,
                WisherId = userId
            };
            var createResponse1 = await _webFactory.Client.PostAsJsonAsync("/api/wishes", wishRequest1);
            var wishResponse1 = await createResponse1.Content.ReadFromJsonAsync<WishResponseList>();
            var wishId1 = wishResponse1!.Id;

            var createResponse2 = await _webFactory.Client.PostAsJsonAsync("/api/wishes", wishRequest2);
            var wishResponse2 = await createResponse2.Content.ReadFromJsonAsync<WishResponseList>();
            var wishId2 = wishResponse2!.Id;
            await _webFactory.Client.PutAsJsonAsync($"/api/wishes/purchase/{wishId1}", new { });

            // Act     
            var responseList = await _webFactory.Client.GetFromJsonAsync<IEnumerable<WishResponse>>("/api/wishes/purchased");

            // Assert          
            responseList.Should().NotBeNull();
            responseList.Count().Should().Be(1);
            responseList.Should().Contain(c => c.Name == "Wish Test 9");
        }




    }
}