using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;
using WebsiteBanSach.Models;

namespace WebsiteBanSach.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DanhMuc dm = new DanhMuc();
            List<DanhMuc> danhMucs = dm.GetDanhMucs();  
            ViewBag.danhMucs= danhMucs;

            Sach sach = new Sach();
            List<Sach> sachs = sach.getSachs();
            ViewBag.sachs = sachs;


            return View();
        }

    }
}
