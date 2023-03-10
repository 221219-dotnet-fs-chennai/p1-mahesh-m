using EntityFramework.newEntities;
using Microsoft.EntityFrameworkCore;
using EntityFramework;
using BusinessLogic;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration.GetConnectionString("TrainerDetails");
builder.Services.AddDbContext<TrainerDetailsContext>(options => options.UseSqlServer(config));
builder.Services.AddScoped<ILogic, Logic>();
builder.Services.AddScoped<IRepo,EFRepo>();
builder.Services.AddScoped<IValidator, Validation>();
builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseCors("corspolicy");

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
