using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebsiteBanSach.Models;

namespace WebsiteBanSach.Controllers
{
    public class ChiTietSanPham : Controller
    {
        private const string CartSessionKey = "Cart";

        
        public IActionResult chiTietSanPham(String idSach)
        {
            Sach sach = new Sach();
            ViewBag.DetailSach = sach.getSachById(idSach);

            return View();
        }

        public ActionResult AddToCart(string MaSach, string TenSach, int NamXb, int SoTrang, string AnhSach, string MoTa, int SoLuong,
                            string TrongLuong, decimal GiaBan, string MaTg, string MaTheLoai, string MaNxb, int soLuongmua)
        {
            const string CartSessionKey = "Cart";

            var cart = HttpContext.Session.GetObjectFromJson<List<WebsiteBanSach.Models.GioHang>>(CartSessionKey) ?? new List<WebsiteBanSach.Models.GioHang>();

            // Kiểm tra sách đã tồn tại trong giỏ hàng chưa
            var existingItem = cart.FirstOrDefault(x => x.Sach.MaSach == MaSach);
            if (existingItem != null)
            {
                existingItem.SoLuong++; // Tăng số lượng nếu đã tồn tại
            }
            else
            {
                // Thêm sách mới vào giỏ hàng
                cart.Add(new WebsiteBanSach.Models.GioHang
                {
                    Sach = new Sach()
                    {
                        MaSach = MaSach,
                        TenSach = TenSach,
                        NamXb = NamXb,
                        SoTrang = SoTrang,
                        AnhSach = AnhSach,
                        MoTa = MoTa,
                        SoLuong = SoLuong,
                        TrongLuong = TrongLuong,
                        GiaBan = GiaBan,
                        MaTg = MaTg,
                        MaTheLoai = MaTheLoai,
                        MaNxb = MaNxb,
                    }, 
                    SoLuong = soLuongmua
                });
            }
            WebsiteBanSach.Models.GioHang gh = new WebsiteBanSach.Models.GioHang(); 
            HttpContext.Session.SetInt32("tongGioHang", gh.GetTotalItems(cart));
            // Lưu giỏ hàng vào Session
            HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);

            return RedirectToAction("chiTietSanPham", new {idSach = MaSach}); 
        }


    }
}
