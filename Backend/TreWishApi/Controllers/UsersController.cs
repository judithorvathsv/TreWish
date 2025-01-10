using System.Globalization;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using TreWishApi.Models;
using TreWishApi.Models.Dtos;

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

       





    }
}