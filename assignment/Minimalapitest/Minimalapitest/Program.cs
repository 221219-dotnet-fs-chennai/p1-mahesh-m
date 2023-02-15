
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MoviesContext>(options => options.UseInMemoryDatabase("MovieList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.MapGet("movies/getall", (MoviesContext m) => m.movies.ToListAsync());


app.MapPost("movies/addmovies", (Movies mv, MoviesContext m) =>
{
    m.movies.Add(mv);
    m.SaveChanges();    
});


app.MapGet("movies/getby/{id}", (int id, MoviesContext m) => m.movies.FindAsync(id));

app.MapPut("movies/updatename/{id}", async (string name, int id, MoviesContext m) =>
{
    var movie = await m.movies.FindAsync(id);
    if (movie != null)
    {
        movie.Title = name;
        m.SaveChanges();
    }
});


app.MapDelete("movies/deleteby/{id}", async (int id, MoviesContext m) =>
{
    var movie = await m.movies.FindAsync(id);
    if (movie != null)
    {
        m.movies.Remove(movie); m.SaveChanges();
    }

});

app.Run();









public class Movies {

    public int Id { get; set; }
    public string ? Title { get; set; }
    public string ? Director { get; set; }
}

public  class MoviesContext : DbContext
{
   public  MoviesContext(DbContextOptions<MoviesContext> options): base(options) { }

    public DbSet<Movies> movies { get; set; }

}