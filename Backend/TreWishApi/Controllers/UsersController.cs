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
    }
}