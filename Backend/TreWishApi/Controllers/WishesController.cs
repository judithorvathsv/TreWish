using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using TreWishApi.Models;
using TreWishApi.Models.Dtos;

namespace TreWishApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public WishesController(ApplicationDbContext context)
        {
            _context = context;
        }

        private WishResponse WishToResponse(Wish wish)
        {

            return new WishResponse()
            {
                Name = wish.Name,
                Description = wish.Description,
                Price = wish.Price,
                WebPageLink = wish.WebPageLink
            };
        }

        [HttpGet("{id}")]
        public ActionResult<Wish> Get(int id)
        {
            var wish = _context.Wishes.Find(id);
            if (wish is null)
            {
                return NotFound();
            }
            return Ok(WishToResponse(wish));
        }
    }
}