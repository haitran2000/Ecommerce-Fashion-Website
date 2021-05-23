﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_API_e_Fashion.Data;

namespace Web_API_e_Fashion.Migrations
{
    [DbContext(typeof(DPContext))]
    partial class DPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.AuthHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdentityId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("AuthHistories");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.ChiTietHoaDon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Id_HoaDon")
                        .HasColumnType("int");

                    b.Property<int?>("Id_SanPhamBienThe")
                        .HasColumnType("int");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.Property<decimal>("ThanhTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Id_HoaDon");

                    b.HasIndex("Id_SanPhamBienThe");

                    b.ToTable("ChiTietHoaDons");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.HoaDon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GhiChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Id_User")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Id_User");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreateBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.Item_SanPhamThietKe", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamThietKeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("ItemId", "SanPhamThietKeId");

                    b.HasIndex("SanPhamThietKeId");

                    b.ToTable("Item_SanPhamThietKe");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.JobSeeker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Id_Identity")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Identity");

                    b.ToTable("JobSeekers");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.Loai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Loais");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.MauSac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Id_Loai")
                        .HasColumnType("int");

                    b.Property<string>("MaMau")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Loai");

                    b.ToTable("MauSacs");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.NhanHieu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThongTin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NhanHieus");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenSanPham")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TranType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.NotificationCheckout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ThongBaoMaDonHang")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("NotificationCheckouts");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Gia")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("HuongDan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Id_Loai")
                        .HasColumnType("int");

                    b.Property<int?>("Id_NhanHieu")
                        .HasColumnType("int");

                    b.Property<decimal?>("KhuyenMai")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThanhPhan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThaiHoatDong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThaiSanPham")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThaiSanPhamThietKe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Loai");

                    b.HasIndex("Id_NhanHieu");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.SanPhamBienThe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Id_Mau")
                        .HasColumnType("int");

                    b.Property<int?>("Id_SanPham")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_Mau");

                    b.HasIndex("Id_SanPham");

                    b.HasIndex("SizeId");

                    b.ToTable("SanPhamBienThes");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.SanPhamThietKe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("Gia")
                        .HasColumnType("bigint");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThaiSanPham")
                        .HasColumnType("bit");

                    b.Property<bool>("TrangThaiXacNhan")
                        .HasColumnType("bit");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SanPhamThietKes");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.SanPham_SanPhamThietKe", b =>
                {
                    b.Property<int>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamThietKeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("SanPhamId", "SanPhamThietKeId");

                    b.HasIndex("SanPhamThietKeId");

                    b.ToTable("SanPham_SanPhamThietKe");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Id_Loai")
                        .HasColumnType("int");

                    b.Property<string>("TenSize")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Loai");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.AppUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quyen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("AppUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.AuthHistory", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.AppUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.ChiTietHoaDon", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.HoaDon", "HoaDon")
                        .WithMany("ChiTietHoaDons")
                        .HasForeignKey("Id_HoaDon");

                    b.HasOne("Web_API_e_Fashion.Models.SanPhamBienThe", "SanPhamBienThe")
                        .WithMany("ChiTietHoaDon")
                        .HasForeignKey("Id_SanPhamBienThe");

                    b.Navigation("HoaDon");

                    b.Navigation("SanPhamBienThe");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.HoaDon", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("Id_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.Item_SanPhamThietKe", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.Item", "Item")
                        .WithMany("Item_SanPhamThietKes")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_API_e_Fashion.Models.SanPhamThietKe", "SanPhamThietKe")
                        .WithMany("Item_SanPhamThietKes")
                        .HasForeignKey("SanPhamThietKeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("SanPhamThietKe");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.JobSeeker", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.AppUser", "Identity")
                        .WithMany()
                        .HasForeignKey("Id_Identity");

                    b.Navigation("Identity");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.MauSac", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.Loai", "Loai")
                        .WithMany("MauSacs")
                        .HasForeignKey("Id_Loai");

                    b.Navigation("Loai");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.SanPham", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.Loai", "Loai")
                        .WithMany("SanPhams")
                        .HasForeignKey("Id_Loai");

                    b.HasOne("Web_API_e_Fashion.Models.NhanHieu", "NhanHieu")
                        .WithMany("SanPhams")
                        .HasForeignKey("Id_NhanHieu");

                    b.Navigation("Loai");

                    b.Navigation("NhanHieu");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.SanPhamBienThe", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.MauSac", "MauSac")
                        .WithMany("SanPhamBienThes")
                        .HasForeignKey("Id_Mau");

                    b.HasOne("Web_API_e_Fashion.Models.SanPham", "SanPham")
                        .WithMany("SanPhamBienThes")
                        .HasForeignKey("Id_SanPham");

                    b.HasOne("Web_API_e_Fashion.Models.Size", "Size")
                        .WithMany("SanPhamBienThes")
                        .HasForeignKey("SizeId");

                    b.Navigation("MauSac");

                    b.Navigation("SanPham");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.SanPham_SanPhamThietKe", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.SanPham", "SanPham")
                        .WithMany("SanPham_SanPhamThietKes")
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_API_e_Fashion.Models.SanPhamThietKe", "SanPhamThietKe")
                        .WithMany("SanPham_SanPhamThietKes")
                        .HasForeignKey("SanPhamThietKeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");

                    b.Navigation("SanPhamThietKe");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.Size", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.Loai", "Loai")
                        .WithMany("Sizes")
                        .HasForeignKey("Id_Loai");

                    b.Navigation("Loai");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.HoaDon", b =>
                {
                    b.Navigation("ChiTietHoaDons");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.Item", b =>
                {
                    b.Navigation("Item_SanPhamThietKes");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.Loai", b =>
                {
                    b.Navigation("MauSacs");

                    b.Navigation("SanPhams");

                    b.Navigation("Sizes");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.MauSac", b =>
                {
                    b.Navigation("SanPhamBienThes");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.NhanHieu", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.SanPham", b =>
                {
                    b.Navigation("SanPham_SanPhamThietKes");

                    b.Navigation("SanPhamBienThes");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.SanPhamBienThe", b =>
                {
                    b.Navigation("ChiTietHoaDon");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.SanPhamThietKe", b =>
                {
                    b.Navigation("Item_SanPhamThietKes");

                    b.Navigation("SanPham_SanPhamThietKes");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.Size", b =>
                {
                    b.Navigation("SanPhamBienThes");
                });
#pragma warning restore 612, 618
        }
    }
}
