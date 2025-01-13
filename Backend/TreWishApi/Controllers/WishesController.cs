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

        private WishResponseList WishToResponseList(Wish wish)
        {
            return new WishResponseList()
            {
                Id = wish.Id,
                Name = wish.Name,
                Description = wish.Description,
                Price = wish.Price,
                WebPageLink = wish.WebPageLink,
                PurchaserId = wish.PurchaserId
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
            return Ok(WishToResponseList(wish));
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

            var response = WishToResponseList(wish);

            return CreatedAtAction("Get", new { id = wish.Id }, response);
        }

        [HttpGet]
        public ActionResult<WishResponseList> GetWishList()
        {
            var wishes = _context.Wishes.Where(w => w.PurchaserId == null || w.PurchaserId == 0)
                                        .Select(w => new WishResponseList
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

        [HttpGet("purchased")]
        public ActionResult<WishResponse> GetWishListPurchasedForUser()
        {
            var userId = _userService.GetUserId();

            var wishes = _context.Wishes.Where(w => w.PurchaserId > 0 && w.WisherId.ToString() == userId).Select(w => new WishResponse
            {
                Name = w.Name,
                Description = w.Description,
                Price = w.Price,
                WebPageLink = w.WebPageLink
            })
            .ToList();
            return Ok(wishes);
        }

        [HttpGet("purchased/basket")]
        public ActionResult<TotalBasketResponse> GetBasketWithWishListPurchasedByUser()
        {
            var userId = _userService.GetUserId();

            var wishes = _context.Wishes.Where(w => w.PurchaserId.ToString() == userId && w.PaymentStatus != PaymentStatus.Paid).Select(w => new BasketWishResponse
            {
                Name = w.Name,
                Price = w.Price,
                WisherName = _context.Users.FirstOrDefault(u => u.Id == w.WisherId)!.Name
            })
            .ToList();

            var totalPrice = wishes.Sum(w => w.Price);

            var basket = new TotalBasketResponse()
            {
                BasketWishes = wishes,
                TotalPrice = totalPrice
            };
            return Ok(basket);
        }


        [HttpGet("purchased/basket/pay")]
        public async Task<ActionResult> PayForWishes()
        {
            var userId = _userService.GetUserId();

            var wishes = _context.Wishes
                .Where(w => w.PurchaserId.ToString() == userId && w.PaymentStatus == PaymentStatus.Pending)
                .ToList();

            if (!wishes.Any())
            {
                return BadRequest("No pending wishes found for payment.");
            }

            foreach (var wish in wishes)
            {
                wish.PaymentStatus = PaymentStatus.Paid;
            }

            await _context.SaveChangesAsync();

            return Ok(new { message = "Payment successful for all pending wishes.", wishes });
        }

//not ready
        [HttpGet("purchased/basket/pay/cancel")]
        public async Task<ActionResult> CancelPayForWishes()
        {
            var userId = _userService.GetUserId();

            var wishes = _context.Wishes
                .Where(w => w.PurchaserId.ToString() == userId && w.PaymentStatus == PaymentStatus.Pending)
                .ToList();

            if (!wishes.Any())
            {
                return BadRequest("No pending wishes found for payment.");
            }

            foreach (var wish in wishes)
            {
                wish.PurchaserId = null;
            }

            await _context.SaveChangesAsync();

            return Ok(new { message = "Payment successful cancelled.", wishes });
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var wish = _context.Wishes.Where(w => w.Id == id).FirstOrDefault();

            if (wish is null)
            {
                return NotFound();
            }

            _context.Wishes.Remove(wish);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult<WishResponseList> Update(WishResponseList request)
        {
            var wishToUpdate = _context.Wishes.FirstOrDefault(w => w.Id == request.Id);

            if (wishToUpdate is null)
            {
                return NotFound();
            }

            wishToUpdate.Name = request.Name;
            wishToUpdate.Description = request.Description;
            wishToUpdate.Price = request.Price;
            wishToUpdate.WebPageLink = request.WebPageLink;
            _context.Wishes.Update(wishToUpdate);
            _context.SaveChanges();
            return Ok(WishToResponseList(wishToUpdate));
        }

        [HttpPut("purchase/{id}")]
        public ActionResult<WishResponseList> Update(int id)
        {
            var wishToUpdate = _context.Wishes.FirstOrDefault(w => w.Id == id);

            if (wishToUpdate is null)
            {
                return NotFound();
            }

            var userId = _userService.GetUserId();

            wishToUpdate.PurchaserId = int.Parse(userId);
            _context.Wishes.Update(wishToUpdate);
            _context.SaveChanges();
            return Ok(WishToResponseList(wishToUpdate));
        }



    }
}