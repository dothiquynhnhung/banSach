using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace WebsiteBanSach.Models
{
    public class XMLToSQL
    {
        private readonly DbBanSachContext _context;

        public XMLToSQL(DbBanSachContext context)
        {
            _context = context;
        }

        public void deleteBooks()
        {
            _context.Saches.ExecuteDelete();
            _context.SaveChanges();
        }

        public void deleteChiTietHoaDon()
        {
            _context.ChiTietHoaDons.ExecuteDelete();
            _context.SaveChanges();
        }


        public void deleteDanhMuc()
        {
            _context.DanhMucs.ExecuteDelete();
            _context.SaveChanges();
        }


        public void deleteHoaDon()
        {
            _context.HoaDons.ExecuteDelete();
            _context.SaveChanges();
        }

        public void deleteKhachHang()
        {
            _context.KhachHangs.ExecuteDelete();
            _context.SaveChanges();
        }

        public void deleteNhaXuatBan()
        {
            _context.NhaXuatBans.ExecuteDelete();
            _context.SaveChanges();
        }

        public void deleteTacGia()
        {
            _context.TacGia.ExecuteDelete();
            _context.SaveChanges();
        }

        public void deleteTheLoai()
        {
            _context.TheLoais.ExecuteDelete();
            _context.SaveChanges();
        }

        public void ImportBooksFromXML(string filePath)
        {

            _context.Saches.ExecuteDelete();
            XDocument xmlDoc = XDocument.Load(filePath);
            var books = xmlDoc.Descendants("Sach")
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

                              }).ToList();

            _context.Saches.AddRange(books);
            _context.SaveChanges();
        }
        public void ImportChiTietHoaDonToSQL(string filePath)
        {

            _context.ChiTietHoaDons.ExecuteDelete();

            XDocument xmlDoc = XDocument.Load(filePath);

            var chiTietHoaDons = xmlDoc.Descendants("ChiTietHoaDon")
                                       .Select(x => new ChiTietHoaDon
                                       {
                                           MaHd = x.Element("maHD")?.Value,
                                           MaSach = x.Element("maSach")?.Value,
                                           SoLuongDat = x.Element("soLuongDat") != null
                                               ? int.Parse(x.Element("soLuongDat").Value)
                                               : null,
                                           DonGia = x.Element("donGia") != null
                                               ? decimal.Parse(x.Element("donGia").Value)
                                               : null
                                       }).ToList();

            _context.ChiTietHoaDons.AddRange(chiTietHoaDons);
            _context.SaveChanges();
        }

        public void ImportDanhMucToSQL(string filePath)
        {

            _context.DanhMucs.ExecuteDelete();
            XDocument xmlDoc = XDocument.Load(filePath);

            var danhMucs = xmlDoc.Descendants("DanhMuc")
                                 .Select(x => new DanhMuc
                                 {
                                     MaDanhMuc = x.Element("maDanhMuc")?.Value,
                                     TenDanhMuc = x.Element("tenDanhMuc")?.Value
                                 }).ToList();

            _context.DanhMucs.AddRange(danhMucs);
            _context.SaveChanges();
        }

        public void ImportHoaDonToSQL(string filePath)
        {

            _context.HoaDons.ExecuteDelete();
            XDocument xmlDoc = XDocument.Load(filePath);

            var hoaDons = xmlDoc.Descendants("HoaDon")
                                .Select(x => new HoaDon
                                {
                                    MaHd = x.Element("maHD")?.Value.Trim(),
                                    MaKh = x.Element("maKH")?.Value.Trim(),
                                    NgayThanhToan = DateOnly.TryParse(x.Element("ngayThanhToan")?.Value.Trim(),
                                        out DateOnly parsedDate) ? parsedDate : null,
                                    DiaChiGiaoDich = x.Element("diaChiGiaoDich")?.Value.Trim()
                                }).ToList();

            _context.HoaDons.AddRange(hoaDons);
            _context.SaveChanges();
        }

        public void ImportKhachHangToSQL(string filePath)
        {
           
            _context.KhachHangs.ExecuteDelete(); 
            XDocument xmlDoc = XDocument.Load(filePath);

            var khachHangs = xmlDoc.Descendants("KhachHang")
                                   .Select(x => new KhachHang
                                   {
                                       MaKh = x.Element("maKH")?.Value.Trim(),
                                       TenKh = x.Element("tenKH")?.Value.Trim(),
                                       MatKhau = x.Element("matKhau")?.Value.Trim(),
                                       Sdt = x.Element("SDT")?.Value.Trim(),
                                       Email = x.Element("email")?.Value.Trim(),
                                       DiaChi = x.Element("diaChi")?.Value.Trim()
                                   }).ToList();

            _context.KhachHangs.AddRange(khachHangs);
            _context.SaveChanges();
        }

        public void ImportNhaXuatBanToSQL(string filePath)
        {
            _context.NhaXuatBans.ExecuteDelete(); 
            XDocument xmlDoc = XDocument.Load(filePath);

            var nhaXuatBans = xmlDoc.Descendants("NhaXuatBan")
                                    .Select(x => new NhaXuatBan
                                    {
                                        MaNxb = x.Element("maNXB")?.Value.Trim(),
                                        TenNxb = x.Element("tenNXB")?.Value.Trim(),
                                    }).ToList();

            _context.NhaXuatBans.AddRange(nhaXuatBans);
            _context.SaveChanges();
        }

        public void ImportTacGiumToSQL(string filePath)
        {
            
            _context.TacGia.ExecuteDelete(); 
            XDocument xmlDoc = XDocument.Load(filePath);

            // Bước 3: Parse dữ liệu XML thành danh sách TacGium
            var tacGiums = xmlDoc.Descendants("TacGia")
                                 .Select(x => new TacGium
                                 {
                                     MaTg = x.Element("maTG")?.Value.Trim(),
                                     TenTg = x.Element("tenTG")?.Value.Trim(),
                                 }).ToList();

            _context.TacGia.AddRange(tacGiums);
            _context.SaveChanges();
        }

        public void ImportTheLoaiToSQL(string filePath)
        {
           
            _context.TheLoais.ExecuteDelete(); 
            XDocument xmlDoc = XDocument.Load(filePath);
            var theLoais = xmlDoc.Descendants("TheLoai")
                                 .Select(x => new TheLoai
                                 {
                                     MaTheLoai = x.Element("maTheLoai")?.Value.Trim(),
                                     TenTheLoai = x.Element("tenTheLoai")?.Value.Trim(),
                                     MaDanhMuc = x.Element("maDanhMuc")?.Value.Trim(),
                                 }).ToList();

            _context.TheLoais.AddRange(theLoais);
            _context.SaveChanges();
        }

    }




}
