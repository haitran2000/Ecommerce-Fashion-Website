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

            modelBuilder.Entity("Web_API_e_Fashion.Models.Cart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Id_SanPhamBienThe")
                        .HasColumnType("int");

                    b.Property<string>("Mau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanPhamId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CartID");

                    b.HasIndex("Id_SanPhamBienThe");

                    b.HasIndex("SanPhamId");

                    b.HasIndex("UserID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.ChiTietHoaDon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Id_HoaDon")
                        .HasColumnType("int");

                    b.Property<int?>("Id_SanPham")
                        .HasColumnType("int");

                    b.Property<int?>("Id_SanPhamBienThe")
                        .HasColumnType("int");

                    b.Property<string>("Mau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.Property<decimal?>("ThanhTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Id_HoaDon");

                    b.HasIndex("Id_SanPham");

                    b.HasIndex("Id_SanPhamBienThe");

                    b.ToTable("ChiTietHoaDons");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.HoaDon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Huyen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Id_User")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TrangThai")
                        .HasColumnType("int");

                    b.Property<int?>("TrangThaiThanhToan")
                        .HasColumnType("int");

                    b.Property<string>("Xa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id_User");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.ImageSanPham", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdSanPham");

                    b.ToTable("ImageSanPhams");
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

                    b.Property<string>("NamNu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Loais");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.MaGiamGia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SoTienGiam")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("MaGiamGias");
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

                    b.Property<string>("Ten")
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

                    b.Property<decimal?>("GiaNhap")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int?>("GioiTinh")
                        .HasColumnType("int");

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

                    b.Property<int?>("SizeId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongTon")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_Mau");

                    b.HasIndex("Id_SanPham");

                    b.HasIndex("SizeId");

                    b.ToTable("SanPhamBienThes");
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

            modelBuilder.Entity("Web_API_e_Fashion.Models.UserComment", b =>
                {
                    b.Property<int>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<int>("IdAppUser")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdSanPham", "IdAppUser");

                    b.HasIndex("IdUser");

                    b.ToTable("UserComment");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.UserLike", b =>
                {
                    b.Property<int>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<int>("IdAppUser")
                        .HasColumnType("int");

                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdSanPham", "IdAppUser");

                    b.HasIndex("IdUser");

                    b.ToTable("UserLike");
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

            modelBuilder.Entity("Web_API_e_Fashion.Models.Cart", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.SanPhamBienThe", "SanPhamBienThe")
                        .WithMany()
                        .HasForeignKey("Id_SanPhamBienThe");

                    b.HasOne("Web_API_e_Fashion.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_API_e_Fashion.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("SanPham");

                    b.Navigation("SanPhamBienThe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.ChiTietHoaDon", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.HoaDon", "HoaDon")
                        .WithMany("ChiTietHoaDons")
                        .HasForeignKey("Id_HoaDon");

                    b.HasOne("Web_API_e_Fashion.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("Id_SanPham");

                    b.HasOne("Web_API_e_Fashion.Models.SanPhamBienThe", "SanPhamBienThe")
                        .WithMany("ChiTietHoaDon")
                        .HasForeignKey("Id_SanPhamBienThe");

                    b.Navigation("HoaDon");

                    b.Navigation("SanPham");

                    b.Navigation("SanPhamBienThe");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.HoaDon", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("Id_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.ImageSanPham", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.SanPham", "SanPham")
                        .WithMany("ImageSanPhams")
                        .HasForeignKey("IdSanPham");

                    b.Navigation("SanPham");
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

            modelBuilder.Entity("Web_API_e_Fashion.Models.Size", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.Loai", "Loai")
                        .WithMany("Sizes")
                        .HasForeignKey("Id_Loai");

                    b.Navigation("Loai");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.UserComment", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_API_e_Fashion.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("IdUser");

                    b.Navigation("SanPham");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.UserLike", b =>
                {
                    b.HasOne("Web_API_e_Fashion.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_API_e_Fashion.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("IdUser");

                    b.Navigation("SanPham");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.HoaDon", b =>
                {
                    b.Navigation("ChiTietHoaDons");
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
                    b.Navigation("ImageSanPhams");

                    b.Navigation("SanPhamBienThes");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.SanPhamBienThe", b =>
                {
                    b.Navigation("ChiTietHoaDon");
                });

            modelBuilder.Entity("Web_API_e_Fashion.Models.Size", b =>
                {
                    b.Navigation("SanPhamBienThes");
                });
#pragma warning restore 612, 618
        }
    }
}
