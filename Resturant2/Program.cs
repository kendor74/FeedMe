using FeedMe.Models.MessageHandler;
using FeedMe.Models.UserMessagesHandler;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resturant2.Data;
using Resturant2.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Database Connection Injection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var resturantConnectionString = builder.Configuration.GetConnectionString("ResturantConnection");
builder.Services.AddDbContext<ResturantDbContext>(options =>
    options.UseSqlServer(resturantConnectionString));

//Interfaces Injection
builder.Services.AddScoped<ImessageFunc, MessagesHelper>();
builder.Services.AddScoped<IuserUserMessagessFunc , UserMessageHelper>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
