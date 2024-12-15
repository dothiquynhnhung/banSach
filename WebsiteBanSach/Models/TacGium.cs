using System;
using System.Collections.Generic;

namespace WebsiteBanSach.Models;

public partial class TacGium
{
    public string MaTg { get; set; } = null!;

    public string? TenTg { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
