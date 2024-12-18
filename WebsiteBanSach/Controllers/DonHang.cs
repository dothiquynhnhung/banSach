using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using WebsiteBanSach.Models;

namespace WebsiteBanSach.Controllers
{
    public class DonHang : Controller
    {

        public IActionResult donHang()
        {
            //string maKH = GetLoggedInCustomerId();
            string maKH = "KH001";
            string hoaDonPath = "wwwroot/fileXML/HoaDon.xml";
            string sachPath = "wwwroot/fileXML/Sach.xml";
            string chiTietHDPath = "wwwroot/fileXML/ChiTietHoaDon.xml";
            string theLoaiPath = "wwwroot/fileXML/TheLoai.xml";
            string khachHangPath = "wwwroot/fileXML/KhachHang.xml";

            var donHangList = GetDonHang(hoaDonPath, sachPath, chiTietHDPath, theLoaiPath, khachHangPath, maKH);
            ViewBag.donHangs = donHangList;
            TempData["DonHangs"] = Newtonsoft.Json.JsonConvert.SerializeObject(donHangList); //

            return View();

        }

        private List<DH> GetDonHang(string hoaDonPath, string sachPath, string chiTietHDPath, string theLoaiPath, string khachHangPath, string maKH)
        {
            XDocument hoaDonXml = XDocument.Load(hoaDonPath);
            XDocument sachXml = XDocument.Load(sachPath);
            XDocument chiTietHDXml = XDocument.Load(chiTietHDPath);
            XDocument theLoaiXml = XDocument.Load(theLoaiPath);
            XDocument khachHangXml = XDocument.Load(khachHangPath);

            var hoaDons = hoaDonXml.Descendants("HoaDon")
                                   .Where(h => h.Element("maKH")!.Value.Trim() == maKH)
                                   .Select(h => new
                                   {
                                       MaHD = h.Element("maHD")!.Value.Trim() ?? string.Empty,
                                       MaKH = h.Element("maKH")!.Value.Trim() ?? string.Empty
                                   });

            var chiTietHDs = chiTietHDXml.Descendants("ChiTietHoaDon")
                                         .Select(c => new
                                         {
                                             MaHD = c.Element("maHD")!.Value.Trim() ?? string.Empty,
                                             MaSach = c.Element("maSach")!.Value.Trim() ?? string.Empty,
                                             SoLuongDat = int.TryParse(c.Element("soLuongDat")?.Value?.Trim(), out int soLuong) ? soLuong : 0
                                         });

            var sachs = sachXml.Descendants("Sach")
                               .Select(s => new
                               {
                                   MaSach = s.Element("maSach")!.Value.Trim() ?? string.Empty,
                                   TenSach = s.Element("tenSach")!.Value.Trim() ?? string.Empty,
                                   AnhSach = s.Element("anhSach")!.Value.Trim() ?? string.Empty,
                                   GiaBan = Decimal.TryParse(s.Element("giaBan")?.Value?.Trim(), out decimal giaBan) ? giaBan : 0, 
                                   MaTheLoai = s.Element("maTheLoai")!.Value.Trim() ?? string.Empty
                               });

            var theLoais = theLoaiXml.Descendants("TheLoai")
                                     .Select(t => new
                                     {
                                         MaTheLoai = t.Element("maTheLoai")!.Value.Trim() ?? string.Empty,
                                         TenTheLoai = t.Element("tenTheLoai")!.Value.Trim() ?? string.Empty
                                     });
            var khachHangs = khachHangXml.Descendants("KhachHang")
                                                     .Select(k => new
                                                     {
                                                         MaKH = k.Element("maKH")!.Value.Trim() ?? string.Empty,
                                                         TenKH = k.Element("tenKH")!.Value.Trim() ?? string.Empty
                                                     });
            var result = (from hd in hoaDons
                          join cthd in chiTietHDs on hd.MaHD equals cthd.MaHD
                          join s in sachs on cthd.MaSach equals s.MaSach
                          join tl in theLoais on s.MaTheLoai equals tl.MaTheLoai
                          join kh in khachHangs on hd.MaKH equals kh.MaKH
                          select new DH
                          {
                              MaHD = hd.MaHD,
                              TenSach = s.TenSach,
                              AnhSach = s.AnhSach,
                              TenTheLoai = tl.TenTheLoai,
                              GiaBan = s.GiaBan,
                              SoLuongDat = cthd.SoLuongDat,
                               ThanhTien = s.GiaBan * cthd.SoLuongDat // Tính tổng tiền cho mỗi đơn hàng
                          }).ToList();

            return result;
        }

        private string GetLoggedInCustomerId()
        {
            return HttpContext.Session.GetString("maKH") ?? string.Empty;
        }


    }
    public class DH
    {
        public string? MaHD { get; set; }
        public string? NgayThanhToan { get; set; }
        public string? TenSach { get; set; }
        public int SoLuongDat { get; set; }
        public decimal GiaBan { get; set; }
        public decimal ThanhTien { get; set; }
        public string? AnhSach { get; set; }
        public string? TenTheLoai { get; set; }

        public static decimal GetTotalPrice(List<DH> dhList)
        {
            return dhList.Sum(item => item.ThanhTien);
        }
    }
}