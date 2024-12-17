using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace WebsiteBanSach.Models;

public partial class TacGium
{
    public string MaTg { get; set; } = null!;

    public string? TenTg { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();

    public TacGium getTacGiaByID(String id)
    {
        string filePath = "wwwroot/fileXML/TacGia.xml";
        XDocument xmlDoc = XDocument.Load(filePath);
        TacGium tacGia = xmlDoc.Descendants("TacGia")
                           .Where(s => s.Element("maTG")?.Value.Trim() == id)
                           .Select(x => new TacGium
                           {
                               MaTg = x.Element("maTG")?.Value.Trim(),
                               TenTg = x.Element("tenTG")?.Value.Trim(),
                           })
                           .FirstOrDefault();

        return tacGia;
    }
}
