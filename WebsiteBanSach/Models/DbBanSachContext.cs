using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebsiteBanSach.Models;

public partial class DbBanSachContext : DbContext
{
    public DbBanSachContext()
    {
    }

    public DbBanSachContext(DbContextOptions<DbBanSachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<DanhMuc> DanhMucs { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<TacGium> TacGia { get; set; }

    public virtual DbSet<TheLoai> TheLoais { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-5TSOTHIM\\MHANG;Initial Catalog=dbBanSach;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaSach }).HasName("PK__ChiTietH__F71B1369AA3D3FEB");

            entity.ToTable("ChiTietHoaDon");

            entity.Property(e => e.MaHd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maHD");
            entity.Property(e => e.MaSach)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maSach");
            entity.Property(e => e.DonGia)
                .HasColumnType("money")
                .HasColumnName("donGia");
            entity.Property(e => e.SoLuongDat).HasColumnName("soLuongDat");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_maHD");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_maSach");
        });

        modelBuilder.Entity<DanhMuc>(entity =>
        {
            entity.HasKey(e => e.MaDanhMuc).HasName("PK__DanhMuc__6B0F914C71C5F923");

            entity.ToTable("DanhMuc");

            entity.Property(e => e.MaDanhMuc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maDanhMuc");
            entity.Property(e => e.TenDanhMuc)
                .HasMaxLength(50)
                .HasColumnName("tenDanhMuc");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HoaDon__7A3E1486072530BF");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHd)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maHD");
            entity.Property(e => e.DiaChiGiaoDich)
                .HasMaxLength(50)
                .HasColumnName("diaChiGiaoDich");
            entity.Property(e => e.MaKh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maKH");
            entity.Property(e => e.NgayThanhToan).HasColumnName("ngayThanhToan");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK_maKH");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__7A3ECFE43F4EFE8D");

            entity.ToTable("KhachHang");

            entity.HasIndex(e => e.Email, "UQ__KhachHan__AB6E6164D4A0B1A5").IsUnique();

            entity.HasIndex(e => e.Sdt, "UQ__KhachHan__CA1930A597A29ED0").IsUnique();

            entity.Property(e => e.MaKh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maKH");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(50)
                .HasColumnName("diaChi");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("matKhau");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.TenKh)
                .HasMaxLength(50)
                .HasColumnName("tenKH");
        });

        modelBuilder.Entity<NhaXuatBan>(entity =>
        {
            entity.HasKey(e => e.MaNxb).HasName("PK__NhaXuatB__26999B20256BF15D");

            entity.ToTable("NhaXuatBan");

            entity.Property(e => e.MaNxb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maNXB");
            entity.Property(e => e.TenNxb)
                .HasMaxLength(50)
                .HasColumnName("tenNXB");
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.MaSach).HasName("PK__Sach__D2507EF952F49DB0");

            entity.ToTable("Sach");

            entity.Property(e => e.MaSach)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maSach");
            entity.Property(e => e.AnhSach)
                .IsUnicode(false)
                .HasColumnName("anhSach");
            entity.Property(e => e.GiaBan)
                .HasColumnType("money")
                .HasColumnName("giaBan");
            entity.Property(e => e.MaNxb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maNXB");
            entity.Property(e => e.MaTg)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maTG");
            entity.Property(e => e.MaTheLoai)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maTheLoai");
            entity.Property(e => e.MoTa).HasColumnName("moTa");
            entity.Property(e => e.NamXb).HasColumnName("namXB");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");
            entity.Property(e => e.SoTrang).HasColumnName("soTrang");
            entity.Property(e => e.TenSach)
                .HasMaxLength(50)
                .HasColumnName("tenSach");
            entity.Property(e => e.TrongLuong)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("trongLuong");

            entity.HasOne(d => d.MaNxbNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaNxb)
                .HasConstraintName("FK_maNXB");

            entity.HasOne(d => d.MaTgNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaTg)
                .HasConstraintName("FK_maTG");

            entity.HasOne(d => d.MaTheLoaiNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaTheLoai)
                .HasConstraintName("FK_maTheLoai");
        });

        modelBuilder.Entity<TacGium>(entity =>
        {
            entity.HasKey(e => e.MaTg).HasName("PK__TacGia__7A226252BFFB5D9B");

            entity.Property(e => e.MaTg)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maTG");
            entity.Property(e => e.TenTg)
                .HasMaxLength(50)
                .HasColumnName("tenTG");
        });

        modelBuilder.Entity<TheLoai>(entity =>
        {
            entity.HasKey(e => e.MaTheLoai).HasName("PK__TheLoai__2E9E267E64852991");

            entity.ToTable("TheLoai");

            entity.Property(e => e.MaTheLoai)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maTheLoai");
            entity.Property(e => e.MaDanhMuc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maDanhMuc");
            entity.Property(e => e.TenTheLoai)
                .HasMaxLength(50)
                .HasColumnName("tenTheLoai");

            entity.HasOne(d => d.MaDanhMucNavigation).WithMany(p => p.TheLoais)
                .HasForeignKey(d => d.MaDanhMuc)
                .HasConstraintName("FK_maDM");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
