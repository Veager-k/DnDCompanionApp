using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DnDApp.Accounts
{
    public class UserModel : IdentityUser
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string HashedPassword { get; set; }
    }
}
