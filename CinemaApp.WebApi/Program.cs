using CinemaApp.Business.Managers;
using CinemaApp.Business.Services;
using CinemaApp.Data.Context;
using CinemaApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // controller kullanýlacak

builder.Services.AddEndpointsApiExplorer(); // api projesi

builder.Services.AddDbContext<CinemaAppContext>(options => options.UseInMemoryDatabase("CinemaAppDb"));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IMovieService, MovieManager>();

builder.Services.AddSwaggerGen();
// Swashbuckle.AspNetCore indirmeyi unutma.

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // http protokolleri eklendi.
app.UseAuthentication(); // her zaman ekle.
app.MapControllers();

//app.MapGet("/", () => "Hello World!");

app.Run();
