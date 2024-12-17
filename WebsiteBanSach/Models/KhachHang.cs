using System;
using System.Collections.Generic;

namespace WebsiteBanSach.Models;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    public string TenKh { get; set; } = null!;

    public string? MatKhau { get; set; }

    public string Sdt { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? DiaChi { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
    public static string GenerateRandomId()
    {
        Random random = new Random();
        int number = random.Next(1, 10000) + DateTime.Now.Second;
        return $"KH{number:D4}";
    }
}
