using System;
using System.Collections.Generic;

namespace WebsiteBanSach.Models;

public partial class NhaXuatBan
{
    public string MaNxb { get; set; } = null!;

    public string? TenNxb { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
