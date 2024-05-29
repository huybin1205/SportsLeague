using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SportsLeague.Models
{
    public partial class SportLeagueContext : DbContext
    {
        public SportLeagueContext()
            : base("name=SportLeagueContext")
        {
        }

        public virtual DbSet<CauThu> CauThus { get; set; }
        public virtual DbSet<DanhHieuCauThu> DanhHieuCauThus { get; set; }
        public virtual DbSet<DoiBong> DoiBongs { get; set; }
        public virtual DbSet<LichThiDau> LichThiDaus { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<PhanQuyenNguoiDung> PhanQuyenNguoiDungs { get; set; }
        public virtual DbSet<QuanLyGiaiDau> QuanLyGiaiDaus { get; set; }
        public virtual DbSet<QuanLyGiaiThuong> QuanLyGiaiThuongs { get; set; }
        public virtual DbSet<VaiTro> VaiTroes { get; set; }
        public virtual DbSet<QuanLyDoiBongVaCauThu> QuanLyDoiBongVaCauThus { get; set; }
        public virtual DbSet<QuanLyCLBVaGiaiDau> QuanLyCLBVaGiaiDaus { get; set; }
        public virtual DbSet<LoaiGiaiThuong> LoaiGiaiThuongs { get; set; }
        public virtual DbSet<BangDau> BangDaus { get; set; }
        public virtual DbSet<BangDauVaDoiBong> BangDauVaDoiBongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CauThu>()
                .Property(e => e.TenCauThu)
                .IsUnicode(true);

            modelBuilder.Entity<CauThu>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<CauThu>()
                .Property(e => e.QuocTich)
                .IsUnicode(true);

            modelBuilder.Entity<CauThu>()
                .Property(e => e.ViTriThiDau)
                .IsUnicode(true);

            modelBuilder.Entity<DoiBong>()
                .Property(e => e.TenDoiBong)
                .IsUnicode(true);

            modelBuilder.Entity<DoiBong>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<DoiBong>()
                .Property(e => e.NguoiQuanLyCLB)
                .IsUnicode(true);

            modelBuilder.Entity<DoiBong>()
                .Property(e => e.DoiTruong)
                .IsUnicode(false);

            modelBuilder.Entity<DoiBong>()
                .Property(e => e.ViTri)
                .IsUnicode(true);

            modelBuilder.Entity<DoiBong>()
                .HasMany(e => e.LichThiDaus)
                .WithOptional(e => e.DoiBong)
                .HasForeignKey(e => e.MaCLBChuNha);

            modelBuilder.Entity<DoiBong>()
                .HasMany(e => e.LichThiDaus)
                .WithOptional(e => e.DoiBong)
                .HasForeignKey(e => e.MaCLBKhach);

            modelBuilder.Entity<LichThiDau>()
                .Property(e => e.VongThiDau)
                .IsUnicode(false);

            modelBuilder.Entity<LichThiDau>()
                .Property(e => e.SanThiDau)
                .IsUnicode(false);

            modelBuilder.Entity<LichThiDau>()
                .Property(e => e.BuGio)
                .IsUnicode(false);

            modelBuilder.Entity<LichThiDau>()
                .Property(e => e.KetQuaLuanLuu)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Ho)
                .IsUnicode(true);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Ten)
                .IsUnicode(true);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<QuanLyGiaiDau>()
                .Property(e => e.TenGiaiDau)
                .IsUnicode(true);

            modelBuilder.Entity<QuanLyGiaiDau>()
                .Property(e => e.DonViToChuc)
                .IsUnicode(true);

            modelBuilder.Entity<QuanLyGiaiThuong>()
                .Property(e => e.TenGiaiThuong)
                .IsUnicode(true);

            modelBuilder.Entity<VaiTro>()
                .Property(e => e.TenVaiTro)
                .IsUnicode(false);
            modelBuilder.Entity<LoaiGiaiThuong>()
             .Property(e => e.TenLoaiGiaiThuong)
             .IsUnicode(true);
        }
    }
}
