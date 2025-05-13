using System.ComponentModel.DataAnnotations;

namespace DnDApp.Users
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string HashedPassword { get; set; }
    }
}
