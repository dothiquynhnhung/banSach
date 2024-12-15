using System;
using System.Collections.Generic;

namespace WebsiteBanSach.Models;

public partial class HoaDon
{
    public string MaHd { get; set; } = null!;

    public string? MaKh { get; set; }

    public DateOnly? NgayThanhToan { get; set; }

    public string? DiaChiGiaoDich { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual KhachHang? MaKhNavigation { get; set; }
}
