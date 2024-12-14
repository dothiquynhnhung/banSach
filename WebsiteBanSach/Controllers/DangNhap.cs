using Microsoft.AspNetCore.Mvc;

namespace WebsiteBanSach.Controllers
{
    public class DangNhap : Controller
    {
        public IActionResult dangKy()
        {
            return View();
        }

        public IActionResult dangNhap()
        {
            return View();
        }
    }
}
