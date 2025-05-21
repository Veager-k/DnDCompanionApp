namespace DnDApp.Users
{
    public interface IUserUtilities
    {
        string Hash(string password);
        bool VerifyUser(string plainPassword, string hashedPassword);
        UserModel ConvertToUserModel(UserView v);
        string CreateJwtToken(UserModel user);
    }
}