using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace DnDApp.Users
{
    public class UserUtilities : IUserUtilities
    {

        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int HashIterations = 100000;

        private readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

        public string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, HashIterations, Algorithm, HashSize);

            return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
        }

        public bool VerifyUser(string plainPassword, string hashedPassword)
        {
            string[] parts = hashedPassword.Split('-');
            byte[] hash = Convert.FromHexString(parts[0]);
            byte[] salt = Convert.FromHexString(parts[1]);

            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(plainPassword, salt, HashIterations, Algorithm, HashSize);

            return CryptographicOperations.FixedTimeEquals(hash, inputHash);
        }

        public UserModel ConvertToUserModel(UserView v)
        {
            var UserModel = new UserModel();
            UserModel.UserName = v.UserName;
            UserModel.HashedPassword = v.Password;

            return UserModel;
        }
    }
}
