using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
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
            //var userResponse = await _webFactory.Client.GetFromJsonAsync<UserResponse>(userCreateResponse.Headers.Location);
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

    }
}