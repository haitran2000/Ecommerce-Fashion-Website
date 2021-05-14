using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.Models;

namespace Web_API_e_Fashion.Data
{
    public partial class DPContext
    {

        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<NhanHieu> NhanHieus { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<SanPhamBienThe> SanPhamBienThes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Item_SanPhamThietKe> Item_SanPhamThietKe { get; set; }
        public DbSet<MauSac> MauSacs { get; set; }
        public DbSet<SanPham_SanPhamThietKe> SanPham_SanPhamThietKe { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<SanPhamThietKe> SanPhamThietKes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<AuthHistory> AuthHistories { get; set; }
        public DbSet<Notification>  Notifications { get; set; }
        protected void TableBuilder(ModelBuilder modelBuilder)
        {

        
            modelBuilder
            .Entity<SanPham>()
            .HasMany(p => p.SanPhamThietKes)
            .WithMany(p => p.SanPhams)
            .UsingEntity<SanPham_SanPhamThietKe>(
                j => j
                    .HasOne(pt => pt.SanPhamThietKe)
                    .WithMany(t => t.SanPham_SanPhamThietKes)
                    .HasForeignKey(pt => pt.SanPhamThietKeId),
                j => j
                    .HasOne(pt => pt.SanPham)
                    .WithMany(p => p.SanPham_SanPhamThietKes)
                    .HasForeignKey(pt => pt.SanPhamId),
                j =>
                {
                    j.Property(pt => pt.PublicationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.HasKey(t => new { t.SanPhamId, t.SanPhamThietKeId });
                });
            modelBuilder
            .Entity<Item>()
            .HasMany(p => p.SanPhamThietKes)
            .WithMany(p => p.Items)
            .UsingEntity<Item_SanPhamThietKe>(
                j => j
                    .HasOne(pt => pt.SanPhamThietKe)
                    .WithMany(t => t.Item_SanPhamThietKes)
                    .HasForeignKey(pt => pt.SanPhamThietKeId),
                j => j
                    .HasOne(pt => pt.Item)
                    .WithMany(p => p.Item_SanPhamThietKes)
                    .HasForeignKey(pt => pt.ItemId),
                j =>
                {
                    j.Property(pt => pt.PublicationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.HasKey(t => new { t.ItemId, t.SanPhamThietKeId });
                });


        }
   
    }
}
