using FeedBackAPI.Interfaces;
using FeedBackAPI.Models;
using FeedBackAPI.Models.Context;
using FeedBackAPI.Models.DTO;
using FeedBackAPI.Repositorys;
using FeedBackAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opts =>
{
    opts.AddPolicy("AngularCORS", options =>
    {
        options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

builder.Services.AddDbContext<FeedbackContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("myConn"));
});

builder.Services.AddScoped<IRepo<HotelFeedback, int>, HotelFBRepo>();
builder.Services.AddScoped<IRepo<PackageFeedback,int>, PackageFBRepo>();
builder.Services.AddScoped<IService<HotelFeedback, int, HotelDTO>, HotelFBService>();
builder.Services.AddScoped<IService<PackageFeedback, int, PackageDTO>, PackageFBService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
