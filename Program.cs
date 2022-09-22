var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication();

var app = builder.Build();


app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();

app.MapDefaultControllerRoute();

app.Run();
