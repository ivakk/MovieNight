using Microsoft.AspNetCore.Authentication.Cookies;
using MovieNight_BusinessLogic;
using MovieNight_BusinessLogic.Services;
using MovieNight_DataAccess.Controllers;
using MovieNight_InterfacesDAL.IManagers;
using MovieNight_InterfacesLL.IServices;
using MovieNight_InterfacesLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

builder.Services.AddTransient<IUserManager, UserManager>();
builder.Services.AddTransient<IUserDALManager, UserDALManager>();
builder.Services.AddTransient<IMovieAlgoManager, MovieAlgoManager>();
builder.Services.AddTransient<IMovieManager, MovieManager>();
builder.Services.AddTransient<IMovieDALManager, MovieDALManager>();
builder.Services.AddTransient<ISeriesAlgoManager, SeriesAlgoManager>();
builder.Services.AddTransient<ISeriesManager, SeriesManager>();
builder.Services.AddTransient<ISeriesDALManager, SeriesDALManager>();
builder.Services.AddTransient<ICategoryManager, CategoryManager>();
builder.Services.AddTransient<ICategoryDALManager, CategoryDALManager>();
builder.Services.AddTransient<IFavouritesManager, FavouritesManager>();
builder.Services.AddTransient<IFavouritesDALManager, FavouritesDALManager>();
builder.Services.AddTransient<IWatchLaterManager, WatchLaterManager>();
builder.Services.AddTransient<IWatchLaterDALManager, WatchLaterDALManager>();
builder.Services.AddTransient<IWatchingManager, WatchingManager>();
builder.Services.AddTransient<IWatchingDALManager, WatchingDALManager>();
builder.Services.AddTransient<IFinishedManager, FinishedManager>();
builder.Services.AddTransient<IFinishedDALManager, FinishedDALManager>();
builder.Services.AddTransient<IRatingManager, RatingManager>();
builder.Services.AddTransient<IRatingDALManager, RatingDALManager>();
builder.Services.AddTransient<ICommentManager, CommentManager>();
builder.Services.AddTransient<ICommentDALManager, CommentDALManager>();
builder.Services.AddTransient<IPasswordHashingManager, PasswordHashingManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();
