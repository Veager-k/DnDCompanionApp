using DnDApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DnDApp.Character
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private readonly DndDataContext _context;
        public CharacterController(DndDataContext context)
        {
            _context = context;
        }

        [HttpGet("GetCharacters")]
        public ActionResult<List<CharacterModel>> GetCharacters()
        {
            var characters = _context.Characters.ToList();

            return characters;
        }

        [HttpPost]
        public ActionResult<int> AddCharacter(CharacterModel character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();

            return character.Id;
        }


    }
}
