
using DawoodShopNew.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DawoodShopDbConnection") ?? throw new InvalidOperationException("Connection string 'DawoodShopDbConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(option=>option.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.IgnoreCycles);
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICategoriesRepository,CategoriesRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IshoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

builder.Services.AddDbContext<DawoodShopNewDbContext>(option => option.UseSqlServer(builder.Configuration["ConnectionStrings:DawoodShopDbConnection"]));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<DawoodShopNewDbContext>();


builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor();

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
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapBlazorHub();
app.MapFallbackToPage("/app/{*catchall}","/App/Index");


app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
DbInitialez.Seed(app);
app.Run();
