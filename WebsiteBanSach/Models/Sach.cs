using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;

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
    public static string FormatCurrency(decimal? amount)
    {
        if (!amount.HasValue) return "0đ"; // Trả về giá trị mặc định nếu là null

        var culture = new CultureInfo("vi-VN");
        return string.Format(culture, "{0:N0}đ", amount.Value);
    }

    public List<Sach> getSachs()
    {
        string filePath = "wwwroot/fileXML/Sach.xml";
        XDocument xmlDoc = XDocument.Load(filePath);
        List<Sach> sachs = xmlDoc.Descendants("Sach").Select(x => new Sach
        {
            MaSach = x.Element("maSach")?.Value.Trim(),
            TenSach = x.Element("tenSach")?.Value.Trim(),
            NamXb = int.Parse(x.Element("namXB")?.Value.Trim()),
            SoTrang = int.Parse(x.Element("soTrang")?.Value.Trim()),
            AnhSach = x.Element("anhSach")?.Value.Trim(),
            MoTa = x.Element("moTa")?.Value.Trim(),
            SoLuong = int.Parse(x.Element("soLuong")?.Value.Trim()),
            TrongLuong = x.Element("trongLuong")?.Value.Trim(),
            GiaBan = Decimal.Parse(x.Element("giaBan")?.Value.Trim()),
            MaTg = x.Element("maTG")?.Value.Trim(),
            MaTheLoai = x.Element("maTheLoai")?.Value.Trim(),
            MaNxb = x.Element("maNXB")?.Value.Trim(),

        })
         .ToList();
        return sachs;

    }
    public Sach getSachById(String id)
    {
        string filePath = "wwwroot/fileXML/Sach.xml";
        XDocument xmlDoc = XDocument.Load(filePath);
        Sach sachs = xmlDoc.Descendants("Sach")
                           .Where(s => s.Element("maSach")?.Value.Trim() == id)
                           .Select(x => new Sach
                           {
                               MaSach = x.Element("maSach")?.Value.Trim(),
                               TenSach = x.Element("tenSach")?.Value.Trim(),
                               NamXb = int.Parse(x.Element("namXB")?.Value.Trim()),
                               SoTrang = int.Parse(x.Element("soTrang")?.Value.Trim()),
                               AnhSach = x.Element("anhSach")?.Value.Trim(),
                               MoTa = x.Element("moTa")?.Value.Trim(),
                               SoLuong = int.Parse(x.Element("soLuong")?.Value.Trim()),
                               TrongLuong = x.Element("trongLuong")?.Value.Trim(),
                               GiaBan = Decimal.Parse(x.Element("giaBan")?.Value.Trim()),
                               MaTg = x.Element("maTG")?.Value.Trim(),
                               MaTheLoai = x.Element("maTheLoai")?.Value.Trim(),
                               MaNxb = x.Element("maNXB")?.Value.Trim(),
                           })
                           .FirstOrDefault();

        return sachs;
    }

    public List<Sach> getSachByMaTheLoai(String idTL, String idSach)
    {
        string filePath = "wwwroot/fileXML/Sach.xml";
        XDocument xmlDoc = XDocument.Load(filePath);
        List<Sach> sachs = xmlDoc.Descendants("Sach")
                           .Where(s => s.Element("maTheLoai")?.Value.Trim() == idTL && s.Element("maTheLoai")?.Value.Trim() != idSach)
                           .Select(x => new Sach
                           {
                               MaSach = x.Element("maSach")?.Value.Trim(),
                               TenSach = x.Element("tenSach")?.Value.Trim(),
                               NamXb = int.Parse(x.Element("namXB")?.Value.Trim()),
                               SoTrang = int.Parse(x.Element("soTrang")?.Value.Trim()),
                               AnhSach = x.Element("anhSach")?.Value.Trim(),
                               MoTa = x.Element("moTa")?.Value.Trim(),
                               SoLuong = int.Parse(x.Element("soLuong")?.Value.Trim()),
                               TrongLuong = x.Element("trongLuong")?.Value.Trim(),
                               GiaBan = Decimal.Parse(x.Element("giaBan")?.Value.Trim()),
                               MaTg = x.Element("maTG")?.Value.Trim(),
                               MaTheLoai = x.Element("maTheLoai")?.Value.Trim(),
                               MaNxb = x.Element("maNXB")?.Value.Trim(),
                           })
                           .ToList();

        return sachs;
    }
}
