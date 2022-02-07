using MinimalJwt.Model;
using MinimalJwt.Repositories;

namespace MinimalJwt.Services;

public class UserService : IUserService
{
    public User Get(UserLogin userLogin)
    {
        User user = UserRepository.Users.FirstOrDefault(o => o.Username.Equals
        (userLogin.Username, StringComparison.OrdinalIgnoreCase) && o.Password.Equals
        (userLogin.Password));
        return user;
    }
}