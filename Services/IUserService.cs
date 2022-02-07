using MinimalJwt.Model;

namespace MinimalJwt.Services;
public interface IUserService
{
    public User Get(UserLogin userLogin);
}
