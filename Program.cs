using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MinimalJwt.Model;
using MinimalJwt.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateActor = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    }
);
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IMovieService, MovieService>();
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();
app.UseSwagger();
app.UseAuthorization();
app.MapGet("/", () => "Hello World!");
app.MapPost("/create", (Movie movie, IMovieService service) => Create(movie, service));
app.MapGet("/get", (int id, IMovieService service) => Get(id, service));
app.MapGet("/list", (IMovieService service) => ListMovies(service));
app.MapPut("/update", (Movie newMovie, IMovieService service) => Update(newMovie, service));
app.MapDelete("/delete", (int id, IMovieService service) => Delete(id, service));

IResult Create(Movie movie, IMovieService service)
{
    var result = service.Create(movie);
    return Results.Ok(result);
}
IResult Get(int id, IMovieService service)
{
    var movie = service.Get(id);
    if (movie is null) return Results.NotFound("Movie Not found");
    return Results.Ok(movie);
}
IResult ListMovies(IMovieService service)
{
    var movies = service.List();
    return Results.Ok(movies);
}
IResult Update(Movie newMovie, IMovieService service)
{
    var updatedMovie = service.Update(newMovie);
    if (updatedMovie is null) Results.NotFound("Movie not found");
    return Results.Ok(updatedMovie);
}

IResult Delete(int id, IMovieService service)
{
    var result = service.Delete(id);
    if (!result) Results.BadRequest("Something went wrong");
    return Results.Ok(result);
}
app.UseSwaggerUI();
app.Run();
