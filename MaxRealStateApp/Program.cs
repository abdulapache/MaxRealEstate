using MaxDataAccess;
using MaxDataAccess.Entites;
using MaxRealStateApp.Configuration;
using Microsoft.EntityFrameworkCore;
using MaxRealStateApp.Utilites;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MaxRealStateContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MaxDb")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddTransient<IAppSettings, AppSettings>();
builder.Services.AddTransient<IFileManager, FileManager>();
builder.Services.AddTransient<ICookieHelper, CookiesHelper>();
builder.Services.AddHttpContextAccessor();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ClientSide}/{action=Index}/{id?}");

app.Run();
