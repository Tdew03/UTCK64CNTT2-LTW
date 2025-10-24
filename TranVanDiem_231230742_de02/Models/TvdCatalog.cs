using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TranVanDiem_231230742_de02.Models;

[Table("tvdCatalog")]
public partial class TvdCatalog
{
    [Key]
    [Column("tvdId")]
    public int TvdId { get; set; }

    [Column("tvdCateName")]
    [StringLength(100)]
    public string TvdCateName { get; set; } = null!;

    [Column("tvdCatePrice", TypeName = "decimal(18, 2)")]
    public decimal TvdCatePrice { get; set; }

    [Column("tvdCateQty")]
    public int TvdCateQty { get; set; }

    [Column("tvdPicture")]
    [StringLength(255)]
    public string? TvdPicture { get; set; }

    [Column("tvdCateActive")]
    public bool TvdCateActive { get; set; }
}
