using System.Net.Http.Json;
using FluentAssertions;
using TreWishApi.Models;
using TreWishApi.Models.Dtos;

namespace TreWishApi.Tests;

public class UserTests : IClassFixture<OurApiWebFactory>
{
   private OurApiWebFactory _webFactory;

   public UserTests(OurApiWebFactory ourApiWebFactory)
   {
      _webFactory = ourApiWebFactory;
   }

   [Fact]
   public async Task Create_Should_Create_New_User()
   {
      //Arrange
      var request = new UserRequest()
      {
         Name = "User TestName 1",
      };

      //Act      
      var createResponse = await _webFactory.Client.PostAsJsonAsync("/api/users", request);

      //Assert
      var response = await _webFactory.Client.GetFromJsonAsync<UserResponse>(createResponse.Headers.Location);
      response.Should().NotBeNull();
   }

   [Fact]
   public async Task Get_Should_Get_User_ById()
   {
      //Arrange
      var request = new UserRequest()
      {
           Name = "User TestName 2",
      };
      var createResponse = await _webFactory.Client.PostAsJsonAsync("/api/users", request);

      //Act      
      var response = await _webFactory.Client.GetFromJsonAsync<UserResponse>(createResponse.Headers.Location);

      //Assert     
      response.Should().NotBeNull();
      response.Name.Should().Be("User Testname 2");
   }



}