using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Xml.Serialization;
using WebsiteBanSach.Models;
using System.Data;
using System.Xml.Linq;

namespace WebsiteBanSach.Controllers
{
    public class ThanhToan : Controller
    {
        public IActionResult thanhToan()
        {
            add(); 

            return View();
        }

        public void add()
        {
            List<WebsiteBanSach.Models.GioHang> gioHang = HttpContext.Session.GetObjectFromJson<List<WebsiteBanSach.Models.GioHang>>("Cart");

            string maKh = HttpContext.Session.GetString("maKhachHang");
            string dch = HttpContext.Session.GetString("diaChi");
       
            

            foreach (var i in gioHang) {
                WebsiteBanSach.Models.HoaDon hd = new HoaDon()
                {
                    MaHd = WebsiteBanSach.Models.HoaDon.GenerateRandomHoaDon(),
                    MaKh = maKh,
                    NgayThanhToan = DateOnly.FromDateTime(DateTime.Now),
                    DiaChiGiaoDich = dch

                };
                WriteHoaDonToXml(hd);
               
                WebsiteBanSach.Models.ChiTietHoaDon ct = new ChiTietHoaDon()
                {
                    MaHd = hd.MaHd,
                    MaSach = i.Sach.MaSach,
                    SoLuongDat = i.Sach.SoLuong,
                    DonGia = i.Sach.GiaBan
                };
                WriteChiTietHDToXml(ct);

            }
           


          
        }

       public  static void WriteHoaDonToXml(HoaDon hd)
        {
            XDocument doc = XDocument.Load("wwwroot/fileXML/HoaDon.xml");
            XElement invoice = new XElement("HoaDon",
                new XElement("maHD", hd.MaHd),
                new XElement("maKH", hd.MaKh),
                new XElement("ngayThanhToan", hd.NgayThanhToan),
                new XElement("diaChiGiaoDich", hd.DiaChiGiaoDich)

            );
            doc.Element("NewDataSet")?.Add(invoice);
            doc.Save("wwwroot/fileXML/HoaDon.xml");

        }

        public static void WriteChiTietHDToXml(ChiTietHoaDon hd)
        {
            XDocument doc = XDocument.Load("wwwroot/fileXML/ChiTietHoaDon.xml");
            XElement invoice = new XElement("ChiTietHoaDon",
                new XElement("maHD", hd.MaHd),
                new XElement("maSach", hd.MaSach),
                new XElement("soLuongDat", hd.SoLuongDat),
                new XElement("donGia", hd.DonGia)

            );
            doc.Element("NewDataSet")?.Add(invoice);
            doc.Save("wwwroot/fileXML/ChiTietHoaDon.xml");
        }
    }



}
