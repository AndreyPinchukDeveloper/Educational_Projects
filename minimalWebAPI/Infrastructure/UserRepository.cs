public class UserRepository : IUserRepository
{
    private List<UserDto> _users => new()
    {
        new UserDto("Andre", "654"),
        new UserDto("NewAndre", "754"),
        new UserDto("NotNewAndre", "454")
    };
    public UserDto GetUser(UserModel userModel) =>
        _users.FirstOrDefault(u =>
            string.Equals(u.username, userModel.UserName)&&
            string.Equals(u.password, userModel.Password))??
            throw new Exception();
    )
}