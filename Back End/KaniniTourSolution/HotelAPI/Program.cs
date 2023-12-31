using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.Context;
using HotelAPI.Models.DTO;
using HotelAPI.Repository;
using HotelAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

builder.Services.AddDbContext<HotelContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("myConn"));
});


builder.Services.AddScoped<IRepo<Hotel, int>, HotelRepo>();
builder.Services.AddScoped<IRoomRepo<Room,int>, RoomRepo>();
builder.Services.AddScoped<IAmenityRepo<HotelAmenity>, HotelAmenityRepo>();
builder.Services.AddScoped<IAmenityRepo<RoomAmenity>, RoomAmenityRepo>();

builder.Services.AddScoped<IHotelService<Hotel, HotelDTO, int>, HotelService>();
builder.Services.AddScoped<IRoomService<RoomDTO, Room, int>, RoomService>();
builder.Services.AddScoped<IAmenityService<HotelAmenity>, HotelAmenityService>();
builder.Services.AddScoped<IAmenityService<RoomAmenity>, RoomAmenityService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

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
