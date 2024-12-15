using System;
using System.Collections.Generic;

namespace WebsiteBanSach.Models;

public partial class ChiTietHoaDon
{
    public string MaHd { get; set; } = null!;

    public string MaSach { get; set; } = null!;

    public int? SoLuongDat { get; set; }

    public decimal? DonGia { get; set; }

    public virtual HoaDon MaHdNavigation { get; set; } = null!;

    public virtual Sach MaSachNavigation { get; set; } = null!;
}
