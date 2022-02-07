using MinimalJwt.Models;

namespace MinimalJwt.Repositories;

public class MovieRepository
{
    public static List<Movie> Movies = new()
    {
        new() { Id = 1, Title = "Eternals", Description = "So weaks", Rating = 6.8 },
        new() { Id = 2, Title = "Avengers", Description = "To good", Rating = 10.0 },
    };
}