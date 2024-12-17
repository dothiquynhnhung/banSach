using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace WebsiteBanSach.Models;

public partial class DanhMuc
{
    public string MaDanhMuc { get; set; } = null!;

    public string? TenDanhMuc { get; set; }

    public virtual ICollection<TheLoai> TheLoais { get; set; } = new List<TheLoai>();
    public List<DanhMuc> GetDanhMucs()
    {
        string filePath = "wwwroot/fileXML/DanhMuc.xml";
        XDocument xmlDoc = XDocument.Load(filePath);
        List<DanhMuc> danhMucs = xmlDoc.Descendants("DanhMuc").Select(x => new DanhMuc
        {
            MaDanhMuc = x.Element("maDanhMuc")?.Value.Trim(),
            TenDanhMuc = x.Element("tenDanhMuc")?.Value.Trim()
        })
                .ToList();
        return danhMucs;
    }

    public DanhMuc getDanhMucByID(string id)
    {
        string filePath = "wwwroot/fileXML/danhMuc.xml";
        XDocument xmlDoc = XDocument.Load(filePath);
        DanhMuc dm = xmlDoc.Descendants("DanhMuc")
                           .Where(s => s.Element("maDanhMuc")?.Value.Trim() == id)
                           .Select(x => new DanhMuc
                           {
                               MaDanhMuc = x.Element("maDanhMuc")?.Value.Trim(),
                               TenDanhMuc = x.Element("tenDanhMuc")?.Value.Trim()
                           })
                           .FirstOrDefault();

        return dm;
    }
}
