using System;
using System.Collections.Generic;

namespace WebsiteBanSach.Models;

public partial class TheLoai
{
    public string MaTheLoai { get; set; } = null!;

    public string? TenTheLoai { get; set; }

    public string? MaDanhMuc { get; set; }

    public virtual DanhMuc? MaDanhMucNavigation { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
