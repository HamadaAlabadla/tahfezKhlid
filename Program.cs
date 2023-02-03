using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tahfez.Models;
using tahfezKhalid.Data;
using tahfezKhalid.Hubs;
using tahfezKhalid.Models;
using tahfezKhalid.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("tahfezKhalidContextConnection") ?? throw new InvalidOperationException("Connection string 'tahfezKhalidContextConnection' not found.");

builder.Services
    .AddDbContext<tahfezKhalidContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.EnableSensitiveDataLogging(true);
});

builder.Services
    .AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<tahfezKhalidContext>();

builder.Services.AddTransient<IManageSessionService, ManageSessionService>();
builder.Services.AddTransient<IManageUserSessionService, ManageUserSessionService>();
builder.Services.AddTransient<IManageDeleteUserService, ManageDeleteUserService>();
builder.Services.AddTransient<IManageStudentService, ManageStudentService>();
builder.Services.AddTransient<IManageDailyReportService, ManageDailyReportService>();
builder.Services.AddTransient<IManageAbsenceService, ManageAbsenceService>();
builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services
    .AddMvc()
    .AddRazorPagesOptions(options =>
    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", ""));
builder.Services.AddRazorPages();



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
app.UseAuthentication(); ;

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<FromSaved>("/FromSaved");
app.MapHub<LogoChange>("/newLogo");
app.MapHub<AddAbsence>("/AddAbsence");
app.Run();
