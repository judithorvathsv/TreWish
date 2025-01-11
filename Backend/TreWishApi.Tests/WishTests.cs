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
            var responseList = await _webFactory.Client.GetFromJsonAsync<IEnumerable<WishResponse>>("/api/wishes");

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


    }
}