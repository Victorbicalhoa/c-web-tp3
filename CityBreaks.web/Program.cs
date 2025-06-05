using Microsoft.EntityFrameworkCore;
using CityBreaks.Web.Data;
using CityBreaks.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CityBreaksContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CityBreaksConnection")));

builder.Services.AddRazorPages();

builder.Services.AddScoped<ICityService, CityService>();

builder.Services.AddScoped<IPropertyService, PropertyService>();


var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();
