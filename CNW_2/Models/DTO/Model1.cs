using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CNW_2.Models.DTO
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBan { get; set; }
        public virtual DbSet<Sach> Sach { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TacGia> TacGia { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<TheLoai> TheLoai { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhachHang>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.GiaBan)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);
        }
    }
}
