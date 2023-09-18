using CarWorkshop.Infrastucture.Extensions;
using CarWorkshop.Infrastucture.Persistance;
using CarWorkshop.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using CarWorkshop.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
//builder.Configuration.GetConnectionString()
builder.Services.AddInfrastucture(builder.Configuration);

builder.Services.AddApplication();

builder.Services.AddDbContext<CarWorkshopDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("CarWorkshop")
    ));




var app = builder.Build();

var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<CarWorkshopSeeder>();

await seeder.Seed();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();

public partial class Program { }