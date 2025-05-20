using DnDApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DnDApp.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly DndDataContext _context;
        public UserController(DndDataContext context)
        {
            _context = context;
        }

        //TODO: add hash + salt
        //TODO: asyc
        [HttpPost("register")]
        public IActionResult RegisterAccount(UserView user)
        {
            user.Password = user.Password; // TODO: add hash + salt

            var ExistingUser = _context.Users.Where(
                x => x.UserName == user.UserName ||
                x.HashedPassword == user.Password).FirstOrDefault();

            if (ExistingUser != null)
            {
                return BadRequest(new { message = "Username or Password is already taken." });
            }

            _context.Users.Add(UserUtilities.ConvertToUserModel(user));
            _context.SaveChanges();

            return Ok(new { success = true}); 


        }

        // TODO: jwt token
        //       hash + salt
        [HttpPost("login")]
        public ActionResult<int> LoginAccount(UserView user, TokenProvider tokenProvider)
        {
            user.Password = user.Password; // TODO: add hash + salt

            var ExistingUser = _context.Users.Where(
                x => x.UserName == user.UserName &&
                x.HashedPassword == user.Password).FirstOrDefault();

            if (ExistingUser == null) 
            { 
                return BadRequest(new { message = "Username or Password does not match." });
            }

            string token = tokenProvider.Create(ExistingUser);

            return Ok(new { success = true, token = token });
        }


    }
}
