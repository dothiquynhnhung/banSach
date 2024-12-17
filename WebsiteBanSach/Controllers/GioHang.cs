using Microsoft.AspNetCore.Mvc;

namespace WebsiteBanSach.Controllers
{
    public class GioHang : Controller
    {
        private const string CartSessionKey = "Cart";
        public IActionResult gioHang()
        {
            return View();
        }
    }
}
