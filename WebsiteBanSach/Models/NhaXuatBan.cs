using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace WebsiteBanSach.Models;

public partial class NhaXuatBan
{
    public string MaNxb { get; set; } = null!;

    public string? TenNxb { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
    public NhaXuatBan getXuatBanById(String id)
    {
        string filePath = "wwwroot/fileXML/NhaXuatBan.xml";
        XDocument xmlDoc = XDocument.Load(filePath);
        NhaXuatBan nhaXuatBan = xmlDoc.Descendants("NhaXuatBan")
                           .Where(s => s.Element("maNXB")?.Value.Trim() == id)
                           .Select(x => new NhaXuatBan
                           {
                               MaNxb = x.Element("maNXB")?.Value.Trim(),
                               TenNxb = x.Element("tenNXB")?.Value.Trim(),
                           })
                           .FirstOrDefault();

        return nhaXuatBan;
    }
}
