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
    public static string GenerateRandomHoaDon()
    {
        Random random = new Random();
        int number = random.Next(1, 10000)+ DateTime.Now.Second; 
        return $"HD{number:D4}"; 
    }
}
