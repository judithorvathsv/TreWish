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


    }
}