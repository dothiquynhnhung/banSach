using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebsiteBanSach.Models;

namespace WebsiteBanSach.Controllers
{
    public class XMLToSQL : Controller
    {
        private readonly Models.XMLToSQL _xmlToSql;

        public XMLToSQL(Models.XMLToSQL xmlToSql)
        {
            _xmlToSql = xmlToSql;
        }

        public IActionResult xMLToSQL()
        {
            delete();
            import();

            return Content("Dữ liệu cũ đã bị xóa và dữ liệu mới đã được ghi thành công từ XML!");
        }

        public void import()
        {
            string filePath1 = "wwwroot/fileXML/KhachHang.xml";
            _xmlToSql.ImportKhachHangToSQL(filePath1);

            string filePath2 = "wwwroot/fileXML/NhaXuatBan.xml";
            _xmlToSql.ImportNhaXuatBanToSQL(filePath2);

            string filePath3 = "wwwroot/fileXML/DanhMuc.xml";
            _xmlToSql.ImportDanhMucToSQL(filePath3);

            string filePath4 = "wwwroot/fileXML/TacGia.xml";
            _xmlToSql.ImportTacGiumToSQL(filePath4);

            string filePath5 = "wwwroot/fileXML/TheLoai.xml";
            _xmlToSql.ImportTheLoaiToSQL(filePath5);

            string filePath6 = "wwwroot/fileXML/Sach.xml";
            _xmlToSql.ImportBooksFromXML(filePath6);

            string filePath7 = "wwwroot/fileXML/HoaDon.xml";
            _xmlToSql.ImportHoaDonToSQL(filePath7);

            string filePath8 = "wwwroot/fileXML/ChiTietHoaDon.xml";
            _xmlToSql.ImportChiTietHoaDonToSQL(filePath8);
        }

        public void delete()
        {
            _xmlToSql.deleteChiTietHoaDon();
            _xmlToSql.deleteHoaDon();
            _xmlToSql.deleteBooks();
            _xmlToSql.deleteTheLoai();
            _xmlToSql.deleteTacGia();
            _xmlToSql.deleteDanhMuc();
            _xmlToSql.deleteNhaXuatBan();
            _xmlToSql.deleteKhachHang();

        }
    }
    }
