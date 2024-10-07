using leave_mgt;
using leave_mgt.Contracts;
using leave_mgt.Data;
using leave_mgt.Mappings;
using leave_mgt.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//IServiceCollection.AddAutoMapper

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

//Add references for Repository and Contacts to Startup/Program file
builder.Services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
builder.Services.AddScoped<ILeaveHistoryRepository, LeaveHistoryRepository>();
builder.Services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

builder.Services.AddAutoMapper(typeof(Maps));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//This enables Account confirmation through email after registering
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

//This is disables Account confirmation through email after registering
builder.Services.AddDefaultIdentity<IdentityUser>().
    AddRoles<IdentityRole>().
    AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Ensure the roles are created when the app starts
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    //await RoleSeeder.SeedRolesAsync(roleManager);
    SeedData.Seed(userManager, roleManager);
}
/*
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    //await SeedRolesAsync(roleManager);

    await RoleSeeder.SeedRolesAsync(roleManager);
}
*/

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
app.UseAuthentication();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();


//SeedData.Seed(userManager, roleManager);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
