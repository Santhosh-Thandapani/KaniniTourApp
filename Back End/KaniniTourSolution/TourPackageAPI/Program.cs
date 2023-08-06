using Microsoft.EntityFrameworkCore;
using TourPackageAPI.Interfaces;
using TourPackageAPI.Models;
using TourPackageAPI.Models.Context;
using TourPackageAPI.Models.DTOs;
using TourPackageAPI.Repositorys;
using TourPackageAPI.Service;

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

builder.Services.AddDbContext<TourContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("myConn"));
});

builder.Services.AddScoped<IRepo<Package, int>, PackageRepo>();
builder.Services.AddScoped<IITineraryRepo<Itinerary>,ItineraryRepo>();
builder.Services.AddScoped<IActivityRepo<Activity>, ActivityRepo>();
builder.Services.AddScoped<IAccoRepo<Accomdation>, AccomadationRepo>();

builder.Services.AddScoped<IService<PackageDTO, int, Package>, PackageService>();

var app = builder.Build();

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
