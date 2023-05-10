using DoAnCoSo.Areas.Identity.Data;
//using DoAnCoSo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoAnCoSo.Areas.Identity.Data;

public class QuanLyHoiThaoDBContext : IdentityDbContext<QuanLyHoiThaoUser>
{
  

    public QuanLyHoiThaoDBContext()
    {

    }

    public QuanLyHoiThaoDBContext(DbContextOptions<QuanLyHoiThaoDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
    }
        public DbSet<GiaiDau> giaiDaus { get; set; }
        //public LoaiGiaiDauDbContext(DbContextOptions<LoaiGiaiDau> options) : base(options) { }
        public DbSet<LoaiGiaiDau> loaiGiaiDaus { get; set; }
        public DbSet<QuanLyHoiThaoUser> quanLyHoiThaoUsers { get; set; }
        public DbSet<ThiSinh> ThiSinhs { get; set; }

    public DbSet<LichThiDau> lichThiDaus { get; set; }
    public DbSet<Doi> dois { get; set; }

    public object Session { get; internal set; }
}
