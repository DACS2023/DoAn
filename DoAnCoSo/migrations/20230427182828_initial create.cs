using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnCoSo.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "giaiDaus",
                columns: table => new
                {
                    IdgiaiDau = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGiaiDau = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IdloaiGiaiDau = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "Date", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "Date", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_giaiDaus", x => x.IdgiaiDau);
                });

            migrationBuilder.CreateTable(
                name: "loaiGiaiDaus",
                columns: table => new
                {
                    IdloaiGiaiDau = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiGiaiDaus", x => x.IdloaiGiaiDau);
                });

            migrationBuilder.CreateTable(
                name: "quanLyHoiThaoUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "Date", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quanLyHoiThaoUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiaiDauLoaiGiaiDau",
                columns: table => new
                {
                    GiaiDausIdgiaiDau = table.Column<int>(type: "int", nullable: false),
                    ThiDausIdloaiGiaiDau = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaiDauLoaiGiaiDau", x => new { x.GiaiDausIdgiaiDau, x.ThiDausIdloaiGiaiDau });
                    table.ForeignKey(
                        name: "FK_GiaiDauLoaiGiaiDau_giaiDaus_GiaiDausIdgiaiDau",
                        column: x => x.GiaiDausIdgiaiDau,
                        principalTable: "giaiDaus",
                        principalColumn: "IdgiaiDau",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiaiDauLoaiGiaiDau_loaiGiaiDaus_ThiDausIdloaiGiaiDau",
                        column: x => x.ThiDausIdloaiGiaiDau,
                        principalTable: "loaiGiaiDaus",
                        principalColumn: "IdloaiGiaiDau",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GiaiDauLoaiGiaiDau_ThiDausIdloaiGiaiDau",
                table: "GiaiDauLoaiGiaiDau",
                column: "ThiDausIdloaiGiaiDau");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiaiDauLoaiGiaiDau");

            migrationBuilder.DropTable(
                name: "quanLyHoiThaoUsers");

            migrationBuilder.DropTable(
                name: "giaiDaus");

            migrationBuilder.DropTable(
                name: "loaiGiaiDaus");
        }
    }
}
