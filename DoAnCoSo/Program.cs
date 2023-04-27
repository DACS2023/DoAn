using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DoAnCoSo.Areas.Identity.Data;
using Microsoft.CodeAnalysis.Options;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("QuanLyHoiThaoDBContextConnection") ?? throw new InvalidOperationException("Connection string 'QuanLyHoiThaoDBContextConnection' not found.");

builder.Services.AddDbContext<QuanLyHoiThaoDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<QuanLyHoiThaoUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<QuanLyHoiThaoDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(optinons =>
{
    optinons.Password.RequireUppercase = false;
});

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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
