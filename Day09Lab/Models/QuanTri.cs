using System;
using System.Collections.Generic;

namespace Day09Lab.Models;

public partial class QuanTri
{
    public int Id { get; set; }

    public string? TaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public bool? TrangThai { get; set; }
}
