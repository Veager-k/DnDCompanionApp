namespace DnDApp.Users
{
    public static class UserUtilities
    {
        public static UserModel ConvertToUserModel(UserView v)
        {
            var UserModel = new UserModel();
            UserModel.UserName = v.UserName;
            UserModel.HashedPassword = v.Password;

            return UserModel;
        }
    }
}
