using System.Globalization;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using TreWishApi.Models;
using TreWishApi.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace TreWishApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        private UserResponse UserToResponse(User user)
        {
            return new UserResponse()
            {
                Name = user.Name,
            };
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


        private UserResponse UserWithWishListsToResponse(User user)
        {
            var allWishesForUser = _context.Wishes.Where(w => w.PurchaserId == user.Id || w.WisherId == user.Id);

            var wishedList = new List<WishResponse>();
            var purchasedList = new List<WishResponse>();

            foreach (var wish in allWishesForUser)
            {
                if (wish.PurchaserId == user.Id)
                {

                    purchasedList.Add(WishToResponse(wish));
                }
                else if (wish.WisherId == user.Id)
                {
                    wishedList.Add(WishToResponse(wish));
                }
            }

            var response = new UserResponse()
            {
                Name = user.Name,
                WishedWishes = wishedList,
                PurchasedWishes = purchasedList
            };

            return response;
        }



        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _context.Users.Find(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(UserToResponse(user));
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRequest request)
        {
            User user = new User()
            {
                Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(request.Name.ToLower())
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            var response = UserToResponse(user);

            return CreatedAtAction("Get", new { id = user.Id }, response);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUserListWithWishes()
        {
            var userResponseList = new List<UserResponse>();

            var userWithPurchasedAndWantedWishes = await _context.Users
                                                            .Include(u => u.WishedWishes)
                                                            .ThenInclude(w => w.Purchaser)
                                                            .Include(u => u.PurchasedWishes)
                                                            .ThenInclude(w => w.Wisher)
                                                            .ToListAsync();

            foreach (var user in userWithPurchasedAndWantedWishes)
            {
                var response = UserWithWishListsToResponse(user);
                userResponseList.Add(response);
            }
            return Ok(userResponseList);
        }





    }
}