using System;
using System.Collections.Generic;

namespace Day07.Models;

public partial class SanPham
{
    public int MaSp { get; set; }

    public string TenSanPham { get; set; } = null!;

    public int MaLoai { get; set; }

    public int SoLuong { get; set; }

    public decimal DonGia { get; set; }

    public string? MoTa { get; set; }

    public bool TrangThai { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual LoaiSanPham MaLoaiNavigation { get; set; } = null!;
}
