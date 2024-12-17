using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebsiteBanSach.Models;

namespace WebsiteBanSach.Controllers
{
	public class QuanLyTaiKhoan : Controller
	{
		public IActionResult dangKy()
		{
			return View();
		}

		// DANGNHAP
		public IActionResult dangNhap()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(string email, string matKhau)
		{
			try
			{
				string filePath = "wwwroot/fileXML/KhachHang.xml";
				XDocument xmlDoc = XDocument.Load(filePath);

				List<KhachHang> khachHangList = xmlDoc.Descendants("KhachHang")
					.Where(kh => kh.Element("email") != null && kh.Element("matKhau") != null)
					.Select(kh => new KhachHang
					{
						MaKh = kh.Element("maKH")?.Value.Trim() ?? string.Empty,
						Email = kh.Element("email")?.Value.Trim() ?? string.Empty,
						MatKhau = kh.Element("matKhau")?.Value.Trim() ?? string.Empty,
						TenKh = kh.Element("tenKH")?.Value ?? string.Empty,
						DiaChi = kh.Element("diaChi")?.Value ?? string.Empty,
						Sdt = kh.Element("SDT")?.Value ?? string.Empty
					})
					.ToList();


				var khachHang = khachHangList.FirstOrDefault(kh => kh.Email == email && kh.MatKhau == matKhau);

				if (khachHang != null)
				{
					HttpContext.Session.SetString("maKhachHang", khachHang.MaKh);
					HttpContext.Session.SetString("tenKH", khachHang.TenKh);
					HttpContext.Session.SetString("email", khachHang.Email);
					HttpContext.Session.SetString("SDT", khachHang.Sdt);
					HttpContext.Session.SetString("diaChi", khachHang.DiaChi);
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng, vui lòng thử lại!";
					return RedirectToAction("dangNhap", "QuanLyTaiKhoan");
				}

			}
			catch (Exception ex)
			{
				ViewBag.Error = "Có lỗi xảy ra: " + ex.Message;
				return View("dangNhap");
			}
		}
		public IActionResult doiMatKhau()
		{
			return View();
		}
		//ĐỔI MẬT KHẨU
		[HttpPost]
		public IActionResult doiMatKhau(string mkHienTai, string mkMoi, string mkNhapLai)
		{
			if (mkMoi != mkNhapLai)
			{
				TempData["Message"] = "Mật khẩu không khớp!";
				return RedirectToAction("doiMatKhau");
			}

			try
			{
				XDocument xmlDoc = XDocument.Load("wwwroot/fileXML/KhachHang.xml");

				var khachHang = xmlDoc.Descendants("KhachHang")
					.FirstOrDefault(kh => kh.Element("matKhau")?.Value == mkHienTai);

				if (khachHang != null)
				{
					khachHang.Element("matKhau").Value = mkMoi;
					xmlDoc.Save("wwwroot/fileXML/khachHang.xml");
					TempData["Message"] = "Đổi mật khẩu thành công!";
				}
				else
				{
					TempData["Message"] = "Mật khẩu hiện tại không chính xác!";
				}
			}
			catch (Exception ex)
			{
				TempData["Message"] = $"Có lỗi xảy ra: {ex.Message}";
			}

			return RedirectToAction("doiMatKhau");


		}

		// HIỂN THỊ THÔNG TIN TÀI KHOẢN
		[HttpGet]
		public IActionResult hoSoCaNhan()
		{
			var tenKH = HttpContext.Session.GetString("tenKH");
			var email = HttpContext.Session.GetString("email");
			var SDT = HttpContext.Session.GetString("SDT");
			var diaChi = HttpContext.Session.GetString("diaChi");

			ViewData["email"] = email;
			ViewData["diaChi"] = diaChi;
			ViewData["tenKH"] = tenKH;
			ViewData["SDT"] = SDT;

			return View();


		}

		[HttpPost]
		public IActionResult Register(String customerName, String email, String address,String telphone,String pass)
		{
			KhachHang kh = new KhachHang()
			{
				MaKh = KhachHang.GenerateRandomId(), 
				TenKh = customerName, 
				MatKhau = pass, 
				Sdt = telphone, 
				Email = email,
				DiaChi = address, 
            };
			WriteKhachHangToXml(kh); 

            return RedirectToAction("dangNhap", "QuanLyTaiKhoan");

		}
        public static void WriteKhachHangToXml(KhachHang hd)
        {
            XDocument doc = XDocument.Load("wwwroot/fileXML/KhachHang.xml");
            XElement invoice = new XElement("KhachHang",
                new XElement("maKH", hd.MaKh),
                new XElement("tenKH", hd.TenKh	),
                new XElement("matKhau", hd.MatKhau),
                new XElement("SDT", hd.Sdt),
                new XElement("email", hd.Email),
                new XElement("diaChi", hd.DiaChi)
            );
            doc.Element("NewDataSet")?.Add(invoice);
            doc.Save("wwwroot/fileXML/KhachHang.xml");
        }
    }
}




