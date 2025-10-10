using System;
using System.Collections.Generic;

namespace Day07.Models;

public partial class KhachHang
{
    public int MaKhachHang { get; set; }

    public string HoTenKhachHang { get; set; } = null!;

    public string? Email { get; set; }

    public string? MaSoThue { get; set; }

    public string? DienThoai { get; set; }

    public string? DiaChi { get; set; }

    public DateOnly? NgayDangKy { get; set; }

    public bool TrangThai { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
