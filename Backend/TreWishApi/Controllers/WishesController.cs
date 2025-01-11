using System.Globalization;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using TreWishApi.Interfaces;
using TreWishApi.Models;
using TreWishApi.Models.Dtos;

namespace TreWishApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public WishesController(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
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

        [HttpPost]
        public async Task<IActionResult> Create(WishRequest request)
        {
            var id = _userService.GetUserId();

            Wish wish = new Wish()
            {
                Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(request.Name.ToLower()),
                Description = request.Description,
                Price = request.Price,
                WebPageLink = request.WebPageLink,
                WisherId = int.Parse(id)
            };

            await _context.Wishes.AddAsync(wish);
            await _context.SaveChangesAsync();

            var response = WishToResponse(wish);

            return CreatedAtAction("Get", new { id = wish.Id }, response);
        }

        [HttpGet]
        public ActionResult<WishResponseList> GetWishList()
        {
            var wishes = _context.Wishes.Select(w => new WishResponseList
            {
                Id = w.Id,
                Name = w.Name,
                Description = w.Description,
                Price = w.Price,
                WebPageLink = w.WebPageLink
            })
         .ToList();
            return Ok(wishes);
        }
    }
}