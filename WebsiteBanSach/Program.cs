using Microsoft.EntityFrameworkCore;
using System;
using WebsiteBanSach.Controllers;
using WebsiteBanSach.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "UserSession";
    options.Cookie.IsEssential = true;
});
builder.Services.AddDistributedMemoryCache();

// Đăng ký DbContext nếu bạn sử dụng Entity Framework
builder.Services.AddDbContext<DbBanSachContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký dịch vụ XMLToSQL vào DI Container
builder.Services.AddScoped<WebsiteBanSach.Models.XMLToSQL>(); // hoặc AddTransient<XMLToSQL>();

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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
