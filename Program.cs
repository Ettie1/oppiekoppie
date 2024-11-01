using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using oppiekoppie.Data;
using oppiekoppie.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var mysqlconn = builder.Configuration.GetConnectionString("mysqlconn");
builder.Services.AddDbContext<OppieKoppieContext>(options => 
options.UseMySql(mysqlconn, ServerVersion.Parse("8.0.36-mysql"), null));

var webconn = builder.Configuration.GetConnectionString("webconn");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(servOpt => {servOpt.CommandTimeout(30); servOpt.EnableRetryOnFailure(); servOpt.UseAzureSqlDefaults(enable: true); } ) );

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
