using DnDApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DnDApp.Character
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

        [HttpPost]
        public ActionResult<int> RegisterAccount(CharacterModel character)
        {
        }


    }
}
