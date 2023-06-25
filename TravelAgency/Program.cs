using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Data.Base;
using TravelAgency.Data.Repository;
using TravelAgency.Data.Repository.InterfacesRepo;
using TravelAgency.Models;

var builder = WebApplication.CreateBuilder(args);

// Строка подключения
string connection = builder.Configuration.GetConnectionString("DbConn");

builder.Services.AddDbContext<TravelAgencyContext>(options => options.UseSqlServer(connection));

// Сопоставление Интерфейсов и классов
builder.Services.AddScoped<IEntityBaseRepository<City>, EntityBaseRepository<City>>();
builder.Services.AddScoped<IEntityBaseRepository<HotelStarRating>, EntityBaseRepository<HotelStarRating>>();
builder.Services.AddScoped<IEntityBaseRepository<MealType>, EntityBaseRepository<MealType>>();
builder.Services.AddScoped<IEntityBaseRepository<TravelService>, EntityBaseRepository<TravelService>>();
builder.Services.AddScoped<IEntityBaseRepository<HotelFacility>, EntityBaseRepository<HotelFacility>>();
builder.Services.AddScoped<IEntityBaseRepository<RoomAmenity>, EntityBaseRepository<RoomAmenity>>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<ITourRepository, TourRepository>();
builder.Services.AddScoped<IHomeRepository, HomeRepository>();



// Add services to the container.
builder.Services.AddControllersWithViews();


// Работа с авторизированными пользователями
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<TravelAgencyContext>();




var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});



app.Run();
