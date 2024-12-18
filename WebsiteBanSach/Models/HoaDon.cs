using System;
using System.Collections.Generic;
using System.Xml.Linq;

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

    public HoaDon getHoaDonById(String id)
    {
        string filePath = "wwwroot/fileXML/HoaDon.xml";
        XDocument xmlDoc = XDocument.Load(filePath);
        HoaDon hoaDon = xmlDoc.Descendants("HoaDon")
                           .Where(s => s.Element("maHD")?.Value.Trim() == id)
                           .Select(x => new HoaDon
                           {
                               MaHd = x.Element("maHD")?.Value.Trim(),
                               MaKh = x.Element("maKH")?.Value.Trim(),
                               NgayThanhToan = DateOnly.TryParse(
                                    x.Element("ngayThanhToan")?.Value.Trim(),
                                    out DateOnly parsedDate
                                ) ? parsedDate : null, 
                               DiaChiGiaoDich = x.Element("diaChiGiaoDich")?.Value.Trim(),
                           })
                           .FirstOrDefault();

        return hoaDon;
    }
}
