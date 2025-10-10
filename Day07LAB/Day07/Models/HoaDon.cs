using System;
using System.Collections.Generic;

namespace Day07.Models;

public partial class HoaDon
{
    public int MaHoaDon { get; set; }

    public int MaKhachHang { get; set; }

    public DateOnly NgayHoaDon { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;
}
