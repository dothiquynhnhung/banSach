using System;
using System.Collections.Generic;

namespace WebsiteBanSach.Models;

public partial class DanhMuc
{
    public string MaDanhMuc { get; set; } = null!;

    public string? TenDanhMuc { get; set; }

    public virtual ICollection<TheLoai> TheLoais { get; set; } = new List<TheLoai>();
}
