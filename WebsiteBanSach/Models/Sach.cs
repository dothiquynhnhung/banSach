using System;
using System.Collections.Generic;

namespace WebsiteBanSach.Models;

public partial class Sach
{
    public string MaSach { get; set; } = null!;

    public string? TenSach { get; set; }

    public int? NamXb { get; set; }

    public int? SoTrang { get; set; }

    public string? AnhSach { get; set; }

    public string? MoTa { get; set; }

    public int? SoLuong { get; set; }

    public string? TrongLuong { get; set; }

    public decimal? GiaBan { get; set; }

    public string? MaTg { get; set; }

    public string? MaTheLoai { get; set; }

    public string? MaNxb { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual NhaXuatBan? MaNxbNavigation { get; set; }

    public virtual TacGium? MaTgNavigation { get; set; }

    public virtual TheLoai? MaTheLoaiNavigation { get; set; }
}
