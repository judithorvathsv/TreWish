using System.Globalization;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using TreWishApi.Models;
using TreWishApi.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using TreWishApi.Interfaces;

namespace TreWishApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        public UsersController(ApplicationDbContext context, IUserService userService)
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

        private UserStatisticsResponse UserWithWishListToUserStatisticsResponse(User user)
        {
            var responseWithWishList = UserWithWishListsToResponse(user);
            var statisticsResponse = new UserStatisticsResponse()
            {
                Name = user.Name,
                WishedWishes = responseWithWishList.WishedWishes?.Count(),
                PurchasedWishes = responseWithWishList.PurchasedWishes?.Count()
            };

            return statisticsResponse;
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _context.Users.Find(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(UserWithWishListsToResponse(user));
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
            _userService.SetUserId(user.Id.ToString());

            var response = UserWithWishListsToResponse(user);
            return CreatedAtAction("Get", new { id = user.Id }, response);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetUserListWithWishes()
        {
            var userResponseList = new List<UserStatisticsResponse>();

            var userWithPurchasedAndWantedWishes = await _context.Users
                                                            .Include(u => u.WishedWishes)
                                                            .ThenInclude(w => w.Purchaser)
                                                            .Include(u => u.PurchasedWishes)
                                                            .ThenInclude(w => w.Wisher)
                                                            .ToListAsync();

            foreach (var user in userWithPurchasedAndWantedWishes)
            {
                var response = UserWithWishListToUserStatisticsResponse(user);
                userResponseList.Add(response);
            }
            return Ok(userResponseList);
        }


        [HttpPost("login/sendUserEmail")]
        public async Task<IActionResult> Login([FromBody] UserRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == request.Name);
            if (user is null)
            {
                return NotFound();
            }
            _userService.SetUserId(user.Id.ToString());
            return Ok(new { message = "User logged in successfully" });
        }


        [HttpPost("register/sendUserEmail")]
        public async Task<IActionResult> Register([FromBody] UserRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == request.Name);
            if (user is null)
            {
                await Create(request);
                return Ok(new { message = "User registered successfully" });
            }

            return Ok(new { message = "User already registered successfully" });
        }
    }








}