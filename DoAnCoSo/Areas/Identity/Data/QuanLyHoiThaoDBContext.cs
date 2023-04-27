using DoAnCoSo.Areas.Identity.Data;
using DoAnCoSo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoAnCoSo.Areas.Identity.Data;

public class QuanLyHoiThaoDBContext : DbContext
{
    public QuanLyHoiThaoDBContext(DbContextOptions<QuanLyHoiThaoDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    //public QuanLyHoiThaoDBContext : IdentityDbContext<GiaiDau>
    //public GiaiDauDbContext(DbContextOptions<QuanLyHoiThaoDBContext> options) : base(options) { }
    public DbSet<GiaiDau> giaiDaus { get; set; }
    //public LoaiGiaiDauDbContext(DbContextOptions<LoaiGiaiDau> options) : base(options) { }
    public DbSet<LoaiGiaiDau> loaiGiaiDaus { get; set; }
    public DbSet<QuanLyHoiThaoUser> quanLyHoiThaoUsers { get; set; }
}
