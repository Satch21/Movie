
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Movie.Models;
using System.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);

var MovieFront = "AuthorizeFront";
// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieContextConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MovieFront,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173");
                      });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





//builder.Services
//    .AddIdentityApiEndpoints<Utilisateur>()
//    .AddEntityFrameworkStores<MovieContext>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MovieFront);

app.UseAuthorization();

app.MapControllers();

app.Run();
