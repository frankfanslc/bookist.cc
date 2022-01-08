using Bookist;
using Bookist.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// 注册服务
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    var conStr = config.GetConnectionString("BookistConnection");
    opt.UseMySql(conStr, ServerVersion.Parse("8.0"));
});
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x => x.LoginPath = "/account/login");

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAntDesign();

builder.Services.AddTransient<BookService>();

var app = builder.Build();

// 注册中间件
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("home", "",
        new { controller = "Home", Action = "Index", pageNo = 1 });
    endpoints.MapControllerRoute("page", "page/{pageNo:int}",
        new { Controller = "Home", Action = "Index"});
    endpoints.MapDefaultControllerRoute();

    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/_Host");
});

app.Run();
