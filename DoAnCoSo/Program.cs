using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DoAnCoSo.Areas.Identity.Data;
using Microsoft.CodeAnalysis.Options;
//using DoAnCoSo.Models;
using Microsoft.Extensions.DependencyInjection;
using DoAnCoSo.Areas.Admin.Pages.Role;



var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("QuanLyHoiThaoDBContextConnection") ?? throw new InvalidOperationException("Connection string 'QuanLyHoiThaoDBContextConnection' not found.");

builder.Services.AddDbContext<QuanLyHoiThaoDBContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<QuanLyHoiThaoUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<QuanLyHoiThaoDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<RoleShowModel>();
builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(optinos =>
{
    // Thiết lập về Password
    optinos.Password.RequireDigit = false; //   phải có số
    optinos.Password.RequireLowercase = false; //   phải có chữ thường
    optinos.Password.RequireNonAlphanumeric = false; //   ký tự đặc biệt
    optinos.Password.RequireUppercase = false; //  chữ in
    optinos.Password.RequiredLength = 6; // Số ký tự tối thiểu của password
    optinos.Password.RequiredUniqueChars = 0; // Số ký tự riêng biệt

    // Cấu hình Lockout - khóa user
    optinos.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
    optinos.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
    optinos.Lockout.AllowedForNewUsers = true;

    // Cấu hình về User.
    optinos.User.AllowedUserNameCharacters = // các ký tự đặt tên user
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    optinos.User.RequireUniqueEmail = true;  // Email là duy nhất

    // Cấu hình đăng nhập.
    optinos.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
    optinos.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "QuanLyHoiThaoDBContext";
});

builder.Services.AddIdentity<QuanLyHoiThaoUser, IdentityRole>(options =>
{
    // Configure password requirements, lockout settings, etc.
})
.AddEntityFrameworkStores<QuanLyHoiThaoDBContext>()
.AddDefaultTokenProviders()
.AddRoleManager<RoleManager<IdentityRole>>()
.AddDefaultUI()
.AddDefaultTokenProviders();

builder.Services.AddScoped<UserManager<QuanLyHoiThaoUser>>();
builder.Services.AddScoped<SignInManager<QuanLyHoiThaoUser>>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Configure password, lockout, user, and sign-in options.
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "QuanLyHoiThaoDBContext";
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();