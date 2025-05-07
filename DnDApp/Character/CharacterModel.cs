using System.ComponentModel.DataAnnotations;

namespace DnDApp.Character
{
    public class CharacterModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Class {  get; set; }
        public string Race { get; set; }

    }
}
