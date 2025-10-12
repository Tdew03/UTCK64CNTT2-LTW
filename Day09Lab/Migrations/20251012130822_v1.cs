using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day09Lab.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KHACH_HANG",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhachHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HoTenKhachHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NgayDangKy = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KHACH_HA__3214EC2789061B61", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOAI_SAN_PHAM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOAI_SAN__3214EC27D4DCD1FB", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QUAN_TRI",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__QUAN_TRI__3214EC27D876CA03", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HOA_DON",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHoaDon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaKhachHang = table.Column<int>(type: "int", nullable: true),
                    NgayHoaDon = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgayNhan = table.Column<DateTime>(type: "datetime", nullable: true),
                    HoTenKhachHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TongTriGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HOA_DON__3214EC2701F86DE7", x => x.ID);
                    table.ForeignKey(
                        name: "FK__HOA_DON__MaKhach__52593CB8",
                        column: x => x.MaKhachHang,
                        principalTable: "KHACH_HANG",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SAN_PHAM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSanPham = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaLoai = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SAN_PHAM__3214EC2712E4685B", x => x.ID);
                    table.ForeignKey(
                        name: "FK__SAN_PHAM__MaLoai__4F7CD00D",
                        column: x => x.MaLoai,
                        principalTable: "LOAI_SAN_PHAM",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CT_HOA_DON",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoaDonID = table.Column<int>(type: "int", nullable: true),
                    SanPhamID = table.Column<int>(type: "int", nullable: true),
                    SoLuongMua = table.Column<int>(type: "int", nullable: true),
                    DonGiaMua = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CT_HOA_D__3214EC2748397BD1", x => x.ID);
                    table.ForeignKey(
                        name: "FK__CT_HOA_DO__HoaDo__5535A963",
                        column: x => x.HoaDonID,
                        principalTable: "HOA_DON",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__CT_HOA_DO__SanPh__5629CD9C",
                        column: x => x.SanPhamID,
                        principalTable: "SAN_PHAM",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CT_HOA_DON_HoaDonID",
                table: "CT_HOA_DON",
                column: "HoaDonID");

            migrationBuilder.CreateIndex(
                name: "IX_CT_HOA_DON_SanPhamID",
                table: "CT_HOA_DON",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_HOA_DON_MaKhachHang",
                table: "HOA_DON",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_SAN_PHAM_MaLoai",
                table: "SAN_PHAM",
                column: "MaLoai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CT_HOA_DON");

            migrationBuilder.DropTable(
                name: "QUAN_TRI");

            migrationBuilder.DropTable(
                name: "HOA_DON");

            migrationBuilder.DropTable(
                name: "SAN_PHAM");

            migrationBuilder.DropTable(
                name: "KHACH_HANG");

            migrationBuilder.DropTable(
                name: "LOAI_SAN_PHAM");
        }
    }
}
