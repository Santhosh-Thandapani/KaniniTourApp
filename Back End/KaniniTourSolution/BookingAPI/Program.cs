using BookingAPI.Interfaces;
using BookingAPI.Models;
using BookingAPI.Models.Context;
using BookingAPI.Models.DTOs;
using BookingAPI.Repositorys;
using BookingAPI.Services;
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

builder.Services.AddDbContext<BookingContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("myConn"));
});

builder.Services.AddScoped<IRepo<HotelBook, int>, HotelBookRepo>();
builder.Services.AddScoped<IRepo<HotelGuest,int>,HotelGuestRepo>();
builder.Services.AddScoped<IRepo<PackageBook, int>, PackageBookRepo>();
builder.Services.AddScoped<IRepo<PackageGuest, int>, PackageGuestRepo>();

builder.Services.AddScoped<IBookingService<HotelBookDTO, int,CancelDTO>, HotelBookingService>();
builder.Services.AddScoped<IBookingService<PackageBookDTO, int, CancelDTO>, PackageBookingService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AngularCORS");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
