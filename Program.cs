using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("Cookie")
    .AddCookie("Cookie", config =>
    {
        config.LoginPath = "/Admin/Login";
        config.AccessDeniedPath = "/Home/AccessDenied";
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administrator", builder =>
    {
        builder.RequireClaim(ClaimTypes.Role, "Administrator");
    });
    options.AddPolicy("Manager", builder =>
    {
        builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, "Manager")
        || x.User.HasClaim(ClaimTypes.Role, "Administrator"));
    });
});

builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseRouting();

//Обязательно в таком порядке, иначе авторизация не сработает!
app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
