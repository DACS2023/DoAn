﻿// <auto-generated />
using System;
using DoAnCoSo.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoAnCoSo.Migrations
{
    [DbContext(typeof(QuanLyHoiThaoDBContext))]
    [Migration("20230427182828_initial create")]
    partial class initialcreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DoAnCoSo.Areas.Identity.Data.GiaiDau", b =>
                {
                    b.Property<int>("IdgiaiDau")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdgiaiDau"));

                    b.Property<int>("IdloaiGiaiDau")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("Date");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("Date");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("TenGiaiDau")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("IdgiaiDau");

                    b.ToTable("giaiDaus");
                });

            modelBuilder.Entity("DoAnCoSo.Areas.Identity.Data.LoaiGiaiDau", b =>
                {
                    b.Property<int>("IdloaiGiaiDau")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdloaiGiaiDau"));

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("IdloaiGiaiDau");

                    b.ToTable("loaiGiaiDaus");
                });

            modelBuilder.Entity("DoAnCoSo.Areas.Identity.Data.QuanLyHoiThaoUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("Date");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("quanLyHoiThaoUsers");
                });

            modelBuilder.Entity("GiaiDauLoaiGiaiDau", b =>
                {
                    b.Property<int>("GiaiDausIdgiaiDau")
                        .HasColumnType("int");

                    b.Property<int>("ThiDausIdloaiGiaiDau")
                        .HasColumnType("int");

                    b.HasKey("GiaiDausIdgiaiDau", "ThiDausIdloaiGiaiDau");

                    b.HasIndex("ThiDausIdloaiGiaiDau");

                    b.ToTable("GiaiDauLoaiGiaiDau");
                });

            modelBuilder.Entity("GiaiDauLoaiGiaiDau", b =>
                {
                    b.HasOne("DoAnCoSo.Areas.Identity.Data.GiaiDau", null)
                        .WithMany()
                        .HasForeignKey("GiaiDausIdgiaiDau")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoAnCoSo.Areas.Identity.Data.LoaiGiaiDau", null)
                        .WithMany()
                        .HasForeignKey("ThiDausIdloaiGiaiDau")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
