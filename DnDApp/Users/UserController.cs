using DnDApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DnDApp.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly DndDataContext _context;
        private readonly IUserUtilities _utilities;
        public UserController(DndDataContext context, IUserUtilities util)
        {
            _context = context;
            _utilities = util;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAccount(UserView user)
        {
            user.Password = _utilities.Hash(user.Password);

            var ExistingUser = await _context.Users.SingleOrDefaultAsync(u => u.UserName == user.UserName);
            if (ExistingUser != null)
            {
                return BadRequest(new { message = "Username already taken." });
            }

            _context.Users.Add(_utilities.ConvertToUserModel(user));
            _context.SaveChanges();

            return Ok(new { success = true}); 


        }

        [HttpPost("login")]
        public async Task<ActionResult<int>> LoginAccount(UserView user, TokenProvider tokenProvider)
        {
            var ExistingUser = await _context.Users.SingleOrDefaultAsync(u => u.UserName == user.UserName);

            if (ExistingUser == null) 
            { 
                return BadRequest(new { message = "User not found." });
            }

            bool verified = _utilities.VerifyUser(user.Password, ExistingUser.HashedPassword);

            if (!verified)
            {
                return BadRequest(new { message = "The password is incorrect." });
            }

            string token = tokenProvider.Create(ExistingUser);

            return Ok(new { success = true, token = token });       
        }


    }
}
