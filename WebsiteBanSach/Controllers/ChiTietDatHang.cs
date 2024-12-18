using Microsoft.AspNetCore.Mvc;

namespace WebsiteBanSach.Controllers
{
    public class ChiTietDatHang : Controller
    {
        public IActionResult chiTietDatHang(String idDonHang)
        {
            List<DH> dhList = ViewBag.donHangs;

            List<DH> dhs = dhList.Where(d => d.MaHD == idDonHang).ToList();
            ViewBag.dhchiTiet = dhs;  
            ViewBag.maHd = idDonHang;


            Models.HoaDon hd = new Models.HoaDon();
            ViewBag.hoaDon = hd.getHoaDonById(idDonHang); 
            return View();
        }
    }
}
