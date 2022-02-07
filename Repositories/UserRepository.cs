using MinimalJwt.Models;

namespace MinimalJwt.Repositories;

public class UserRepository
{
    public static List<User> Users = new()
    {
        new()
        {
            Username = "luke_admin",
            EmailAddress = "g@gmail.com",
            Password = "1234",
            GivenName = "Luke",
            Surname = "Rogers",
            Role = "standard"
        },
        new()
        {
            Username = "ronanzin",
            EmailAddress = "g123@gmail.com",
            Password = "saopaulo123",
            GivenName = "Gabriel",
            Surname = "Morelli",
            Role = "admin"
        }
    };
}