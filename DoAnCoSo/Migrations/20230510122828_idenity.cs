using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnCoSo.Migrations
{
    /// <inheritdoc />
    public partial class idenity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BomonThiDau",
                table: "Users",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdDoi",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Users",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "lichThiDaus",
                columns: table => new
                {
                    IdTranDau = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDoi1 = table.Column<int>(type: "int", nullable: false),
                    IdDoi2 = table.Column<int>(type: "int", nullable: false),
                    Trangthai = table.Column<bool>(type: "bit", nullable: false),
                    Thoigianbatdau = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Tiso = table.Column<string>(type: "varchar(50)", nullable: true),
                    GiaiDauIdgiaiDau = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lichThiDaus", x => x.IdTranDau);
                    table.ForeignKey(
                        name: "FK_lichThiDaus_giaiDaus_GiaiDauIdgiaiDau",
                        column: x => x.GiaiDauIdgiaiDau,
                        principalTable: "giaiDaus",
                        principalColumn: "IdgiaiDau");
                });

            migrationBuilder.CreateTable(
                name: "dois",
                columns: table => new
                {
                    IdDoi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDoi = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Donvi = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GiaiDauIdgiaiDau = table.Column<int>(type: "int", nullable: true),
                    LichThiDauIdTranDau = table.Column<int>(type: "int", nullable: true),
                    LichThiDauIdTranDau1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dois", x => x.IdDoi);
                    table.ForeignKey(
                        name: "FK_dois_giaiDaus_GiaiDauIdgiaiDau",
                        column: x => x.GiaiDauIdgiaiDau,
                        principalTable: "giaiDaus",
                        principalColumn: "IdgiaiDau");
                    table.ForeignKey(
                        name: "FK_dois_lichThiDaus_LichThiDauIdTranDau",
                        column: x => x.LichThiDauIdTranDau,
                        principalTable: "lichThiDaus",
                        principalColumn: "IdTranDau");
                    table.ForeignKey(
                        name: "FK_dois_lichThiDaus_LichThiDauIdTranDau1",
                        column: x => x.LichThiDauIdTranDau1,
                        principalTable: "lichThiDaus",
                        principalColumn: "IdTranDau");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdDoi",
                table: "Users",
                column: "IdDoi");

            migrationBuilder.CreateIndex(
                name: "IX_dois_GiaiDauIdgiaiDau",
                table: "dois",
                column: "GiaiDauIdgiaiDau");

            migrationBuilder.CreateIndex(
                name: "IX_dois_LichThiDauIdTranDau",
                table: "dois",
                column: "LichThiDauIdTranDau");

            migrationBuilder.CreateIndex(
                name: "IX_dois_LichThiDauIdTranDau1",
                table: "dois",
                column: "LichThiDauIdTranDau1");

            migrationBuilder.CreateIndex(
                name: "IX_lichThiDaus_GiaiDauIdgiaiDau",
                table: "lichThiDaus",
                column: "GiaiDauIdgiaiDau");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_dois_IdDoi",
                table: "Users",
                column: "IdDoi",
                principalTable: "dois",
                principalColumn: "IdDoi",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_dois_IdDoi",
                table: "Users");

            migrationBuilder.DropTable(
                name: "dois");

            migrationBuilder.DropTable(
                name: "lichThiDaus");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdDoi",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BomonThiDau",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdDoi",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Users");
        }
    }
}
