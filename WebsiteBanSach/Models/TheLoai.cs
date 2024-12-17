using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace WebsiteBanSach.Models;

public partial class TheLoai
{
    public string MaTheLoai { get; set; } = null!;

    public string? TenTheLoai { get; set; }

    public string? MaDanhMuc { get; set; }

    public virtual DanhMuc? MaDanhMucNavigation { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
    public TheLoai getTheLoaiById(string id)
    {
        string filePath = "wwwroot/fileXML/TheLoai.xml";
        XDocument xmlDoc = XDocument.Load(filePath);
        TheLoai theLoai = xmlDoc.Descendants("TheLoai")
                           .Where(s => s.Element("maTheLoai")?.Value.Trim() == id)
                           .Select(x => new TheLoai
                           {
                               MaTheLoai = x.Element("maTheLoai")?.Value.Trim(),
                               TenTheLoai = x.Element("tenTheLoai")?.Value.Trim(),
                               MaDanhMuc = x.Element("maDanhMuc")?.Value.Trim(),
                           })
                           .FirstOrDefault();

        return theLoai;
    }
}
