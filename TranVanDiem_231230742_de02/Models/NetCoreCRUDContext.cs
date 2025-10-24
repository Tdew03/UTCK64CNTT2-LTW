using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TranVanDiem_231230742_de02.Models;

public partial class NetCoreCRUDContext : DbContext
{
    public NetCoreCRUDContext()
    {
    }

    public NetCoreCRUDContext(DbContextOptions<NetCoreCRUDContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TvdCatalog> TvdCatalogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-RQC2G9N;Database=tranvandiem_231230742_de02;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TvdCatalog>(entity =>
        {
            entity.HasKey(e => e.TvdId).HasName("PK__tvdCatal__C46E26486A354A85");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
